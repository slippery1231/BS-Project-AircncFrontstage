﻿using Aircnc.FrontStage.Models.ViewModels.Guest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Aircnc.FrontStage.Models.Entities.RoomServiceLabel;

namespace Aircnc.FrontStage.Models.ViewModels.Guest
{
    public class SearchVM
    {
        public IEnumerable<SearchRoomViewModel> SearchRoom { get; set; }
        public AdvancedSearchVM AdSearch { get; set; }
        public NavSearchVMPost NavSearch { get; set; }
        public RoomDetailViewModel RoomDetailVM { get; set; }
        public RoomDetailPostVM roomDetailPost { get; set; }
    }

    public class GetAdQuery
	{
        public string AdQuery { get; set; }
	}
}
