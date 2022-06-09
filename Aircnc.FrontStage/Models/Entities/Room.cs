﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Aircnc.FrontStage.Models.Entities
{
    public partial class Room
    {
        public Room()
        {
            Comments = new HashSet<Comment>();
            Orders = new HashSet<Order>();
            RoomCalendars = new HashSet<RoomCalendar>();
            RoomImgs = new HashSet<RoomImg>();
            RoomServiceLabels = new HashSet<RoomServiceLabel>();
            WishLists = new HashSet<WishList>();
        }

        [Key]
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public HouseTypeEnum HouseType { get; set; }
        public RoomTypeEnum RoomType { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Pax { get; set; }
        public int BedCount { get; set; }
        public int RoomCount { get; set; }
        public int BathroomCount { get; set; }
        public string RoomDescription { get; set; }
        public string RoomName { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? LastChangeTime { get; set; }
        public string RoomCheckInTime { get; set; }
        public string RoomCheckOutTime { get; set; }
        //lat緯度
        [Required]
        [Column(TypeName = "decimal(10, 6)")]
        public decimal Lat { get; set; }
        //lng 經度
        [Required]
        [Column(TypeName = "decimal(10, 6)")]
        public decimal Lng { get; set; }
        public RoomStatusEnum Status { get; set; }
        [ StringLength(500)]
        public string Note { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<RoomCalendar> RoomCalendars { get; set; }
        public virtual ICollection<RoomImg> RoomImgs { get; set; }
        public virtual ICollection<RoomServiceLabel> RoomServiceLabels { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }

    public enum RoomStatusEnum
    {
        //1已上架 2已下架 3建立中 4取消發布
        [Display(Name = "已上架")]
        [Description("已上架")]
        Online = 1,
        [Display(Name = "已下架")]
        [Description("已下架")]
        Offline = 2,
        [Display(Name = "建立中")]
        [Description("建立中")]
        Pending = 3,
        [Display(Name = "取消發布")]
        [Description("取消發布")]
        Unpublish = 4
    }

    public enum HouseTypeEnum
    {
        //1公寓 2獨棟房屋 3獨特房源 4家庭式旅館 
        [Display(Name = "公寓")]
        [Description("公寓")]
        Apartment = 1 ,
        [Display(Name = "獨棟房屋")]
        [Description("獨棟房屋")]
        OneBuild = 2,
        [Display(Name = "獨特房源")]
        [Description("獨特房源")]
        Special = 3,
        [Display(Name = "家庭式旅館")]
        [Description("家庭式旅館")]
        Family = 4
    }
    
    public enum RoomTypeEnum
    {
        //1 整套房源 2獨立房間 3 合住房間
        [Display(Name = "整套房源")]
        [Description("整套房源")]
        FullHouse =1,
        [Display(Name = "獨立房間")]
        [Description("獨立房間")]
        Solo =2 ,
        [Display(Name = "合住房間")]
        [Description("合住房間")]
        Share =3
        
    }
}
