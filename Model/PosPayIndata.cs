
namespace Gmc.Model
{
    public class PosPayIndata
    {
        /// <summary>
        /// 交易类型（'00'-签到 '01'-消费 '02'-消费撤销  '03'-退货  '04'-查询  '05'-结算  ‘15’—无秘无卡退货）
        /// </summary>
        public string Trans { get; set; }

        /// <summary>
        /// //卡类型‘00’-银联卡；‘01’-社保卡
        /// </summary>
        public string CardType { get; set; }
        /// <summary>
        /// //金额（12 字节，无小数点，左补 0，单位：分）
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        /// //卡号(20 字节，左对齐，无密无卡退货传入需要退货的全卡号，不足部分补空格，如“6288888888888888   ”；其他交易类型补充空格)
        /// </summary>
        public string card_no { get; set; }
        /// <summary>
        ///  //原交易参考号，退货时用，其他交易默认空格
        /// </summary>
        public string old_reference { get; set; }
        /// <summary>
        /// //原交易流水号，撤销时用，其他交易默认空格
        /// </summary>
        public string old_trace { get; set; }
        /// <summary>
        /// //原交易商户号，补足空格即可
        /// </summary>
        public string UserNO { get; set; }
        /// <summary>
        /// //原交易终端号，补足空格即可
        /// </summary>
        public string TerNO { get; set; }
        /// <summary>
        /// //原交易日期 yyyymmdd，退货时用，其他交易默认空格
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        ///  //社保卡退货时传入原消费虚账流水号，银联扫码消费传入银联串码，银联扫码撤销和银联扫码退货传入付款凭证号，其他默认补空格
        /// </summary>
        public string Memo { get; set; }
    }
}
