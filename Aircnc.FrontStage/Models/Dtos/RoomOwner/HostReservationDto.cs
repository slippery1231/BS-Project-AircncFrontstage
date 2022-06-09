using Aircnc.FrontStage.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc.FrontStage.Models.Dtos.RoomOwner
{
    public class HostReservationDto
    {
        public int RoomId { get; set; }
        public int OwnerId { get; set; }
        public string GuestName { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public string BookingDateTime { get; set; }
        public string CkeckIn { get; set; }
        public string CkeckOut { get; set; }

        //detail
        public string RoomName { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public int BedCount { get; set; }
        public int RoomCount { get; set; }
        public int GuestCount { get; set; }
        public decimal Price { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public HouseTypeEnum HouseType { get; set; }
        public RoomTypeEnum RoomType { get; set; }
    }
}
