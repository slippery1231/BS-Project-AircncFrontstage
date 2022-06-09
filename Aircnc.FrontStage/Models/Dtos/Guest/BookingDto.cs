using Aircnc.FrontStage.Models.Entities;
using System;

namespace Aircnc.FrontStage.Models.Dtos.Guest
{
    public class BookingDto
    {
        
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
        public decimal RoomTablePrice { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
    }
}
