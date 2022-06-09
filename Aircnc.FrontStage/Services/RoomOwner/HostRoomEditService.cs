using Aircnc.FrontStage.Common;
using Aircnc.FrontStage.Models.DataModels.RoomOwner;
using Aircnc.FrontStage.Models.DataModels.RoomOwner.HostRoomEdit;
using Aircnc.FrontStage.Models.Dtos.RoomOwner;
using Aircnc.FrontStage.Models.Entities;
using AircncFrontStage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Aircnc.FrontStage.Models.Entities.RoomServiceLabel;

namespace Aircnc.FrontStage.Services.RoomOwner
{
    public class HostRoomEditService
    {
        private readonly DBRepository _dBRepository;

        public HostRoomEditService(DBRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }

        public IEnumerable<RoomDto> GetRoomDetail(int roomId)
        {
            var result = _dBRepository.GetAll<Room>().Where(x => x.RoomId == roomId).Select(roomdetail => new RoomDto
            {
                RoomId = roomId,
                RoomName = roomdetail.RoomName,
                RoomDescription = roomdetail.RoomDescription,
                RoomGusetCount = roomdetail.Pax,
                RoomStatus = roomdetail.Status, //房源狀態
                RoomService = string.Join(",", roomdetail.RoomServiceLabels.Where(x => x.RoomId == roomId).Select(x => x.TypeOfLabel.GetDescriptionText())), //房源設備
                Country = roomdetail.Country,
                City = roomdetail.City,
                District = roomdetail.District,
                Street = roomdetail.Street,
                HouseType = roomdetail.HouseType, //房源類型
                RoomType = roomdetail.RoomType, //房間類型
                BedCount = roomdetail.BedCount, //床數
                RoomCount = roomdetail.RoomCount,  //臥室
                BathroomCount = roomdetail.BathroomCount, //衛浴
                UnitPrice = roomdetail.UnitPrice,
                RoomCheckInTime = roomdetail.RoomCheckInTime, //入住時段
                RoomCheckOutTime = roomdetail.RoomCheckOutTime,  //退房時間
                RoomImgs = roomdetail.RoomImgs.Where(x => x.RoomId == roomId).Select(x => new RoomImgDto {
                    ImageUrl = x.ImageUrl,
                    RoomId = x.RoomId,
                    RoomImgId = x.RoomImgId,
                    Sort = x.Sort
                })
            });

            return result;

        }

        public void EditRoomImgById(RoomImgDataModel request)
        {
            var roomDetail = _dBRepository.GetEntityById<RoomImg>(request.RoomImgId);
            roomDetail.Sort = request.Sort;
            _dBRepository.Update<RoomImg>(roomDetail);
            _dBRepository.Save();
        }

        public string EditRoomTitleById(RoomTitleDataModel request)
        {
            var roomDetail = _dBRepository.GetEntityById<Room>(request.RoomId);
            roomDetail.RoomName = request.RoomTitle;
            _dBRepository.Update<Room>(roomDetail);
            _dBRepository.Save();
            return roomDetail.RoomName;
        }

        public string EditRoomDescriptionById(RoomDescriptionDataModel request)
        {
            var roomDetail = _dBRepository.GetEntityById<Room>(request.RoomId);
            roomDetail.RoomDescription = request.RoomDescription;
            _dBRepository.Update<Room>(roomDetail);
            _dBRepository.Save();
            return roomDetail.RoomDescription;
        }


        public int EditRoomGuestCountById(GuestCountDataModel request)
        {
            var roomData = _dBRepository.GetEntityById<Room>(request.RoomId);
            roomData.Pax = request.GuestCount;
            _dBRepository.Update<Room>(roomData);
            try
            {
                _dBRepository.Save();
                return roomData.Pax;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int EditRoomRoomCountById(RoomCountDataModel request)
        {
            var roomData = _dBRepository.GetEntityById<Room>(request.RoomId);
            roomData.RoomCount = request.RoomCount;
            _dBRepository.Update<Room>(roomData);
            try
            {
                _dBRepository.Save();
                return roomData.RoomCount;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int EditRoomBedCountById(BedCountDataModel request)
        {
            var roomData = _dBRepository.GetEntityById<Room>(request.RoomId);
            roomData.BedCount = request.BedCount;
            _dBRepository.Update<Room>(roomData);
            try
            {
                _dBRepository.Save();
                return roomData.BedCount;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int EditRoomBathroomCountById(BathroomCountDataModel request)
        {
            var roomData = _dBRepository.GetEntityById<Room>(request.RoomId);
            roomData.BathroomCount = request.BathroomCount;
            _dBRepository.Update<Room>(roomData);
            try
            {
                _dBRepository.Save();
                return roomData.BathroomCount;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public string EditRoomTypeById(RoomTypeDataModel request)
        {
            var roomData = _dBRepository.GetEntityById<Room>(request.RoomId);
            roomData.HouseType = (HouseTypeEnum)request.HouseType;
            roomData.RoomType = (RoomTypeEnum)request.RoomType;

            _dBRepository.Update<Room>(roomData);
            
            _dBRepository.Save();
            return roomData.HouseType.GetDescriptionText() + '/' + roomData.RoomType.GetDescriptionText();
           
        }

        public string EditRoomStatusById(RoomStatusDataModel request)
        {
            var roomData = _dBRepository.GetEntityById<Room>(request.RoomId);
            roomData.Status = (RoomStatusEnum)request.RoomStatus;

            _dBRepository.Update<Room>(roomData);

            _dBRepository.Save();
            return roomData.Status.GetDescriptionText();

        }

        public string EditRoomServiceById(RoomServiceDataModel request)
        {

            var ogLabels = _dBRepository.GetAll<RoomServiceLabel>().Where(x => x.RoomId == request.RoomId);
            foreach (var ogLabel in ogLabels)
            {
                _dBRepository.Delete<RoomServiceLabel>(ogLabel);
                
            }

            foreach (var label in request.RoomService)
            {
                var result = new RoomServiceLabel()
                {
                    RoomId = request.RoomId,
                    TypeOfLabel = (TypeOfLabelEnum)label
                };
                _dBRepository.Create(result);
            }

            _dBRepository.Save();
            var newTypeOfLabel = ogLabels.Select(l => l.TypeOfLabel.GetDescriptionText()).ToList();
            return string.Join(Environment.NewLine, newTypeOfLabel);
        }
    }
}
