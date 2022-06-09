﻿using Aircnc.FrontStage.Models.Entities;
using Aircnc.FrontStage.Models.ViewModels.Order;
using Aircnc.FrontStage.Services;
using Aircnc.FrontStage.Services.Guest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc.FrontStage.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        private readonly RoomDetailService _roomDetailService;

        //private static int totalRows;
        //int Pages = 0;

        public OrderController(OrderService orderService , RoomDetailService roomDetailService)
        {
            _orderService = orderService;
            _roomDetailService = roomDetailService;
        }

        [Authorize]
        public IActionResult OrderList() //透過使用者ID去找他的訂單們
        {
            int userId = int.Parse(User.Identity.Name);
            _orderService.UpdateOrderStatus(_orderService.GetAllOrderByUserId(userId));
            var orderList = _orderService.GetAllOrderDtoByUserId(userId).Select(x => new OrderViewModel
            {
                CkeckIn = x.CkeckIn.ToString("yyyy/MM/dd"),
                CkeckOut = x.CkeckOut.ToString("yyyy/MM/dd"),
                RoomName = x.RoomName,
                City = x.City,
                District = x.District,
                Street = x.Street,
                RoomImg = x.RoomImg,
                RoomOwnerName = x.RoomOwnerName,
                Status = x.Status,
                RoomId = x.RoomId

            });

            var result = orderList.OrderBy(x => x.CkeckIn);
            return View(result);


            //#region//分頁功能
            //if (totalRows == 0)
            //{
            //    totalRows = _orderService.GetAllOrderByUserId(userId).Count();
            //}

            //int activePage = id; //目前所在分頁
            //int pageRows = 2; //每頁幾筆資料

            ////計算頁數
            //if (totalRows % pageRows == 0)
            //{
            //    Pages = totalRows / pageRows;
            //}
            //else
            //{
            //    Pages = (totalRows / pageRows) + 1;
            //}
            //int startRow = (activePage - 1) * pageRows; //紀錄起始index
            //var result = orderList.OrderBy(x => x.CkeckIn).Skip(startRow).Take(pageRows);

            //ViewData["ActivePage"] = id; //active分頁碼
            //ViewData["Pages"] = Pages; //總頁數
            //#endregion

        }

    }
}
