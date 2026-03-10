
namespace Gmc.Model
{
    /// <summary>
    /// 银联交易
    /// </summary>
    public class PosPayOutData
    {
        /// <summary>
        /// //0～1 位 返回码	( 2 字节， "00"成功)
        /// </summary>
        public string resp_code { get; set; }
        /// <summary>
        /// //卡号 (20 字节，左对齐，不足部分补空格)
        /// </summary>
        public string card_no { get; set; }
        /// <summary>
        /// //金额（12 字节，无小数点，左补 0，单位：分）
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        /// //交易参考号
        /// </summary>
        public string reference { get; set; }
        /// <summary>
        /// //流水号 (6 字节，左对齐)
        /// </summary>
        public string trace { get; set; }
        /// <summary>
        /// //商户号
        /// </summary>
        public string UserNO { get; set; }
        /// <summary>
        /// //终端号
        /// </summary>
        public string TerNO { get; set; }
        /// <summary>
        /// //卡类型
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// //有效期(4 字节) ，返回空格
        /// </summary>
        public string expr { get; set; }
        /// <summary>
        /// //批次号
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// //交易日期 yyyymmdd
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// //交易时间 hhmmss
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// //发卡行中文名，返回发卡行行号
        /// </summary>
        public string CardName { get; set; }
        /// <summary>
        /// //原交易金额（12 字节，无小数点，左补 0，单位：分）
        /// </summary>
        public string old_amount { get; set; }
        /// <summary>
        /// //原交易参考号 
        /// </summary>
        public string old_reference { get; set; }
        /// <summary>
        /// //原交易流水号
        /// </summary>
        public string old_trace { get; set; }
        /// <summary>
        /// //原交易商户号
        /// </summary>
        public string old_UserNO { get; set; }
        /// <summary>
        /// //原交易终端号
        /// </summary>
        public string old_TerNO { get; set; }
        /// <summary>
        /// //原交易日期 yyyymmdd
        /// </summary>
        public string old_Date { get; set; }
        /// <summary>
        /// //错误说明(100 字节，左对齐，不足部分补空格)
        /// </summary>
        public string resp_chin { get; set; }
        /// <summary>
        ///   //社保卡消费时返回虚账流水号，银联扫码消费返回付款凭证号
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        ///  交易类型
        /// </summary>
        public string trans_type { get; set; }

        /// <summary>
        /// //HIS交易流水号
        /// </summary>
        public string soft_flow { get; set; }
    }
}
