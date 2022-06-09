using Aircnc.FrontStage.Models.DataModels.RoomOwner;
using Aircnc.FrontStage.Models.Dtos.Guest;
using Aircnc.FrontStage.Models.Entities;
using AircncFrontStage.Repositories;
using System;
using System.Linq;

namespace Aircnc.FrontStage.Services
{
    public class SaveOrderService
    {
        private readonly DBRepository _dbRepository;
        public SaveOrderService(DBRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public bool CreatOrder(BookingDto request)
        {
            using (var transaction = _dbRepository._DbContext.Database.BeginTransaction())
            {
                try
                {
                    var order = new Order()
                    {
                        BookingDateTime = request.BookingDateTime,
                        UserId = request.UserId,
                        RoomId = request.RoomId,
                        RoomName = request.RoomName,
                        CkeckIn = request.CkeckIn,
                        CkeckOut = request.CkeckOut,
                        PaymentType = request.PaymentType,
                        Status = request.Status,
                        BedCount = request.BedCount,
                        RoomCount = request.RoomCount,
                        GuestCount = request.GuestCount,
                        OriginalPrice = request.OriginalPrice,
                        Country = request.Country,
                        City = request.City,
                        District = request.District,
                        Street = request.Street,
                    };
                    _dbRepository.Create(order);
                    _dbRepository.Save();

                    //加入roomCalendar
                    for(int i = 0; i < request.CkeckOut.Subtract(request.CkeckIn).Days ; i++)
                    {
                        ChangeRoomStatusDataModel roomCalendarData = new()
                        {
                            RoomId = request.RoomId,
                            Date = request.CkeckIn.Date.AddDays(i),
                        };

                        if (isDataExist(roomCalendarData))
                        {
                            //已有資料，變更狀態
                            var target = _dbRepository.GetAll<RoomCalendar>().First(x => x.RoomId == roomCalendarData.RoomId && x.Date == roomCalendarData.Date);
                            target.RoomCalendarStatus = RoomCalendarStatusEnum.Booked;
                            target.LastChangeTime = DateTime.Now;
                            _dbRepository.Update<RoomCalendar>(target);
                        }
                        else
                        {
                            //沒有資料，建立一筆
                            var target = new RoomCalendar()
                            {
                                RoomId = roomCalendarData.RoomId,
                                Date= roomCalendarData.Date,
                                LastChangeTime = DateTime.Now,
                                RoomCalendarStatus = RoomCalendarStatusEnum.Booked,
                                UnitPrice = request.RoomTablePrice
                            };
                            _dbRepository.Create<RoomCalendar>(target);
                        }
                        _dbRepository.Save();
                    }
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    
                    transaction.Rollback();
                    return false;
                }
            }
            if (isCreated(request.RoomId, request.CkeckIn, request.CkeckOut))
            {
                return true;
            }
            else 
            { return false; }
            
        }

        public bool isDataExist(ChangeRoomStatusDataModel input)
        {
            var isExit = _dbRepository.GetAll<RoomCalendar>().Any(x => x.RoomId == input.RoomId && x.Date == input.Date);
            return isExit;
        }

        public bool isCreated(int roomId, DateTime checkIn, DateTime checkOut)
        {
            var created = _dbRepository.GetAll<Order>().Any(x => x.RoomId == roomId && x.CkeckIn == checkIn && x.CkeckOut == checkOut);
            return created;
        }
    }
}
