
namespace Gmc
{
    partial class GmcForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GmcForm));
            this.gmcPathLabel = new System.Windows.Forms.Label();
            this.gmcPathTextBox = new System.Windows.Forms.TextBox();
            this.openGmcButton = new System.Windows.Forms.Button();
            this.logButton = new System.Windows.Forms.Button();
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.LogDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.moneyTextBox = new System.Windows.Forms.TextBox();
            this.fillButton = new System.Windows.Forms.Button();
            this.refundButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.respCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.respDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cardNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountStrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchCardNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkValDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.payLogBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payLogBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gmcPathLabel
            // 
            this.gmcPathLabel.AutoSize = true;
            this.gmcPathLabel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gmcPathLabel.Location = new System.Drawing.Point(12, 21);
            this.gmcPathLabel.Name = "gmcPathLabel";
            this.gmcPathLabel.Size = new System.Drawing.Size(86, 16);
            this.gmcPathLabel.TabIndex = 0;
            this.gmcPathLabel.Text = "GMC路径：";
            this.gmcPathLabel.Click += new System.EventHandler(this.GmcPathLabel_Click);
            // 
            // gmcPathTextBox
            // 
            this.gmcPathTextBox.Location = new System.Drawing.Point(91, 16);
            this.gmcPathTextBox.Name = "gmcPathTextBox";
            this.gmcPathTextBox.Size = new System.Drawing.Size(129, 21);
            this.gmcPathTextBox.TabIndex = 1;
            this.gmcPathTextBox.Click += new System.EventHandler(this.gmcPathTextBox_Click);
            // 
            // openGmcButton
            // 
            this.openGmcButton.Location = new System.Drawing.Point(134, 58);
            this.openGmcButton.Name = "openGmcButton";
            this.openGmcButton.Size = new System.Drawing.Size(86, 23);
            this.openGmcButton.TabIndex = 2;
            this.openGmcButton.Text = "启动GMC";
            this.openGmcButton.UseVisualStyleBackColor = true;
            this.openGmcButton.Click += new System.EventHandler(this.OpenGmcButton_Click);
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(15, 58);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(93, 23);
            this.logButton.TabIndex = 3;
            this.logButton.Text = "加载日志文件";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.LogButton_Click);
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.AllowUserToAddRows = false;
            this.resultDataGridView.AllowUserToDeleteRows = false;
            this.resultDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultDataGridView.AutoGenerateColumns = false;
            this.resultDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.resultDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LogDate,
            this.respCodeDataGridViewTextBoxColumn,
            this.respDescDataGridViewTextBoxColumn,
            this.cardNoDataGridViewTextBoxColumn,
            this.amountDataGridViewTextBoxColumn,
            this.amountStrDataGridViewTextBoxColumn,
            this.referenceDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.timeDataGridViewTextBoxColumn,
            this.batchCardNoDataGridViewTextBoxColumn,
            this.batchNoDataGridViewTextBoxColumn,
            this.authNoDataGridViewTextBoxColumn,
            this.supplementDataGridViewTextBoxColumn,
            this.checkValDataGridViewTextBoxColumn});
            this.resultDataGridView.DataSource = this.payLogBindingSource;
            this.resultDataGridView.Location = new System.Drawing.Point(12, 87);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.ReadOnly = true;
            this.resultDataGridView.RowTemplate.Height = 23;
            this.resultDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultDataGridView.Size = new System.Drawing.Size(1059, 419);
            this.resultDataGridView.TabIndex = 4;
            this.resultDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ResultDataGridView_CellContentDoubleClick);
            // 
            // LogDate
            // 
            this.LogDate.DataPropertyName = "LogDate";
            this.LogDate.HeaderText = "日志日期";
            this.LogDate.Name = "LogDate";
            this.LogDate.ReadOnly = true;
            this.LogDate.Width = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(237, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "金额：";
            // 
            // moneyTextBox
            // 
            this.moneyTextBox.Location = new System.Drawing.Point(289, 11);
            this.moneyTextBox.Name = "moneyTextBox";
            this.moneyTextBox.Size = new System.Drawing.Size(129, 21);
            this.moneyTextBox.TabIndex = 6;
            this.moneyTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MoneyTextBox_KeyUp);
            // 
            // fillButton
            // 
            this.fillButton.Location = new System.Drawing.Point(240, 58);
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(96, 23);
            this.fillButton.TabIndex = 7;
            this.fillButton.Text = "退款填充";
            this.fillButton.UseVisualStyleBackColor = true;
            this.fillButton.Click += new System.EventHandler(this.FillButton_Click);
            // 
            // refundButton
            // 
            this.refundButton.Location = new System.Drawing.Point(343, 58);
            this.refundButton.Name = "refundButton";
            this.refundButton.Size = new System.Drawing.Size(75, 23);
            this.refundButton.TabIndex = 8;
            this.refundButton.Text = "退款";
            this.refundButton.UseVisualStyleBackColor = true;
            this.refundButton.Click += new System.EventHandler(this.refundButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(436, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "选中列表相应支付记录，双击输入密码执行退款";
            // 
            // respCodeDataGridViewTextBoxColumn
            // 
            this.respCodeDataGridViewTextBoxColumn.DataPropertyName = "RespCode";
            this.respCodeDataGridViewTextBoxColumn.HeaderText = "返回码";
            this.respCodeDataGridViewTextBoxColumn.Name = "respCodeDataGridViewTextBoxColumn";
            this.respCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.respCodeDataGridViewTextBoxColumn.Width = 66;
            // 
            // respDescDataGridViewTextBoxColumn
            // 
            this.respDescDataGridViewTextBoxColumn.DataPropertyName = "RespDesc";
            this.respDescDataGridViewTextBoxColumn.HeaderText = "返回码说明";
            this.respDescDataGridViewTextBoxColumn.Name = "respDescDataGridViewTextBoxColumn";
            this.respDescDataGridViewTextBoxColumn.ReadOnly = true;
            this.respDescDataGridViewTextBoxColumn.Width = 90;
            // 
            // cardNoDataGridViewTextBoxColumn
            // 
            this.cardNoDataGridViewTextBoxColumn.DataPropertyName = "CardNo";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            this.cardNoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.cardNoDataGridViewTextBoxColumn.HeaderText = "卡号";
            this.cardNoDataGridViewTextBoxColumn.Name = "cardNoDataGridViewTextBoxColumn";
            this.cardNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cardNoDataGridViewTextBoxColumn.Width = 54;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            this.amountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.amountDataGridViewTextBoxColumn.HeaderText = "交易金额";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 78;
            // 
            // amountStrDataGridViewTextBoxColumn
            // 
            this.amountStrDataGridViewTextBoxColumn.DataPropertyName = "AmountStr";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            this.amountStrDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.amountStrDataGridViewTextBoxColumn.HeaderText = "原始交易金额";
            this.amountStrDataGridViewTextBoxColumn.Name = "amountStrDataGridViewTextBoxColumn";
            this.amountStrDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountStrDataGridViewTextBoxColumn.Width = 72;
            // 
            // referenceDataGridViewTextBoxColumn
            // 
            this.referenceDataGridViewTextBoxColumn.DataPropertyName = "Reference";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            this.referenceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.referenceDataGridViewTextBoxColumn.HeaderText = "参考号";
            this.referenceDataGridViewTextBoxColumn.Name = "referenceDataGridViewTextBoxColumn";
            this.referenceDataGridViewTextBoxColumn.ReadOnly = true;
            this.referenceDataGridViewTextBoxColumn.Width = 61;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "交易日期";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Width = 61;
            // 
            // timeDataGridViewTextBoxColumn
            // 
            this.timeDataGridViewTextBoxColumn.DataPropertyName = "Time";
            this.timeDataGridViewTextBoxColumn.HeaderText = "交易时间";
            this.timeDataGridViewTextBoxColumn.Name = "timeDataGridViewTextBoxColumn";
            this.timeDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeDataGridViewTextBoxColumn.Width = 61;
            // 
            // batchCardNoDataGridViewTextBoxColumn
            // 
            this.batchCardNoDataGridViewTextBoxColumn.DataPropertyName = "BatchCardNo";
            this.batchCardNoDataGridViewTextBoxColumn.HeaderText = "凭证号";
            this.batchCardNoDataGridViewTextBoxColumn.Name = "batchCardNoDataGridViewTextBoxColumn";
            this.batchCardNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchCardNoDataGridViewTextBoxColumn.Width = 61;
            // 
            // batchNoDataGridViewTextBoxColumn
            // 
            this.batchNoDataGridViewTextBoxColumn.DataPropertyName = "BatchNo";
            this.batchNoDataGridViewTextBoxColumn.HeaderText = "批次号";
            this.batchNoDataGridViewTextBoxColumn.Name = "batchNoDataGridViewTextBoxColumn";
            this.batchNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchNoDataGridViewTextBoxColumn.Width = 61;
            // 
            // authNoDataGridViewTextBoxColumn
            // 
            this.authNoDataGridViewTextBoxColumn.DataPropertyName = "AuthNo";
            this.authNoDataGridViewTextBoxColumn.HeaderText = "授权号";
            this.authNoDataGridViewTextBoxColumn.Name = "authNoDataGridViewTextBoxColumn";
            this.authNoDataGridViewTextBoxColumn.ReadOnly = true;
            this.authNoDataGridViewTextBoxColumn.Width = 61;
            // 
            // supplementDataGridViewTextBoxColumn
            // 
            this.supplementDataGridViewTextBoxColumn.DataPropertyName = "Supplement";
            this.supplementDataGridViewTextBoxColumn.HeaderText = "附加信息";
            this.supplementDataGridViewTextBoxColumn.Name = "supplementDataGridViewTextBoxColumn";
            this.supplementDataGridViewTextBoxColumn.ReadOnly = true;
            this.supplementDataGridViewTextBoxColumn.Width = 61;
            // 
            // checkValDataGridViewTextBoxColumn
            // 
            this.checkValDataGridViewTextBoxColumn.DataPropertyName = "CheckVal";
            this.checkValDataGridViewTextBoxColumn.HeaderText = "校验值";
            this.checkValDataGridViewTextBoxColumn.Name = "checkValDataGridViewTextBoxColumn";
            this.checkValDataGridViewTextBoxColumn.ReadOnly = true;
            this.checkValDataGridViewTextBoxColumn.Width = 61;
            // 
            // payLogBindingSource
            // 
            this.payLogBindingSource.DataSource = typeof(Gmc.Model.PayLog);
            // 
            // GmcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 523);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.refundButton);
            this.Controls.Add(this.fillButton);
            this.Controls.Add(this.moneyTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultDataGridView);
            this.Controls.Add(this.logButton);
            this.Controls.Add(this.openGmcButton);
            this.Controls.Add(this.gmcPathTextBox);
            this.Controls.Add(this.gmcPathLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GmcForm";
            this.Text = "银联          信息科-李广辉";
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payLogBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label gmcPathLabel;
        private System.Windows.Forms.TextBox gmcPathTextBox;
        private System.Windows.Forms.Button openGmcButton;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.DataGridView resultDataGridView;
        private System.Windows.Forms.BindingSource payLogBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox moneyTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn respCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn respDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cardNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountStrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchCardNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplementDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkValDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button fillButton;
        private System.Windows.Forms.Button refundButton;
        private System.Windows.Forms.Label label2;
    }
}

