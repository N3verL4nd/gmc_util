using Gmc.Model;
using System;
using System.Runtime.InteropServices;

namespace Gmc
{
    /// <summary>
    /// 医保卡刷扣费
    /// </summary>
    public class SiPosPay
    {
        #region 接口说明

        /*输入参数 InputData
                typedef struct		
                {		
                char trans[2];//交易类型（'00'-签到 '01'-消费 '02'-消费撤销  '03'-退货  '04'-查询  '05'-结算 
                 '06'-银联扫码消费 '07'-银联扫码撤销  '07'-银联扫码退货）
                char CardType[2];		//卡类型‘00’-银联卡；‘01’-新社保卡
                char amount[12];		//金额（12 字节，无小数点，左补 0，单位：分）
                char card_no[20];		//卡号(20 字节，左对齐，不足部分补空格)
                char old_reference[12];       //原交易参考号，退货时用，默认空格
                char old_trace[6];		//原交易流水号，撤销时用，默认空格
                char UserNO[15];		//原交易商户号，默认空格，配置文件中读取
                char TerNO[15];		//原交易终端号，默认空格，配置文件中读取
                char Date[8];			//原交易日期 yyyymmdd，退货时用，默认空格
                char Memo[100];                 //社保卡退货时传入原消费虚账流水号，银联扫码消费传入银联串码，银联扫码撤销和银联扫码退货传入付款凭证号，其他默认补空格
                } InputData;	

                输出 参数OutPutData
                typedef struct
                {
                char resp_code[2];		//0～1 位 返回码	( 2 字节， "00"成功)
                char card_no[20];		//卡号 (20 字节，左对齐，不足部分补空格)
                char 	amount[12];		//金额（12 字节，无小数点，左补 0，单位：分）
                char 	reference[12]; 	//交易参考号
                char trace[6]; 			//流水号 (6 字节，左对齐)
                char UserNO[15];		//商户号
                char TerNO[15];		//终端号
                char CardType[2];		//卡类型
                char expr[4];			//有效期(4 字节) ，返回空格
                char BatchNo[10];		//批次号
                char Date[8];			//交易日期 yyyymmdd
                char Time[6];			//交易时间 hhmmss
                char CardName[20];  	//发卡行中文名，返回发卡行行号
                char old_amount[12];	//原交易金额（12 字节，无小数点，左补 0，单位：分）
                char old_reference[12];	//原交易参考号 
                char old_trace[6];		//原交易流水号
                char old_UserNO[15];	//原交易商户号
                char old_TerNO[15];		//原交易终端号
                char old_Date[8];		//原交易日期 yyyymmdd
                char resp_chin[100];		//错误说明(100 字节，左对齐，不足部分补空格)
                char Memo[100];                 //社保卡消费时返回虚账流水号，银联扫码消费返回付款凭证号
                } OutPutData;

         */
        /*
         *1、撤销和退货必要入参：金额、流水号、批次号、参考号、交易日期、交易ID
         * 如果是无卡退货则必要入参 在加上 银行卡号和介质类型
         *2、撤销：只能撤销当日、当批次、当终端读卡器交易的消费
         *3、退货：可以跨天、跨窗口、跨终端退费
         *4、需要把银联的gmc文件夹拷贝到每一台客户端C盘根目录下
         *   否则提示调用失败，找不到运达的接口DLL文件
         */

        #endregion

        #region 接口变量
        [DllImport(@"C:\gmc\posinf_outer.dll")]
        public static extern int BankTrans_pw(byte[] InStr, byte[] OutStr);
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errText = string.Empty;
        #endregion

