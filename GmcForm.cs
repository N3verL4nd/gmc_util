using Gmc.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Gmc
{
    public partial class GmcForm : Form
    {
        private string gmcPath;
        private string gmcUser;
        private string gmcPass;
        private List<PayLog> logList;
        public GmcForm()
        {
            InitializeComponent();
            gmcPath = @"C:\gmc";
            gmcUser = "testCallDll 用户名";
            gmcPass = "testCallDll 密码";

            gmcPathTextBox.Text = gmcPath;

            logList = new List<PayLog>();

            ToolTip fillToolTip = new ToolTip();
            fillToolTip.SetToolTip(fillButton, "请先点击启动GMC按钮！！！");
        }

        private bool LoginCheck()
        {
            if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "ClientHost")
            {
                refundButton.Visible = false;
                fillButton.Visible = false;
                openGmcButton.Visible = false;
                return true;
            }
            if (Environment.MachineName.ToLower() == "pc-lgh")
            {
                return true;
            }
            using (PasswordForm passwordForm = new PasswordForm())
            {
                if (passwordForm.ShowDialog() == DialogResult.OK)
                {
                    string password = passwordForm.Password;
					
					// 启动密码
                    if ("admin".Equals(password))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected override void OnLoad(EventArgs e)
        {
            // 登录校验
            if (!LoginCheck())
            {
                MessageBox.Show("密码有误，退出！！！");
                this.Close();
                return;
            }

            // 默认加载 C:\gmc\sst\umsips\umsips.log
            try
            {
                string filePath = @"C:\gmc\sst\umsips\umsips.log";
                if (File.Exists(filePath))
                {
                    fillData(filePath, true);
                }
            }
            catch (Exception)
            {
                // NOOP
            }
        }

        private void GmcPathLabel_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", gmcPath);

        }

        private void gmcPathTextBox_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            // 设置对话框的标题
            folderBrowserDialog.Description = "请选择GMC目录";
            // 设置默认打开路径
            folderBrowserDialog.SelectedPath = @"c:\gmc";

            // 显示对话框并获取用户的选择结果
            DialogResult result = folderBrowserDialog.ShowDialog();

            // 检查用户是否点击了"确定"按钮
            if (result == DialogResult.OK)
            {
                // 获取用户选择的目录路径
                string selectedPath = folderBrowserDialog.SelectedPath;

                gmcPathTextBox.Text = selectedPath;
                gmcPath = selectedPath;
            }
        }

        private void OpenGmcButton_Click(object sender, EventArgs e)
        {
            GmcTools.LoginGmc(gmcPath + "\\testCallDll.exe", gmcUser, gmcPass);
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "umsips*";
            dialog.Title = "请选择 umsips 日志文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            dialog.InitialDirectory = @"C:\gmc\sst\umsips";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("请选择 umsips 日志文件！！！");
                return;
            }
            fillData(filePath, false);
        }

        private void fillData(string filePath, bool init)
        {
            string today = DateTime.Now.ToString("yyyyMMdd");
            logList.Clear();
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fs, Encoding.GetEncoding("GB2312")))
                {
                    string line;
                    PayLog payLog = null;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Contains("TR_PrintResponse"))
                        {
                            // 交易记录-开始
                            if (line.Contains("返回码:"))
                            {
                                payLog = new PayLog();
                                payLog.RespCode = truncData(line);
                                payLog.LogDate = line.Substring(line.IndexOf("|") + 1, 14);

                            }
                            else if (line.Contains("返回码说明"))
                            {
                                if (payLog == null)
                                {
                                    continue;
                                }
                                payLog.RespDesc = truncData(line);
                            }
                            else if (line.Contains("卡号"))
                            {
                                if (payLog == null)
                                {
                                    continue;
                                }
                                payLog.CardNo = truncData(line);

                            }
                            else if (line.Contains("交易金额"))
                            {
                                if (payLog == null)
                                {
                                    continue;
                                }
                                string money = truncData(line);
                                if (string.IsNullOrEmpty(money))
                                {
                                    continue;
                                }
                                payLog.Amount = (decimal.Parse(money) / 100.0m).ToString();
                                payLog.AmountStr = money;
                            }
                            else if (line.Contains("凭证号"))
                            {
                                if (payLog == null)
                                {
                                    continue;
                                }
                                payLog.BatchCardNo = truncData(line);
                            }
                            else if (line.Contains("批次号"))
                            {
                                if (payLog == null)
                                {
                                    continue;
                                }
                                payLog.BatchNo = truncData(line);
                            }
                            else if (line.Contains("交易日期"))
                            {
                                if (payLog == null)
                                {
                                    continue;
                                }
                                payLog.Date = truncData(line);

                            }
                            else if (line.Contains("交易时间"))
                            {
                                if (payLog == null)
                                {
                                    continue;
                                }
                                payLog.Time = truncData(line);
                            }
                            else if (line.Contains("参考号"))
                            {
                                if (payLog == null)
                                {
                                    continue;
                                }
                                payLog.Reference = truncData(line);
                            }
                            else if (line.Contains("授权号"))
                            {
                                if (payLog == null)
                                {
                                    continue;
                                }
                                payLog.AuthNo = truncData(line);
                            }
                            else if (line.Contains("附加信息"))
                            {
                                if (payLog == null)
                                {
                                    continue;
                                }
                                payLog.Supplement = truncData(line);

                            }
                            // 交易记录-结束
                            else if (line.Contains("校验值"))
                            {
                                if (payLog == null)
                                {
                                    continue;
                                }
                                payLog.CheckVal = truncData(line);
                                logList.Add(payLog);
                            }
                        }
                    }
                }
            }
            //MessageBox.Show("共加载 " + logList.Count + " 项支付数据");
            logList = logList
                .OrderByDescending(log =>
                {
                    if (DateTime.TryParseExact(log.LogDate, "yyyyMMddHHmmss", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
                        return dt;
                    else
                        return DateTime.MinValue; // 排在最后（因为是降序，最小时间会排最后）
                })
                .ToList();
            resultDataGridView.DataSource = logList;
            
            /*
            // 自动滚动到最后一行并选中它
            if (resultDataGridView.Rows.Count > 0)
            {
                int lastRowIndex = resultDataGridView.Rows.Count - 1;
                resultDataGridView.FirstDisplayedScrollingRowIndex = lastRowIndex;
                resultDataGridView.ClearSelection();
                resultDataGridView.Rows[lastRowIndex].Selected = true;
            }
            */
        }

        /// <summary>
        /// 解析日志 <para />
        /// <param name="data">每行日志<para /></param>
        /// <returns>格式化后的参数</returns>
        /// </summary>
        private string truncData(string data)
        {
            int start = data.LastIndexOf("[") + 1;
            int last = data.LastIndexOf("]");
            return data.Substring(start, last - start).Trim();
        }

        private void MoneyTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            string money = moneyTextBox.Text;
            if (string.IsNullOrEmpty(money))
            {
                resultDataGridView.DataSource = logList;
                return;
            }
            List<PayLog> result = new List<PayLog>();
            foreach (var log in logList)
            {
                if (!string.IsNullOrEmpty(log.Amount) && log.Amount == money)
                {
                    result.Add(log);
                }
            }
            resultDataGridView.DataSource = result;
        }

        private void ResultDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult refoundResult = MessageBox.Show("是否确认退款？", "确认框", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (refoundResult != DialogResult.OK)
            {
                return;
            }
           
            int rowIndex = e.RowIndex;

            SiPosPay siPosPay = new SiPosPay();
            PosPayOutData posPayOutData = new PosPayOutData();
            // 退款金额
            posPayOutData.amount = resultDataGridView.Rows[rowIndex].Cells[5].Value.ToString();
            // 参考号
            posPayOutData.reference = resultDataGridView.Rows[rowIndex].Cells[6].Value.ToString();
            // 日期
            posPayOutData.Date = resultDataGridView.Rows[rowIndex].Cells[0].Value.ToString().Substring(0, 8);

            PosPayOutData posPayOutData2 = new PosPayOutData();
            siPosPay.POSConsumeReturn(posPayOutData, ref posPayOutData2);
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            if (resultDataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选中需要退款的订单！！！");
                return;
            }
            string date = resultDataGridView.SelectedRows[0].Cells[0].Value.ToString().Substring(0, 8);
            string amount = resultDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            string reference = resultDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            GmcTools.FillRefund(false, amount, reference, date);
        }

        private void refundButton_Click(object sender, EventArgs e)
        {
            if (resultDataGridView.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选中需要退款的订单！！！");
                return;
            }
            string date = resultDataGridView.SelectedRows[0].Cells[0].Value.ToString().Substring(0, 8);
            string amount = resultDataGridView.SelectedRows[0].Cells[5].Value.ToString();
            string reference = resultDataGridView.SelectedRows[0].Cells[6].Value.ToString();
            GmcTools.FillRefund(true, amount, reference, date);
        }
    }
}
