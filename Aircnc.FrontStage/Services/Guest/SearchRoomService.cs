using Aircnc.FrontStage.Models.Dtos.Guest;
using Aircnc.FrontStage.Models.Entities;
using Aircnc.FrontStage.Models.ViewModels.Guest;
using AircncFrontStage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircnc.FrontStage.Services.Guest
{
    public class SearchRoomService
    {
        private readonly DBRepository _dbRepository;
        private readonly AverageRoomPriceService _averageRoomPriceService;
        public SearchRoomService(DBRepository dbRepository, AverageRoomPriceService averageRoomPriceService)
        {
            _dbRepository = dbRepository;
            _averageRoomPriceService = averageRoomPriceService;
        }
        //Dto轉ViewModel
        public IEnumerable<SearchRoomViewModel> searchContorller(SearchVM searchVM)
        {
            var getRooms = GetRoom(searchVM).Select(SearchRoomDto => new SearchRoomViewModel
            {
                RoomId = SearchRoomDto.RoomId,
                UserId = SearchRoomDto.UserId,
                HouseType = SearchRoomDto.HouseType,
                RoomType = SearchRoomDto.RoomType,
                Status = SearchRoomDto.Status,
                RoomName = SearchRoomDto.RoomName,
                Pax = SearchRoomDto.Pax,
                RoomCount = SearchRoomDto.RoomCount,
                BedCount = SearchRoomDto.BedCount,
                BathroomCount = SearchRoomDto.BathroomCount,
                Country = SearchRoomDto.Country,
                City = SearchRoomDto.City,
                District = SearchRoomDto.District,
                UnitPrice = SearchRoomDto.UnitPrice,
                Lat = SearchRoomDto.Lat,
                Lng = SearchRoomDto.Lng,
                Comments = SearchRoomDto.Comments,
                Stars = SearchRoomDto.Stars,
                RoomServiceLabels = SearchRoomDto.RoomServiceLabels,
                RoomImgs = SearchRoomDto.RoomImgs,
            });
            return getRooms;
        }
        //呼叫Repository
        public IEnumerable<SearchRoomDto> GetRoom(SearchVM input)
        {
            //篩選地點
            var rooms = _dbRepository.GetAll<Room>().Where(room => (room.City.Contains(input.NavSearch.Location) || room.Country.Contains(input.NavSearch.Location) || room.District.Contains(input.NavSearch.Location)) && room.Status == RoomStatusEnum.Online).Select(room => new SearchRoomDto
            {
                RoomId = room.RoomId,
                UserId = room.UserId,
                HouseType = room.HouseType,
                RoomType = room.RoomType,
                Status = room.Status,
                RoomName = room.RoomName,
                Pax = room.Pax,
                RoomCount = room.RoomCount,
                BedCount = room.BedCount,
                BathroomCount = room.BathroomCount,
                Country = room.Country,
                City = room.City,
                District = room.District,
                UnitPrice = room.UnitPrice,
                Lat = room.Lat,
                Lng = room.Lng,
                                
            }).ToList();

            //篩選入住人數
            if (input.NavSearch.NumberOfGuests.HasValue)
            {
                rooms = rooms.Where(room => room.Pax >= input.NavSearch.NumberOfGuests.Value).ToList();
            }

            //篩選日期與計算平均房價
            if (input.NavSearch.StartDate.HasValue)
            {
                //var bookedRooms = _dbRepository.GetAll<Order>().Where(room => room.City.Contains(input.NavSearch.Location)).ToList();
                //var bRsByDate = bookedRooms.Where(room => 
                //                (room.CkeckOut > input.NavSearch.StartDate && room.CkeckOut <= input.NavSearch.EndDate) ||
                //                (room.CkeckIn >= input.NavSearch.StartDate && room.CkeckIn < input.NavSearch.EndDate) ||
                //                (room.CkeckIn <= input.NavSearch.StartDate && room.CkeckOut >= input.NavSearch.EndDate)).Select(room => room.RoomId).ToList();
                ////排除日期上已被預訂的房源
                //foreach (var room in rooms.ToList())
                //{
                //    if (bRsByDate.Contains(room.RoomId))
                //    {
                //        rooms.Remove(room);
                //    }
                //}


                //排除日期上已出租或被房東設為不出租的房源
                var roomCalendarList = _dbRepository.GetAll<RoomCalendar>().Where(x => rooms.Select(y => y.RoomId).Contains(x.RoomId)).ToList();

                foreach (var room in rooms.ToList())
                {
                    var notBook = roomCalendarList
                        .Where(x => x.RoomId == room.RoomId && x.Date >= input.NavSearch.StartDate && x.Date < input.NavSearch.EndDate && (x.RoomCalendarStatus == RoomCalendarStatusEnum.Hided || x.RoomCalendarStatus == RoomCalendarStatusEnum.Booked))
                        .Select(x => x.RoomId).ToList().Distinct();

                    if (notBook.Contains(room.RoomId))
                    {
                        rooms.Remove(room);
                    }
                }
                //查RoomCalendar是否有特別設定價格並算出平均房價
                foreach (var room in rooms)
                {
                    room.UnitPrice = _averageRoomPriceService.FindPrice(room.RoomId, DateTime.Parse(input.NavSearch.StartDate.ToString()), DateTime.Parse(input.NavSearch.EndDate.ToString()));
                }
            }
            //篩選房價
            if (input.AdSearch.minPrice != 0 && input.AdSearch.maxPrice != 0)
            {
                rooms = rooms.Where(room => room.UnitPrice >= input.AdSearch.minPrice && room.UnitPrice <= input.AdSearch.maxPrice).ToList();
            }
            else
            {
                rooms = rooms.Where(room => room.UnitPrice >= input.AdSearch.minPrice || room.UnitPrice <= input.AdSearch.maxPrice).ToList();
            }
            //篩選房源類型
            if (input.AdSearch.houseTypes.Count > 0)
            {
                rooms = rooms.Where(room => input.AdSearch.houseTypes.Contains(room.HouseType)).ToList();
            }
            //篩選房間類型
            if (input.AdSearch.roomTypes.Count > 0)
            {
                rooms = rooms.Where(room => input.AdSearch.roomTypes.Contains(room.RoomType)).ToList();
            }
            //篩選房間數
            if (input.AdSearch.roomCount != 0)
            {
                rooms = rooms.Where(room => room.RoomCount >= input.AdSearch.roomCount).ToList();
            }
            //篩選床數
            if (input.AdSearch.bedCount != 0)
            {
                rooms = rooms.Where(room => room.BedCount >= input.AdSearch.bedCount).ToList();
            }
            //篩選衛浴數
            if (input.AdSearch.bathroomCount != 0)
            {
                rooms = rooms.Where(room => room.BathroomCount >= input.AdSearch.bathroomCount).ToList();
            }
            var photosList = _dbRepository.GetAll<RoomImg>().Where(x => rooms.Select(y => y.RoomId).Contains(x.RoomId)).ToList();
            var commentList = _dbRepository.GetAll<Comment>().Where(x => rooms.Select(y => y.RoomId).Contains(x.RoomId)).ToList();
            var roomServiceLabelList = _dbRepository.GetAll<RoomServiceLabel>().Where(x => rooms.Select(y => y.RoomId).Contains(x.RoomId)).ToList();
            
            //找出評價則數,平均星等,房源圖片
            foreach (var room in rooms)
            {
                var comments = commentList.Where(x => x.RoomId == room.RoomId).Select(y => y.CommentId).Count();
                var star = commentList.Where(x => x.RoomId == room.RoomId).Select(y => y.Stars).ToList();
                var staravg = star.Count > 0 ? Math.Round(star.Average(),2) : 0;
                var photos = photosList.Where(x => x.RoomId == room.RoomId).OrderBy(y => y.Sort).Select(z => z.ImageUrl).ToList();
                room.Comments = comments;
                room.Stars = staravg;
                room.RoomImgs = photos;
            }
            //找出房源設備
            foreach (var room in rooms)
            {
                var roomServices = roomServiceLabelList.Where(x => x.RoomId == room.RoomId).Select(y => y.TypeOfLabel).ToList();
                room.RoomServiceLabels = roomServices;
            }
            //篩選設備
            if (input.AdSearch.roomServiceLabels.Any())
            {
                foreach (var room in rooms.ToList())
                {
                    var sameLabels = input.AdSearch.roomServiceLabels.Intersect(room.RoomServiceLabels).ToList();
                    if (sameLabels.Count != input.AdSearch.roomServiceLabels.Count)
                    {
                        rooms.Remove(room);
                    }
                }
            }
            return rooms;
        }

    }
}
