using Aircnc.FrontStage.Common;
using Aircnc.FrontStage.Models.Dtos.Account;
using Aircnc.FrontStage.Models.Entities;
using Aircnc.FrontStage.Services.Account.Interface;
using Aircnc.FrontStage.Services.Common;
using AircncFrontStage.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Aircnc.FrontStage.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly DBRepository _dBRepository;
        private readonly MailService _mailService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(DBRepository dBRepository, MailService mailService, IHttpContextAccessor httpContextAccessor)
        {
            _dBRepository = dBRepository;
            _mailService = mailService;
            _httpContextAccessor = httpContextAccessor;
        }

        public CreateAccountOutputDto CreateAccount(CreateAccountInputDto input)
        {
            var result = new CreateAccountOutputDto();
            result.IsSuccess = false;
            result.User.Name = input.Name;
            result.User.Email = input.Email;
            

            //判斷資料庫中是否有這個email
            if (IsExistAccount(input.Email))
            {
                result.Message = "該Email已經被註冊";
                return result;
            }
            if (String.IsNullOrEmpty(input.Name))
            {
                result.Message = "名字不能空白";
                return result;
            }
            if (String.IsNullOrEmpty(input.Email))
            {
                result.Message = "Email不能空白";
                return result;
            }
            if (input.Password.Length < 8)
            {
                result.Message = "密碼需要至少8個字元";
                return result;
            }
            //做成entity
            var user = new User
            {
                Email = input.Email,
                Name = input.Name,
                Gender = false,
                Password = input.Password.SHA256Encrypt(),
                CreateTime = DateTime.Now,
                MailIsVerify = false,
                Phone = "",
                IsDelete = false,
                TypeOfLogin = input.TypeOfLogin

                //Birthday = DateTime.Now

            };
            _dBRepository.Create(user);
            _dBRepository.Save();
            //mail驗證信發出去
            _mailService.SendVerifyMail(user.Email, user.UserId);

            result.IsSuccess = true;
            result.User.UserId = user.UserId;
            return result;

        }

        public bool IsExistAccount(string email)
        {
            return _dBRepository.GetAll<User>().Any(user => user.Email == email);
        }

        public LoginAccountOutputDto LoginAccount(LoginAccountInputDto input)
        {
            var result = new LoginAccountOutputDto();
            result.IsSuccess = false;

            var target = _dBRepository.GetAll<User>().FirstOrDefault(x => x.Email == input.Email);

            if (!this.IsExistAccount(input.Email))
            {
                result.Message = "此帳號不存在";
                return result;
            }

            if (target.IsDelete == true)
            {
                result.Message = "該帳號已被停權，請洽管理員";
                return result;
            }



            var currentUser = _dBRepository.GetAll<User>().First(x => x.Email == input.Email);
            if (!currentUser.MailIsVerify)
            {
                result.Message = "此帳號尚未驗證";
                return result;
            }
        
            if (input.TypeOfLogin == TypeOfLoginEnum.Aircnc && input.Password.SHA256Encrypt() != currentUser.Password)
            {
                result.Message = "密碼錯誤";
                return result;
            }
            else
            {
                input.Password = currentUser.Password;
            }
            result.IsSuccess = true;
            result.User.UserId = currentUser.UserId;
            result.User.Name = currentUser.Name;
            result.User.Email = currentUser.Email;
            //如果使用者照片為null 使用預設值

            result.User.Photo = currentUser.Photo ?? "https://i.imgur.com/Vt0a9O2.png";

            if(input.TypeOfLogin == TypeOfLoginEnum.Aircnc)
            {
                result.User.TypeOfLogin = 1;
            }
            else if(input.TypeOfLogin == TypeOfLoginEnum.Google)
            {
                result.User.TypeOfLogin = 2;
            }


            if (result.IsSuccess)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, result.User.UserId.ToString()),
                    new Claim(ClaimTypes.Email, result.User.Email),
                    new Claim("UserName", result.User.Name),//自訂欄位(聲明)
                    new Claim("UserPhoto", result.User.Photo),
                    new Claim("UserLoginType", result.User.TypeOfLogin.ToString())
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                _httpContextAccessor.HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
            }

            return result;
        }

        public void LogoutAccount()
        {
            _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public void VerifyAccount(int userId)
        {
            var user = _dBRepository.GetAll<User>().First(x => x.UserId == userId);

            if (!user.MailIsVerify)
            {
                user.MailIsVerify = true;
                _dBRepository.Update<User>(user);
                _dBRepository.Save();
            }
        }

        public LoginAccountOutputDto ThirdLogin(CreateAccountInputDto input)
        {

            var accountInfo = CreateAccount(input);
            var loginInput = new LoginAccountInputDto()
            {
                Email = input.Email,
                Password = input.Password,
                TypeOfLogin = input.TypeOfLogin
            };

            if (this.IsExistAccount(loginInput.Email))
            {
                var currentUser = _dBRepository.GetAll<User>().First(x => x.Email == input.Email);
                loginInput.Password = currentUser.Password;
                loginInput.Email = currentUser.Email;

            }
            if (string.IsNullOrEmpty(accountInfo.Message))
            {
                VerifyAccount(accountInfo.User.UserId);
            }
            var result = LoginAccount(loginInput);

            return result;
        }
    }
}
