using Aircnc.FrontStage.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc.FrontStage.Models.DataModels.Account.Personal
{
    public class SendUrlDataModel
    {
        public string IdPhoto { get; set; }
        public string Photo { get; set; }
        public int UserVerificationId { get; set; }
        public DocumentTypeEnum DocumentType { get; set; }
        public VerifyStatusEnum Status { get; set; }
        public DateTime ApplyTime { get; set; }
        public DateTime? CertificationTime { get; set; }
        public int AdminId { get; set; }

    }
}
