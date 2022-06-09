using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc.FrontStage.Models.Entities
{
    public class PreOrder
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PreOrderId { get; set; }
        public DateTime BookingDateTime { get; set; } //datetime.utcnow
        public int UserId { get; set; }
        public int RoomId { get; set; }
        [Required]
        public string RoomName { get; set; }
        public DateTime CkeckIn { get; set; }
        public DateTime CkeckOut { get; set; }
        public int GuestCount { get; set; } //要入住的人數
        public decimal OriginalPrice { get; set; }

    }
}
