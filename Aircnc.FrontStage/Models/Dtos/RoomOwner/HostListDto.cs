﻿using Aircnc.FrontStage.Models.Entities;
using System;
using System.Collections.Generic;
using static Aircnc.FrontStage.Models.Entities.RoomServiceLabel;

namespace Aircnc.FrontStage.Models.Dtos.RoomOwner
{
    public class HostListDto
    {
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public string RoomName { get; set; }
        public int BathroomCount { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public RoomStatusEnum Status { get; set; }
        public List<TypeOfLabelEnum> TypeOfLabel { get; set; }
        public string State { get; set; }
        public int BedCount { get; set; }
        public int RoomCount { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? LastChangeTime { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
    }
}
