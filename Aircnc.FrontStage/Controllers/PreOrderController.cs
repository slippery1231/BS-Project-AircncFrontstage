using Aircnc.FrontStage.Models.Dtos.Guest;
using Aircnc.FrontStage.Models.Entities;
using Aircnc.FrontStage.Models.ViewModels.Guest;
using Aircnc.FrontStage.Services.Guest;
using Aircnc.FrontStage.Services.PreOrders;
using AircncFrontStage.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Aircnc.FrontStage.Controllers
{
    public class PreOrderController : Controller
    {
        private readonly PreOrderService _preOrderService;
        private readonly RoomDetailService _roomDetailService;
        private readonly DBRepository _dbRepository;

        public PreOrderController(PreOrderService preOrderService , RoomDetailService roomDetailService,DBRepository dBRepository)
        {
            _preOrderService = preOrderService;
            _roomDetailService = roomDetailService;
            _dbRepository = dBRepository;

        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult CreatePreOrder()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePreOrder(SearchVM request)
        {
            int userId = int.Parse(User.Identity.Name);
            var room = _roomDetailService.GetRoomDetailById(request.RoomDetailVM.RoomId);
            //int bookDayCunt = preOrder.CkeckOut.Subtract(preOrder.CkeckIn).Days
            var bookingData = new BookingDto()
            {
                BookingDateTime = DateTime.UtcNow.AddHours(8),
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
                OriginalPrice = request.RoomDetailVM.UnitPrice, 
                RoomTablePrice = room.UnitPrice,
                Country = room.Country,
                City = room.City,
                District = room.District,
                Street = room.Street,
            };
            var preOrderId = _preOrderService.CreatPreOrder(bookingData);
            var currentPreOrder = _preOrderService.GetPreOrderInfoToEcPay(preOrderId);
            currentPreOrder["CheckMacValue"] = GetCheckMacValue(currentPreOrder);
            return View(currentPreOrder);

        }


        /// <summary>
        /// 接綠界回傳回來的東西塞進order
        /// </summary>
        /// <param name="preOrderId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateOrder([FromForm] IFormCollection info , int preOrderId)
        {
            _preOrderService.CreateOrder(preOrderId,info);

            return Ok();
        }


        [HttpPost]
        public IActionResult AfterEcpay(int userId)
        {
            return  RedirectToAction("OrderList", "Order");
        }

        /// <summary>
        /// 取得 檢查碼
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private string GetCheckMacValue(Dictionary<string, string> order)
        {
            var param = order.Keys.OrderBy(x => x).Select(key => key + "=" + order[key]).ToList();

            var checkValue = string.Join("&", param);

            //測試用的 HashKey
            var hashKey = "5294y06JbISpM5x9";

            //測試用的 HashIV
            var HashIV = "v77hoKGq4kWxNNIS";

            checkValue = $"HashKey={hashKey}" + "&" + checkValue + $"&HashIV={HashIV}";

            checkValue = HttpUtility.UrlEncode(checkValue).ToLower();

            checkValue = GetSHA256(checkValue);

            return checkValue.ToUpper();
        }

        /// <summary>
        /// SHA256 編碼
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string GetSHA256(string value)
        {
            var result = new StringBuilder();
            var sha256 = SHA256Managed.Create();
            var bts = Encoding.UTF8.GetBytes(value);
            var hash = sha256.ComputeHash(bts);

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }

            return result.ToString();
        }


    }
}
