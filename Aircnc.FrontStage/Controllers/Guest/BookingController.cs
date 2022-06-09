using Aircnc.FrontStage.Models.ViewModels.Guest;
using Microsoft.AspNetCore.Mvc;
using Aircnc.FrontStage.Services.Guest;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Aircnc.FrontStage.Models.Dtos.Guest;
using Aircnc.FrontStage.Services;

namespace Aircnc.FrontStage.Controllers.Guest
{
    public class BookingController : Controller
    {
        private readonly RoomDetailService _roomDetailService;
        private readonly AverageRoomPriceService _averageRoomPriceService;
        private readonly SaveOrderService _saveOrderService;
        public BookingController(RoomDetailService roomDetailService, AverageRoomPriceService averageRoomPriceService, SaveOrderService saveOrderService)
        {
            _roomDetailService = roomDetailService;
            _averageRoomPriceService = averageRoomPriceService;
            _saveOrderService = saveOrderService;
        }
        public IActionResult BookingCheck()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Booking(SearchVM input)
        {
            input.roomDetailPost.userId = int.Parse(User.Identity.Name);
            int roomId = (int)TempData["roomId"];

            if (ModelState.IsValid)
            {
                var room = _roomDetailService.GetRoomDetailById(roomId);
                var detail = new RoomDetailViewModel()
                {
                    RoomId = roomId,
                    OwnerName = room.OwnerName,
                    RoomType = room.RoomType,
                    HouseType = room.HouseType,
                    District = room.District,
                    City = room.City,
                    RoomName = room.RoomName,
                    AvgStars = room.AvgStars,
                    ReviewsCount = room.Reviews.Count,
                    roomImgs = room.roomImgs
                };
                input.RoomDetailVM = detail;

                input.RoomDetailVM.UnitPrice = _averageRoomPriceService.FindPrice(roomId, input.roomDetailPost.startDate, input.roomDetailPost.endDate);
            }

            return View(input);
        }

        public IActionResult SaveOrder()
        {
            return View();
        }
        [HttpPost, Authorize, ValidateAntiForgeryToken]
        public IActionResult SaveOrder(SearchVM request)
        {

            var room = _roomDetailService.GetRoomDetailById(request.RoomDetailVM.RoomId);
            var bookingData = new BookingDto()
            {
                BookingDateTime = DateTime.Now,
                UserId = request.roomDetailPost.userId,
                RoomId = room.RoomId,
                RoomName = room.RoomName,
                CkeckIn = request.roomDetailPost.startDate,
                CkeckOut = request.roomDetailPost.endDate,
                PaymentType = Models.Entities.PaymentTypeEnum.CreditCard,
                Status = Models.Entities.OrderStatusEnum.Future,
                BedCount = room.BedCount,
                RoomCount = room.RoomCount,
                GuestCount = request.roomDetailPost.guestNumbers,
                OriginalPrice = request.RoomDetailVM.UnitPrice, //下訂時每天平均價格
                RoomTablePrice = room.UnitPrice,
                Country = room.Country,
                City = room.City,
                District = room.District,
                Street = room.Street,
            };
            var result = _saveOrderService.CreatOrder(bookingData);
            if (result == true)
            {
                return RedirectToAction("OrderList", "Order");
            }

            return NotFound();
        }
    }
}
