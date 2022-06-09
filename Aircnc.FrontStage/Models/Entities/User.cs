﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Aircnc.FrontStage.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            MessageRecipients = new HashSet<Message>();
            MessageSenders = new HashSet<Message>();
            Orders = new HashSet<Order>();
            Rooms = new HashSet<Room>();
            TransactionStatuses = new HashSet<TransactionStatus>();
            WishLists = new HashSet<WishList>();
        }


        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public DateTime? Birthday { get; set; }
        public bool? Gender { get; set; }
        public string Photo { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhone { get; set; }
        public DateTime CreateTime { get; set; }
        public int? UserVerificationId { get; set; }
        public int? BankVerificationId { get; set; }
        public bool? IsDelete { get; set; }

        public bool MailIsVerify { get; set; }
        public TypeOfLoginEnum TypeOfLogin { get; set; }

        public virtual BankVerification BankVerification { get; set; }
        public virtual UserVerification UserVerification { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Message> MessageRecipients { get; set; }
        public virtual ICollection<Message> MessageSenders { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<TransactionStatus> TransactionStatuses { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
    }

    public enum TypeOfLoginEnum
    {
        Aircnc = 1,
        Google = 2,
        FB = 3,
        Line = 4
    }
}
