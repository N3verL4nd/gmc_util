namespace Gmc.Model
{
    /// <summary>
    /// 银联交易
    /// </summary>
    public class PayLog
    {
        /// <summary>
        /// //日志日期
        /// </summary>
        public string LogDate { get; set; }
        /// <summary>
        /// //0～1 位 返回码	( 2 字节， "00"成功)
        /// </summary>
        public string RespCode { get; set; }
        /// <summary>
        /// //返回码说明
        /// </summary>
        public string RespDesc { get; set; }
        /// <summary>
        /// //卡号 (20 字节，左对齐，不足部分补空格)
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// //金额
        /// </summary>
        public string Amount { get; set; }
        /// <summary>
        /// //金额
        /// </summary>
        public string AmountStr { get; set; }
        /// <summary>
        /// //凭证号
        /// </summary>
        public string BatchCardNo { get; set; }
        /// <summary>
        /// //批次号
        /// </summary>
        public string BatchNo { get; set; }
        /// <summary>
        /// //交易日期 mmdd
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// //交易时间 hhmmss
        /// </summary>
        public string Time { get; set; }
        /// <summary>
        /// //交易参考号
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// //授权号
        /// </summary>
        public string AuthNo { get; set; }
        /// <summary>
        /// //授权号
        /// </summary>
        public string Supplement { get; set; }
        /// <summary>
        /// //校验值
        /// </summary>
        public string CheckVal { get; set; }
    }
}