        #region 签到
        /// <summary>
        /// 签到
        /// </summary>
        public int PosSignIn()
        {
            byte[] inStr = new byte[512];
            byte[] outStr = new byte[512];
            Array.Clear(inStr, 0, 512);
            Array.Clear(outStr, 0, 512);

            //交易类型（'00'-签到 '01'-消费 '02'-消费撤销  '03'-退货  '04'-查询  '05'-结算 '06'-银联扫码消费 '07'-银联扫码撤销  '07'-银联扫码退货）
            SetArrayInfo(inStr, 0, 2, "00");
            //卡类型‘00’-银联卡；‘01’-新社保卡
            SetArrayInfo(inStr, 2, 2, "00");
            //金额（12 字节，无小数点，左补 0，单位：分）
            SetArrayInfo(inStr, 4, 12, " ");
            //卡号(20 字节，左对齐，不足部分补空格)
            SetArrayInfo(inStr, 16, 20, " ");
            //原交易参考号，退货时用，默认空格
            SetArrayInfo(inStr, 36, 12, " ");
            //原交易流水号，撤销时用，默认空格
            SetArrayInfo(inStr, 48, 6, " ");
            //原交易商户号，默认空格，配置文件中读取
            SetArrayInfo(inStr, 54, 15, " ");
            //原交易终端号，默认空格，配置文件中读取
            SetArrayInfo(inStr, 69, 15, " ");
            //原交易日期 yyyymmdd，退货时用，默认空格
            SetArrayInfo(inStr, 84, 8, " ");
            //社保卡退货时传入原消费虚账流水号，银联扫码消费传入银联串码，银联扫码撤销和银联扫码退货传入付款凭证号，其他默认补空格
            SetArrayInfo(inStr, 92, 100, " ");

            int ret = BankTrans_pw(inStr, outStr);
            if (ret < 0)
            {
                return -1;
            }
            else
            {
                PosPayOutData bankBalance = new PosPayOutData();
                bankBalance.reference = System.Text.Encoding.Default.GetString(outStr, 0, 2);//0～1 位 返回码	( 2 字节， "00"成功)
                bankBalance.card_no = System.Text.Encoding.Default.GetString(outStr, 2, 20);//卡号 (20 字节，左对齐，不足部分补空格)
                bankBalance.amount = System.Text.Encoding.Default.GetString(outStr, 22, 12);//金额（12 字节，无小数点，左补 0，单位：分）
                bankBalance.reference = System.Text.Encoding.Default.GetString(outStr, 34, 12);//交易参考号
                bankBalance.trace = System.Text.Encoding.Default.GetString(outStr, 46, 6);//流水号 (6 字节，左对齐)
                bankBalance.UserNO = System.Text.Encoding.Default.GetString(outStr, 52, 15);//商户号
                bankBalance.TerNO = System.Text.Encoding.Default.GetString(outStr, 67, 15);//终端号
                bankBalance.CardType = System.Text.Encoding.Default.GetString(outStr, 82, 2);//卡类型
                bankBalance.expr = System.Text.Encoding.Default.GetString(outStr, 84, 4);//有效期(4 字节) ，返回空格
                bankBalance.BatchNo = System.Text.Encoding.Default.GetString(outStr, 88, 10);//批次号
                bankBalance.Date = System.Text.Encoding.Default.GetString(outStr, 98, 8);//交易日期 yyyymmdd
                bankBalance.Time = System.Text.Encoding.Default.GetString(outStr, 106, 6);//交易时间 hhmmss
                bankBalance.CardName = System.Text.Encoding.Default.GetString(outStr, 112, 20);//发卡行中文名，返回发卡行行号
                bankBalance.old_amount = System.Text.Encoding.Default.GetString(outStr, 132, 12);//原交易金额（12 字节，无小数点，左补 0，单位：分）
                bankBalance.old_reference = System.Text.Encoding.Default.GetString(outStr, 144, 12);//原交易参考号 
                bankBalance.old_trace = System.Text.Encoding.Default.GetString(outStr, 156, 6);//原交易流水号
                bankBalance.old_UserNO = System.Text.Encoding.Default.GetString(outStr, 162, 15);//原交易商户号
                bankBalance.old_TerNO = System.Text.Encoding.Default.GetString(outStr, 177, 15);//原交易终端号
                bankBalance.old_Date = System.Text.Encoding.Default.GetString(outStr, 192, 8);//原交易日期 yyyymmdd
                bankBalance.resp_chin = System.Text.Encoding.Default.GetString(outStr, 200, 100);//错误说明(100 字节，左对齐，不足部分补空格)
                bankBalance.Memo = System.Text.Encoding.Default.GetString(outStr, 300, 100); //社保卡消费时返回虚账流水号，银联扫码消费返回付款凭证号
                if (bankBalance.resp_code == "00")
                {
                    //this.errText=bankBalance.resp_chin;
                    return 1;
                }
                else
                {
                    this.errText = bankBalance.resp_chin;
                    return -1;
                }

            }
        }
        #endregion

