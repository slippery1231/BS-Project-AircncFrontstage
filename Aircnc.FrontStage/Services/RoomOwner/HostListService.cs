using Aircnc.FrontStage.Common;
using Aircnc.FrontStage.Models.Dtos.RoomOwner;
using Aircnc.FrontStage.Models.Entities;
using AircncFrontStage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Aircnc.FrontStage.Models.Entities.RoomServiceLabel;

namespace Aircnc.FrontStage.Services
{
    public class HostListService
    {
        private readonly DBRepository _DBRepository;
        public HostListService(DBRepository DBRepository)
        {

            _DBRepository = DBRepository;
        }
        public IEnumerable<HostListDto> GetAllRoomByOwnerId(int userid)
        {
            var result = _DBRepository.GetAll<Room>().Where(room => room.UserId == userid).Select(room => new HostListDto
            {
                RoomId = room.RoomId,
                UserId = room.UserId,
                Status = room.Status,
                TypeOfLabel = room.RoomServiceLabels.Where(x => x.RoomId == room.RoomId).Select(x => x.TypeOfLabel).ToList(),
                RoomName = room.RoomName,
                BathroomCount = room.BathroomCount,
                Country = room.Country,
                City = room.City,
                BedCount = room.BedCount,
                RoomCount = room.RoomCount,
                CreateTime = room.CreateTime,
                LastChangeTime = room.LastChangeTime,
                ImageUrl = room.RoomImgs.Where(i => i.Sort == 1).Select(i => i.ImageUrl).First()
            });
            return result;
        }

        public IEnumerable<HostListDto> SearchHostListByOwnerId(HostListSearchDto hostListSearchDto)
        {
            var result = this.GetAllRoomByOwnerId((int)hostListSearchDto.UserId);
            
            if (!string.IsNullOrEmpty(hostListSearchDto.KeyWord))
            {
                result = result.Where(r => r.RoomName.Contains(hostListSearchDto.KeyWord)).ToList();
            }

            if (hostListSearchDto.BedCount > 0)
            {
                result = result.Where(x => x.BedCount == hostListSearchDto.BedCount).ToList();
            }

            if (hostListSearchDto.RoomCount > 0)
            {
                result = result.Where(x => x.RoomCount == hostListSearchDto.RoomCount).ToList();

            }

            if (hostListSearchDto.BathroomCount > 0)
            {
                result = result.Where(x => x.BathroomCount == hostListSearchDto.BathroomCount).ToList();

            }

            if (hostListSearchDto.AllStatus.Count > 0)
            {
                result = result.Where(x => (hostListSearchDto.AllStatus).Contains((int)x.Status)).ToList();
            }

            if (hostListSearchDto.TypeOfLabel?.Count > 0)
            {
                result = result.Where(r =>
                                     (hostListSearchDto.TypeOfLabel).Intersect(r.TypeOfLabel.Select(t => Convert.ToInt32(t)).ToList()).Any()
                                     ).ToList();
            }

            var searchResult = result.Select(x => new HostListDto
            {
                RoomId = x.RoomId,
                UserId = x.UserId,
                Status = x.Status,
                TypeOfLabel = x.TypeOfLabel,
                RoomName = x.RoomName,
                BathroomCount = x.BathroomCount,
                Country = x.Country,
                City = x.City,
                BedCount = x.BedCount,
                RoomCount = x.RoomCount,
                CreateTime = x.CreateTime,
                LastChangeTime = x.LastChangeTime,
                Address = $"{x.Country} {x.City}",
                State = x.Status == RoomStatusEnum.Online ? "上架中" : x.Status == RoomStatusEnum.Unpublish ? "取消發布" : "已下架",
                ImageUrl = x.ImageUrl
            });

            return searchResult;
        }
    }
}
