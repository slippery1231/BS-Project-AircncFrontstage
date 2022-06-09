﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Aircnc.FrontStage.Models.Entities
{
    public partial class Order
    {
        public Order()
        {
            TransactionStatuses = new HashSet<TransactionStatus>();
        }

        [Key]
        public int OrderId { get; set; }
        public DateTime BookingDateTime { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public DateTime CkeckIn { get; set; }
        public DateTime CkeckOut { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public OrderStatusEnum Status { get; set; }
        public decimal? Discount { get; set; }
        public int BedCount { get; set; }
        public int RoomCount { get; set; }
        public int GuestCount { get; set; }
        public decimal OriginalPrice { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        //public string Address { get; set; }
        public string Street { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TransactionStatus> TransactionStatuses { get; set; }
    }
    public enum PaymentTypeEnum
    {
        [Description("信用卡")]
        CreditCard = 1,
        [Description("LinePay")]
        LinePay = 2
    }
    public enum OrderStatusEnum
    {
        [Description("已完成")]
        Past = 1 ,
        [Description("已取消")]
        Cancel = 2 ,
        [Description("將至旅程")]
        Future = 3
    }
}