        #region 消费
        /// <summary>
        /// 消费
        /// </summary>
        /// <param name="amount">消费金额</param>
        /// <param name="soft_flow">HIS流水号</param>
        /// <param name="bankBalance">消费银联返回参数</param>
        public int POSConsume(string amount, string soft_flow, ref PosPayOutData bankBalance)
        {


            //bankBalance.card_no = CardInfo.ToString();
            amount = amount.PadLeft(12, '0');
            byte[] inStr = new byte[512];
            byte[] outStr = new byte[512];
            Array.Clear(inStr, 0, 512);
            Array.Clear(outStr, 0, 512);

            //交易类型（'00'-签到 '01'-消费 '02'-消费撤销  '03'-退货  '04'-查询  '05'-结算 '06'-银联扫码消费 '07'-银联扫码撤销  '07'-银联扫码退货）
            SetArrayInfo(inStr, 0, 2, "01");
            //卡类型‘00’-银联卡；‘01’-新社保卡
            SetArrayInfo(inStr, 2, 2, "01");
            //金额（12 字节，无小数点，左补 0，单位：分）
            SetArrayInfo(inStr, 4, 12, amount);
            //卡号(20 字节，左对齐，不足部分补空格)
            SetArrayInfo(inStr, 16, 20, " ");
            //原交易参考号，退货时用，默认空格
            SetArrayInfo(inStr, 36, 12, " ");
            //原交易流水号，撤销时用，默认空格
            SetArrayInfo(inStr, 48, 6, " ");
            //原交易商户号，默认空格，配置文件中读取
            SetArrayInfo(inStr, 54, 15, " ");
            //原交易终端号，默认空格，配置文件中读取
            SetArrayInfo(inStr, 69, 15, " ");
            //原交易日期 yyyymmdd，退货时用，默认空格
            SetArrayInfo(inStr, 84, 8, " ");
            //社保卡退货时传入原消费虚账流水号，银联扫码消费传入银联串码，银联扫码撤销和银联扫码退货传入付款凭证号，其他默认补空格
            SetArrayInfo(inStr, 92, 100, " ");

            int ret = BankTrans_pw(inStr, outStr);
            if (ret < 0)
            {
                errText = System.Text.Encoding.Default.GetString(outStr, 200, 100);
                return -1;
            }
            else
            {
                bankBalance.resp_code = System.Text.Encoding.Default.GetString(outStr, 0, 2);//0～1 位 返回码	( 2 字节， "00"成功)
                bankBalance.card_no = System.Text.Encoding.Default.GetString(outStr, 2, 20);//卡号 (20 字节，左对齐，不足部分补空格)
                bankBalance.amount = amount;//金额（12 字节，无小数点，左补 0，单位：分）
                bankBalance.reference = System.Text.Encoding.Default.GetString(outStr, 34, 12);//交易参考号
                bankBalance.trace = System.Text.Encoding.Default.GetString(outStr, 46, 6);//流水号 (6 字节，左对齐)
                bankBalance.UserNO = System.Text.Encoding.Default.GetString(outStr, 52, 15);//商户号
                bankBalance.TerNO = System.Text.Encoding.Default.GetString(outStr, 67, 15);//终端号
                bankBalance.CardType = System.Text.Encoding.Default.GetString(outStr, 82, 2);//卡类型
                bankBalance.expr = System.Text.Encoding.Default.GetString(outStr, 84, 4);//有效期(4 字节) ，返回空格
                bankBalance.BatchNo = System.Text.Encoding.Default.GetString(outStr, 88, 10);//批次号
                bankBalance.Date = System.Text.Encoding.Default.GetString(outStr, 98, 8);//交易日期 yyyymmdd
                bankBalance.Time = System.Text.Encoding.Default.GetString(outStr, 106, 6);//交易时间 hhmmss
                bankBalance.CardName = System.Text.Encoding.Default.GetString(outStr, 112, 20);//发卡行中文名，返回发卡行行号
                bankBalance.old_amount = System.Text.Encoding.Default.GetString(outStr, 132, 12);//原交易金额（12 字节，无小数点，左补 0，单位：分）
                bankBalance.old_reference = System.Text.Encoding.Default.GetString(outStr, 144, 12);//原交易参考号 
                bankBalance.old_trace = System.Text.Encoding.Default.GetString(outStr, 156, 6);//原交易流水号
                bankBalance.old_UserNO = System.Text.Encoding.Default.GetString(outStr, 162, 15);//原交易商户号
                bankBalance.old_TerNO = System.Text.Encoding.Default.GetString(outStr, 177, 15);//原交易终端号
                bankBalance.old_Date = System.Text.Encoding.Default.GetString(outStr, 192, 8);//原交易日期 yyyymmdd
                bankBalance.resp_chin = System.Text.Encoding.Default.GetString(outStr, 200, 100);//错误说明(100 字节，左对齐，不足部分补空格)
                bankBalance.Memo = System.Text.Encoding.Default.GetString(outStr, 300, 100); //社保卡消费时返回虚账流水号，银联扫码消费返回付款凭证号
                bankBalance.trans_type = "01";//交易类型
                bankBalance.soft_flow = soft_flow;//HIS交易流水号
                if (bankBalance.resp_code == "00")
                {
                    errText = bankBalance.resp_chin;
                    return 1;
                }
                else
                {
                    errText = bankBalance.resp_chin;
                    return -1;
                }

            }
        }
        #endregion

