using Aircnc.FrontStage.Models.DataModels.Account;
using Aircnc.FrontStage.Models.Dtos.Account;
using Aircnc.FrontStage.Models.Entities;
using Aircnc.FrontStage.Services.Account.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aircnc.FrontStage.Controllers.Account
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        //public IActionResult Signup()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Signup(SignupDataModel request)
        {
            var inputDto = new CreateAccountInputDto
            {
                Email = request.Email,
                Name = request.Name,
                //Birthday = request.Birthday,
                Password = request.Password,
            };
            var outputDto = _accountService.CreateAccount(inputDto);
            if (outputDto.IsSuccess)
            {
                //先跳回首頁看以後要怎樣
                return  Redirect("/");
            }
            else 
            {
                return new  JsonResult("Sign up Failed");
            }

            
        }
        //public IActionResult AfterSignup(int user)
        //{
            
        //    return View();
        //}
        public IActionResult Verify(int user)
        {
            _accountService.VerifyAccount(user);
            return Redirect("/");
        }

        public IActionResult Logout()
        {
            _accountService.LogoutAccount();
            return Redirect("/");
        }

        [HttpPost]
        public IActionResult FetchLogin([FromBody] LoginDataModel request)
        {

            var inputDto = new LoginAccountInputDto
            {
                Email = request.Email,
                Password = request.Password,
                TypeOfLogin = TypeOfLoginEnum.Aircnc
            };

            var outputDto = _accountService.LoginAccount(inputDto);

            return new JsonResult(outputDto);
        }



        [HttpPost]
        public IActionResult ThirdLogin([FromBody]SignupDataModel request)
        {
            var thirdLoginInfo = new CreateAccountInputDto
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                TypeOfLogin = request.TypeOfLogin
            };
            var account = _accountService.ThirdLogin(thirdLoginInfo);
            return new JsonResult(account);
        }
    }
}
