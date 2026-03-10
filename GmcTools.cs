using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Gmc
{
    public class GmcTools
    {
        #region Windows API 调用
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr parent, IntPtr child, string strClass, string frmText);
        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, string lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hwnd);

        private const int WM_CLOSE = 0x0010;
        private const int WM_SETTEXT = 0x000C;
        private const int BM_CLICK = 0x00F5;
        private const int CB_SELECTSTRING = 0x014D;

        #endregion

        public static void LoginGmc(string gmcPath, string gmcUser, string gmcPass)
        {
            RunGmc(gmcPath, "");
            IntPtr mainWnd = IntPtr.Zero;

            for (int i = 0; i < 10; i++)
            {
                mainWnd = FindWindow("Tloginfrm", "登录");
                if (mainWnd != IntPtr.Zero)
                {
                    break;
                }
                Thread.Sleep(100);
            }
            if (mainWnd == IntPtr.Zero)
            {
                MessageBox.Show("查找GMC登录框失败！！！");
                return;
            }

            SetForegroundWindow(mainWnd);

            IntPtr pwdPtr = FindWindowEx(mainWnd, IntPtr.Zero, "TEdit", null);
            if (pwdPtr == IntPtr.Zero)
            {
                MessageBox.Show("查找 GMC 用户名句柄失败！！！");
                return;
            }
            IntPtr usrPtr = FindWindowEx(mainWnd, pwdPtr, "TEdit", null);
            if (usrPtr == IntPtr.Zero)
            {
                MessageBox.Show("查找 GMC 密码句柄失败！！！");
                return;
            }
            IntPtr loginPtr = FindWindowEx(mainWnd, IntPtr.Zero, "TButton", "登录");
            
            if (loginPtr == IntPtr.Zero)
            {
                MessageBox.Show("查找 GMC 登陆按钮句柄失败！！！");
                return;
            }

            SendMessage(usrPtr, WM_SETTEXT, IntPtr.Zero, gmcUser);
            SendMessage(pwdPtr, WM_SETTEXT, IntPtr.Zero, gmcPass);
            SendMessage(loginPtr, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
        }

        private static void RunGmc(string gmcPath, string arg)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = gmcPath,
                    Arguments = arg,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            Thread.Sleep(500);
        }

        public static void FillRefund(bool autoCharge, string money, string reference, string date)
        {
            IntPtr mainWnd = IntPtr.Zero;

            for (int i = 0; i < 10; i++)
            {
                mainWnd = FindWindow("TCallingForm", "无界面调用PosInf.dll");
                if (mainWnd != IntPtr.Zero)
                {
                    break;
                }
                Thread.Sleep(100);
            }
            if (mainWnd == IntPtr.Zero)
            {
                MessageBox.Show("查找GMC退款失败！！！");
                return;
            }

            SetForegroundWindow(mainWnd);

            IntPtr groupBoxPtr = FindWindowEx(mainWnd, IntPtr.Zero, "TGroupBox", "输入");


            IntPtr chargeTypePtr = FindWindowEx(groupBoxPtr, IntPtr.Zero, "TComboBox", null);
            if (chargeTypePtr == IntPtr.Zero)
            {
                MessageBox.Show("查找 GMC 交易类型句柄失败！！！");
                return;
            }

            // 交易类型
            SendMessage(chargeTypePtr, CB_SELECTSTRING, IntPtr.Zero, "03--退货");


            IntPtr cardTypePtr = FindWindowEx(groupBoxPtr, IntPtr.Zero, "TEdit", "00");
            if (cardTypePtr == IntPtr.Zero)
            {
                MessageBox.Show("查找 GMC 卡类型句柄失败！！！");
                return;
            }
            SendMessage(cardTypePtr, WM_SETTEXT, IntPtr.Zero, "01");

            IntPtr moneyPtr = FindWindowEx(groupBoxPtr, IntPtr.Zero, "TEdit", "000000000001");
            if (moneyPtr == IntPtr.Zero)
            {
                MessageBox.Show("查找 GMC 金额句柄失败！！！");
                return;
            }
            SendMessage(moneyPtr, WM_SETTEXT, IntPtr.Zero, money);


            IntPtr referencePtr = FindWindowEx(groupBoxPtr, IntPtr.Zero, "TEdit", "123456123456");
            if (referencePtr == IntPtr.Zero)
            {
                MessageBox.Show("查找 GMC 参考号句柄失败！！！");
                return;
            }
            SendMessage(referencePtr, WM_SETTEXT, IntPtr.Zero, reference);


            IntPtr datePtr = FindWindowEx(groupBoxPtr, IntPtr.Zero, "TEdit", "20170101");
            if (datePtr == IntPtr.Zero)
            {
                MessageBox.Show("查找 GMC 日期句柄失败！！！");
                return;
            }
            SendMessage(datePtr, WM_SETTEXT, IntPtr.Zero, date);


            IntPtr chargePtr = FindWindowEx(groupBoxPtr, IntPtr.Zero, "TButton", "交易");

            if (chargePtr == IntPtr.Zero)
            {
                MessageBox.Show("查找 GMC 交易按钮句柄失败！！！");
                return;
            }

            if (autoCharge)
            {
                SendMessage(chargePtr, BM_CLICK, IntPtr.Zero, IntPtr.Zero);
            }
        }

    }
}