        #region 撤销
        /// <summary>
        /// 撤销
        /// 金额、流水号、批次、参考号、交易日期、交易ID
        /// 有卡必须入参
        /// 无卡退货 介质类型和银行卡号是必须的
        /// </summary>
        /// <param name="bankBalance">消费返回实体</param>
        /// /// <param name="bankBalanceYS">撤销返回实体</param>
        public int POSConsumeCancle(PosPayOutData bankBalance, ref PosPayOutData bankBalanceYS)
        {
            string amount = bankBalance.amount.PadLeft(12, '0');
            byte[] inStr = new byte[512];
            byte[] outStr = new byte[512];
            Array.Clear(inStr, 0, 512);
            Array.Clear(outStr, 0, 512);

            //交易类型（'00'-签到 '01'-消费 '02'-消费撤销  '03'-退货  '04'-查询  '05'-结算 '06'-银联扫码消费 '07'-银联扫码撤销  '07'-银联扫码退货）
            SetArrayInfo(inStr, 0, 2, "02");
            //卡类型‘00’-银联卡；‘01’-新社保卡
            SetArrayInfo(inStr, 2, 2, "01");
            //金额（12 字节，无小数点，左补 0，单位：分）
            SetArrayInfo(inStr, 4, 12, amount);
            //卡号(20 字节，左对齐，不足部分补空格)
            SetArrayInfo(inStr, 16, 20, " ");
            //原交易参考号，退货时用，默认空格
            SetArrayInfo(inStr, 36, 12, bankBalance.reference);
            //原交易流水号，撤销时用，默认空格
            SetArrayInfo(inStr, 48, 6, bankBalance.trace);
            //原交易商户号，默认空格，配置文件中读取
            SetArrayInfo(inStr, 54, 15, " ");
            //原交易终端号，默认空格，配置文件中读取
            SetArrayInfo(inStr, 69, 15, " ");
            //原交易日期 yyyymmdd，退货时用，默认空格
            SetArrayInfo(inStr, 84, 8, " ");
            //社保卡退货时传入原消费虚账流水号，银联扫码消费传入银联串码，银联扫码撤销和银联扫码退货传入付款凭证号，其他默认补空格
            SetArrayInfo(inStr, 92, 100, " ");

            int ret = BankTrans_pw(inStr, outStr);
            if (ret < 0)
            {
                errText = System.Text.Encoding.Default.GetString(outStr, 200, 100);
                return -1;
            }
            else
            {
                bankBalanceYS.resp_code = System.Text.Encoding.Default.GetString(outStr, 0, 2);//0～1 位 返回码	( 2 字节， "00"成功)
                bankBalanceYS.card_no = System.Text.Encoding.Default.GetString(outStr, 2, 20);//卡号 (20 字节，左对齐，不足部分补空格)
                bankBalanceYS.amount = System.Text.Encoding.Default.GetString(outStr, 22, 12);//金额（12 字节，无小数点，左补 0，单位：分）
                bankBalanceYS.reference = System.Text.Encoding.Default.GetString(outStr, 34, 12);//交易参考号
                bankBalanceYS.trace = System.Text.Encoding.Default.GetString(outStr, 46, 6);//流水号 (6 字节，左对齐)
                bankBalanceYS.UserNO = System.Text.Encoding.Default.GetString(outStr, 52, 15);//商户号
                bankBalanceYS.TerNO = System.Text.Encoding.Default.GetString(outStr, 67, 15);//终端号
                bankBalanceYS.CardType = System.Text.Encoding.Default.GetString(outStr, 82, 2);//卡类型
                bankBalanceYS.expr = System.Text.Encoding.Default.GetString(outStr, 84, 4);//有效期(4 字节) ，返回空格
                bankBalanceYS.BatchNo = System.Text.Encoding.Default.GetString(outStr, 88, 10);//批次号
                bankBalanceYS.Date = System.Text.Encoding.Default.GetString(outStr, 98, 8);//交易日期 yyyymmdd
                bankBalanceYS.Time = System.Text.Encoding.Default.GetString(outStr, 106, 6);//交易时间 hhmmss
                bankBalanceYS.CardName = System.Text.Encoding.Default.GetString(outStr, 112, 20);//发卡行中文名，返回发卡行行号
                bankBalanceYS.old_amount = System.Text.Encoding.Default.GetString(outStr, 132, 12);//原交易金额（12 字节，无小数点，左补 0，单位：分）
                bankBalanceYS.old_reference = System.Text.Encoding.Default.GetString(outStr, 144, 12);//原交易参考号 
                bankBalanceYS.old_trace = System.Text.Encoding.Default.GetString(outStr, 156, 6);//原交易流水号
                bankBalanceYS.old_UserNO = System.Text.Encoding.Default.GetString(outStr, 162, 15);//原交易商户号
                bankBalanceYS.old_TerNO = System.Text.Encoding.Default.GetString(outStr, 177, 15);//原交易终端号
                bankBalanceYS.old_Date = System.Text.Encoding.Default.GetString(outStr, 192, 8);//原交易日期 yyyymmdd
                bankBalanceYS.resp_chin = System.Text.Encoding.Default.GetString(outStr, 200, 100);//错误说明(100 字节，左对齐，不足部分补空格)
                bankBalanceYS.Memo = System.Text.Encoding.Default.GetString(outStr, 300, 100); //社保卡消费时返回虚账流水号，银联扫码消费返回付款凭证号
                bankBalanceYS.trans_type = "02";//交易类型
                bankBalanceYS.soft_flow = bankBalance.soft_flow;//HIS交易流水号
                if (bankBalanceYS.resp_code == "00")
                {
                    errText = bankBalanceYS.resp_chin;
                    return 1;
                }
                else
                {
                    errText = bankBalanceYS.resp_chin;
                    return -1;
                }

            }
        }
        #endregion

