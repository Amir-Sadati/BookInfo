using AutoMapper;
using BookInfo.Application.Interfaces;
using BookInfo.Application.ViewModels;
using BookInfo.Application.ViewModels.UserViewModel;
using BookInfo.Domain.Entities;
using BookInfo.Domain.Entities.Identities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Api.Controllers.AccountApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IJwtTokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IEmailService _emailService;
        private readonly SignInManager<AppUser> _signInManager;
       

        public AccountController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager, 
            IJwtTokenService tokenService, IMapper mapper,RoleManager<AppRole> rolemanager,
            IEmailService emailService)
        {
            _roleManager = rolemanager;
            _emailService = emailService;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserViewModel>> Register(UserViewModel viewmodel)
        {
            if (_userManager.Users.Any(x => x.UserName == viewmodel.Username.ToLower()))
                return BadRequest("این نام کاربری انتخاب شده است");


            var user = _mapper.Map<AppUser>(viewmodel);

            user.UserName = viewmodel.Username.ToLower();
            

            var result = await _userManager.CreateAsync(user, viewmodel.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            if (!_roleManager.Roles.Any(x => x.Name == "member"))
                await _roleManager.CreateAsync(new AppRole { Name = "member" });

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            //We can send email to member for confirm email
            return new UserViewModel
            {
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user),


            };
        }


        [HttpPost("Signin")]
        public async Task<IActionResult> SignIn(UserSignInViewModel viewmodel)
        {
            if (!ModelState.IsValid)
                return BadRequest("خطایی پیش آمده است");
            var user = await _userManager.FindByNameAsync(viewmodel.UserName);
            if (user == null)
                return BadRequest("نام کاربری یا رمز عبور صحیح نمی باشد"); // Security :D
        
          var check= await _signInManager.CheckPasswordSignInAsync(user,viewmodel.Password,false);
            if (check.Succeeded)
                return Ok("oK");
            else if(check.IsLockedOut)
            {
                return BadRequest("حساب کاربری شما قفل شده است");
            }
            else if (check.RequiresTwoFactor)
            {
                return BadRequest("نیاز به احراز هویت 2 مرحله ای است");
            }
            else
                return BadRequest("نام کاربری یا رمز عبور شما صحیح نیست");
        }

       [Authorize(AuthenticationSchemes = 
         JwtBearerDefaults.AuthenticationScheme)] // Need Jwt 
        [HttpPost("EditMember")]
        public async Task<IActionResult> EditMember(UserEditViewModel viewModel)
        {
           
            var user = await _userManager.FindByIdAsync(viewModel.Id.ToString());

            if (user != null)
            {
                var result= await _userManager.UpdateAsync(_mapper.Map(viewModel, user));
                if (result.Succeeded)
                    return Ok("تغییرات با موفقیت انجام شد");
                return BadRequest("خطایی پیش آمده است");
            }
            return BadRequest("خطایی پیش آمده است");
                
           
        }
     

        [HttpPost("SendEmail")]
       [Authorize(AuthenticationSchemes = 
         JwtBearerDefaults.AuthenticationScheme,Policy ="Admin")]
        public async Task<IActionResult> SendEmail(EmailViewModel viewModel)
        {
            foreach(var item in viewModel.EmailAddress)
            {
               await _emailService.SendEmail(item, viewModel.Subject,viewModel.Message);
            }

            return Ok("با موفقیت ارسال شد");
        }
    }
}
