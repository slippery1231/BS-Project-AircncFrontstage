using Aircnc.FrontStage.Models.Dtos.RoomOwner;
using Aircnc.FrontStage.Models.Entities;
using AircncFrontStage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc.FrontStage.Services.RoomOwner
{
    public class HostReservationService
    {
        private readonly DBRepository _dBRepository;
        public HostReservationService(DBRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public IEnumerable<HostReservationDto> GetHostReservation(int id)
        {
            return _dBRepository.GetAll<Order>().Where(x => x.Room.UserId == id).Select(reservation => new HostReservationDto
            {
                RoomId = reservation.RoomId,
                OwnerId = id,
                GuestName = reservation.User.Name,
                OrderStatus = reservation.Status,
                BookingDateTime = reservation.BookingDateTime.ToString("yyyy/MM/dd"),
                CkeckIn = reservation.CkeckIn.ToString("yyyy/MM/dd"),
                CkeckOut = reservation.CkeckOut.ToString("yyyy/MM/dd"),
                BedCount = reservation.BedCount,
                RoomCount = reservation.RoomCount,
                GuestCount = reservation.GuestCount,
                PaymentType = reservation.PaymentType,
                Price = reservation.OriginalPrice,
                Country = reservation.Country,
                City = reservation.City,
                District = reservation.District,
                Street = reservation.Street,
                RoomName = reservation.RoomName,
                HouseType = reservation.Room.HouseType,
                RoomType = reservation.Room.RoomType
            }).ToList();
        }
    }
}
