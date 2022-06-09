using System.Collections.Generic;

namespace Aircnc.FrontStage.Models.Dtos.RoomOwner
{
    public class HostListSearchDto
    {
        public int? UserId { get; set; }
        public int? BathroomCount { get; set; }
        public int? BedCount { get; set; }
        public int? RoomCount { get; set; }
        public List<int> AllStatus { get; set; }
        public List<int> TypeOfLabel { get; set; }
        public string KeyWord { get; set; }
        public string RoomName { get; set; }
        public string ImageUrl { get; set; }
    }
}
