using Aircnc.FrontStage.Models.Dtos.Guest;
using Aircnc.FrontStage.Models.ViewModels.Guest;
using Aircnc.FrontStage.Services.Guest;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircnc.FrontStage.Controllers.Guest
{
    public class SearchController : Controller
    {
        public readonly SearchRoomService _searchRoomService;
        private static int totalRows; //搜尋結果總筆數
        public SearchController(SearchRoomService searchRoomService)
        {
            _searchRoomService = searchRoomService;
        }
        [HttpGet]
        public IActionResult Search(string location, int id = 1)
        {
            //把從Home傳來的參數組成searchVM
            SearchVM searchVM = new SearchVM() { NavSearch = new NavSearchVMPost(), AdSearch = new AdvancedSearchVM() { houseTypes = new List<Models.Entities.HouseTypeEnum>(), roomTypes = new List<Models.Entities.RoomTypeEnum>(), roomServiceLabels = new List<Models.Entities.RoomServiceLabel.TypeOfLabelEnum>() } };

            if (location != null) 
            { 
                searchVM.NavSearch.Location = location.Trim();
                TempData["location"] = location.Trim();
            } 
            else 
            { 
                searchVM.NavSearch.Location = (string)TempData["location"]; 
            }
            if (TempData["startDate"] != null) { searchVM.NavSearch.StartDate = DateTime.Parse(TempData["startDate"].ToString()); }
            if (TempData["endDate"] != null) { searchVM.NavSearch.EndDate = DateTime.Parse(TempData["endDate"].ToString()); }
            if (TempData["numberofGuests"] != null) { searchVM.NavSearch.NumberOfGuests = (int)TempData["numberOfGuests"]; }
            //進行搜尋
            var rooms = _searchRoomService.searchContorller(searchVM);
            
            //將rooms往view傳生成地圖markers
            string jsonRooms = JsonConvert.SerializeObject(rooms);
            ViewData["Rooms"] = jsonRooms;

            //分頁
            int activePage = id;
            int pageRows = 8; // show rows per page
            totalRows = rooms.Count();

            int pages = 0; //計算總頁數
            if (totalRows % pageRows == 0)
            {
                pages = totalRows / pageRows;
            }
            else
            {
                pages = (totalRows / pageRows) + 1;
            }
            int startRow = (activePage - 1) * pageRows;
            var result = rooms.OrderByDescending(x => x.RoomId).Skip(startRow).Take(pageRows);
            searchVM.SearchRoom = result;

            ViewData["ActivePage"] = id;
            ViewData["Pages"] = pages;
            ViewData["TotalRows"] = totalRows;

            TempData.Keep();

            return View(searchVM);
        }

        [HttpPost]
        public IActionResult Search([FromBody]GetAdQuery request)
        {
            var searchVM = JsonConvert.DeserializeObject<SearchVM>(request.AdQuery);
            if (searchVM.AdSearch.houseTypes == null)
            {
                searchVM.AdSearch.houseTypes = new List<Models.Entities.HouseTypeEnum>();
            }
            if (searchVM.AdSearch.roomTypes == null)
            {
                searchVM.AdSearch.roomTypes = new List<Models.Entities.RoomTypeEnum>();
            }
            if (searchVM.AdSearch.roomServiceLabels == null)
            {
                searchVM.AdSearch.roomServiceLabels = new List<Models.Entities.RoomServiceLabel.TypeOfLabelEnum>();
            }
            var rooms = _searchRoomService.searchContorller(searchVM);
            
            return new JsonResult(rooms);
        }
    }
}
