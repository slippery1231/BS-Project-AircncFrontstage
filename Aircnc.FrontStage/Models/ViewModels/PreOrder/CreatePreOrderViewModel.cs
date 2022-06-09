using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc.FrontStage.Models.ViewModels.PreOrder
{
    public class CreatePreOrderViewModel
    {
        public string MerchantID { get; set; }//2000132
        public string MerchantTradeNo { get; set; }//ecPay1234
        public string MerchantTradeDate { get; set; }//2012/03/21 15:40:18 格式為：yyyy/MM/dd HH:mm:ss
        public string PaymentType { get; set; }//請固定填入 aio
        public int TotalAmount { get; set; }
        public string TradeDesc { get; set; }//ecpay 商城購物 平台名字
        public string ItemName { get; set; }//手機 20 元 X2#隨身碟60 元 X1 roomname
        public string ReturnURL { get; set; }
        public string ChoosePayment { get; set; }//Credit
        public string CheckMacValue { get; set; }//請參考附錄檢查碼機制
        public int EncryptType { get; set; }//請固定填入 1，使用 SHA256 加密。 
        public string OrderResultURL { get; set; } //當消費者付款完成後，綠界會將付款結果參數以幕前(Client POST)回傳到該網址。

    }
}