        #region 退货
        /// <summary>
        /// 退货
        /// 金额、流水号、批次、参考号、交易日期、交易ID
        /// 有卡必须入参
        /// 无卡退货 介质类型和银行卡号是必须的
        /// </summary>
        /// <param name="bankBalance">消费返回实体</param>
        /// <param name="bankBalanceYS">退货返回实体</param>
        public int POSConsumeReturn(PosPayOutData bankBalance, ref PosPayOutData bankBalanceYS)
        {
            //string maount1 = (Neusoft.FrameWork.Function.NConvert.ToDecimal(amout)*100).ToString();
            string amount = bankBalance.amount.PadLeft(12, '0');
            byte[] inStr = new byte[512];
            byte[] outStr = new byte[512];
            Array.Clear(inStr, 0, 512);
            Array.Clear(outStr, 0, 512);

            //交易类型（'00'-签到 '01'-消费 '02'-消费撤销  '03'-退货  '04'-查询  '05'-结算 '06'-银联扫码消费 '07'-银联扫码撤销  '07'-银联扫码退货）
            SetArrayInfo(inStr, 0, 2, "03");
            //卡类型‘00’-银联卡；‘01’-新社保卡
            SetArrayInfo(inStr, 2, 2, "01");
            //金额（12 字节，无小数点，左补 0，单位：分）
            SetArrayInfo(inStr, 4, 12, amount);
            //卡号(20 字节，左对齐，不足部分补空格)
            SetArrayInfo(inStr, 16, 20, " ");
            //原交易参考号，退货时用，默认空格
            SetArrayInfo(inStr, 36, 12, bankBalance.reference);
            //原交易流水号，撤销时用，默认空格
            SetArrayInfo(inStr, 48, 6, " ");
            //原交易商户号，默认空格，配置文件中读取
            SetArrayInfo(inStr, 54, 15, " ");
            //原交易终端号，默认空格，配置文件中读取
            SetArrayInfo(inStr, 69, 15, " ");
            //原交易日期 yyyymmdd，退货时用，默认空格
            SetArrayInfo(inStr, 84, 8, bankBalance.Date);
            //社保卡退货时传入原消费虚账流水号，银联扫码消费传入银联串码，银联扫码撤销和银联扫码退货传入付款凭证号，其他默认补空格
            SetArrayInfo(inStr, 92, 100, " ");
            int ret = BankTrans_pw(inStr, outStr);
            if (ret < 0)
            {
                errText = System.Text.Encoding.Default.GetString(outStr, 200, 100);
                return -1;
            }
            else
            {
                bankBalanceYS.resp_code = System.Text.Encoding.Default.GetString(outStr, 0, 2);//0～1 位 返回码	( 2 字节， "00"成功)
                bankBalanceYS.card_no = System.Text.Encoding.Default.GetString(outStr, 2, 20);//卡号 (20 字节，左对齐，不足部分补空格)
                bankBalanceYS.amount = System.Text.Encoding.Default.GetString(outStr, 4, 12); ;//金额（12 字节，无小数点，左补 0，单位：分）
                bankBalanceYS.reference = System.Text.Encoding.Default.GetString(outStr, 34, 12);//交易参考号
                bankBalanceYS.trace = System.Text.Encoding.Default.GetString(outStr, 46, 6);//流水号 (6 字节，左对齐)
                bankBalanceYS.UserNO = System.Text.Encoding.Default.GetString(outStr, 52, 15);//商户号
                bankBalanceYS.TerNO = System.Text.Encoding.Default.GetString(outStr, 67, 15);//终端号
                bankBalanceYS.CardType = System.Text.Encoding.Default.GetString(outStr, 82, 2);//卡类型
                bankBalanceYS.expr = System.Text.Encoding.Default.GetString(outStr, 84, 4);//有效期(4 字节) ，返回空格
                bankBalanceYS.BatchNo = System.Text.Encoding.Default.GetString(outStr, 88, 10);//批次号
                bankBalanceYS.Date = System.Text.Encoding.Default.GetString(outStr, 98, 8);//交易日期 yyyymmdd
                bankBalanceYS.Time = System.Text.Encoding.Default.GetString(outStr, 106, 6);//交易时间 hhmmss
                bankBalanceYS.CardName = System.Text.Encoding.Default.GetString(outStr, 112, 20);//发卡行中文名，返回发卡行行号
                bankBalanceYS.old_amount = System.Text.Encoding.Default.GetString(outStr, 132, 12);//原交易金额（12 字节，无小数点，左补 0，单位：分）
                bankBalanceYS.old_reference = System.Text.Encoding.Default.GetString(outStr, 144, 12);//原交易参考号 
                bankBalanceYS.old_trace = System.Text.Encoding.Default.GetString(outStr, 156, 6);//原交易流水号
                bankBalanceYS.old_UserNO = System.Text.Encoding.Default.GetString(outStr, 162, 15);//原交易商户号
                bankBalanceYS.old_TerNO = System.Text.Encoding.Default.GetString(outStr, 177, 15);//原交易终端号
                bankBalanceYS.old_Date = System.Text.Encoding.Default.GetString(outStr, 192, 8);//原交易日期 yyyymmdd
                bankBalanceYS.resp_chin = System.Text.Encoding.Default.GetString(outStr, 200, 100);//错误说明(100 字节，左对齐，不足部分补空格)
                bankBalanceYS.Memo = System.Text.Encoding.Default.GetString(outStr, 300, 100); //社保卡消费时返回虚账流水号，银联扫码消费返回付款凭证号
                bankBalanceYS.trans_type = "03";//交易类型
                bankBalanceYS.soft_flow = bankBalance.soft_flow;//HIS交易流水号
                if (bankBalanceYS.resp_code == "00")
                {
                    errText = bankBalanceYS.resp_chin;
                    return 1;
                }
                else
                {
                    errText = bankBalanceYS.resp_chin;
                    return -1;
                }

            }
        }
        #endregion

        #region 拼接字符串
        /// <summary>
        /// 拼接字符串
        /// </summary>
        /// <param name="src">字符串</param>
        /// <param name="stratIdx">字符串开始索引</param>
        /// <param name="length">字符串字节数</param>
        /// <param name="devString">补齐字符</param>
        public void SetArrayInfo(byte[] src, int stratIdx, int length, string devString)
        {
            if (devString.Length < length)
            {
                devString = devString.PadLeft(length, ' ');
            }
            for (int idx = 0; idx < length; idx++)
            {
                src[stratIdx + idx] = (byte)devString.ToCharArray()[idx];
            }
        }
        #endregion



    }
}
