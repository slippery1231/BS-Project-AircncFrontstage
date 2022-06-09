using Aircnc.FrontStage.Models.DataModels;
using Aircnc.FrontStage.Models.DataModels.Account.Personal;
using Aircnc.FrontStage.Models.Entities;
using Aircnc.FrontStage.Models.ViewModels.Member;
using AircncFrontStage.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc.FrontStage.Controllers
{
    public class MemberController : Controller
    {
        private readonly DBRepository _dBRepository;

        public MemberController(DBRepository dBRepository)
        {
            _dBRepository = dBRepository;
        }

        [Authorize]
        public IActionResult Upload_Identification()
        {
            return View();
        }

        [Authorize]
        public IActionResult Upload_ID_Photo()
        {
            return View();
        }

        //[HttpPost]
        //[Authorize]
        //public IActionResult SendUrlToDatabase([FromBody] SendUrlDataModel request)
        //{
        //  var userid = int.Parse(User.Identity.Name);
        //  var select_userverification_in_user = _dBRepository.GetEntityById<User>(userid).UserVerificationId;
        //  var select_photoId_in_userverification = _dBRepository.GetEntityById<UserVerification>(select_userverification_in_user);
        //  select_photoId_in_userverification.IdPhoto = request.IdPhoto;
        //  _dBRepository.Update<UserVerification>(select_photoId_in_userverification);
        //  _dBRepository.Save();
        //  var user = _dBRepository.GetEntityById<User>(userid);
        //  user.UserVerificationId = select_photoId_in_userverification.UserVerificationId;
        //  _dBRepository.Update(user);
        //  return Ok();
        //}
        [HttpPost]
        public void CreateUserVerification([FromBody]UploadIdPhotoDataModel request)
        {
            var userid = int.Parse(User.Identity.Name);
            using (var transaction = _dBRepository._DbContext.Database.BeginTransaction())
            {
                try
                {
                    var result = new UserVerification
                    {
                        DocumentType = (DocumentTypeEnum)1,
                        Status = (VerifyStatusEnum)2,
                        ApplyTime = DateTime.UtcNow.AddHours(8),
                        //need to change
                        AdminId = 1,
                        IdPhoto = request.IdPhoto
                    };
                    _dBRepository.Create(result);
                    _dBRepository.Save();
                    var userTarget = _dBRepository.GetEntityById<User>(userid);
                    userTarget.UserVerificationId = result.UserVerificationId;
                    _dBRepository.Update(userTarget);
                    _dBRepository.Save();


                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                }

            }
            
}


        [Authorize]
        public IActionResult Select_IdentificationType()
        {
            return View();
        }


            }
        }
