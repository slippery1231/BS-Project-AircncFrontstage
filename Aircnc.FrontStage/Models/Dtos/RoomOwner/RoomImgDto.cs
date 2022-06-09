using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc.FrontStage.Models.Dtos.RoomOwner
{
    public class RoomImgDto
    {
        public int RoomImgId { get; set; }
        public int RoomId { get; set; }
        public string ImageUrl { get; set; }
        public int Sort { get; set; }
    }
    
}
