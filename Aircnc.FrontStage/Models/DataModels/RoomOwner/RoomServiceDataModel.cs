using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc.FrontStage.Models.DataModels.RoomOwner
{
    public class RoomServiceDataModel
    {
        public int RoomId { get; set; }
        public IEnumerable<int> RoomService { get; set; }
    }
}
