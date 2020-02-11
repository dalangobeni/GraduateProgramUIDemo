using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Models.AccountViewModels;
using Backend.Models.ManageViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace SimpleNotes.Api.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginViewModel model) {
           var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
          
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                TokenClaimHandler(user, out JwtSecurityTokenHandler tokenHandler, out SecurityToken token);
                var userModel = new
                {
                    user.Id,
                    user.UserName,
                    user.Email
                };

                return Ok(new
                {
                    userToken = tokenHandler.WriteToken(token),
                    userInfo = userModel
                });
            }
            return Unauthorized();
        }

        private void TokenClaimHandler(ApplicationUser userFromRepo, out JwtSecurityTokenHandler tokenHandler, out SecurityToken token)
        {
            var claims = new[]
                           {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id),
                new Claim(ClaimTypes.Name, ($"{userFromRepo.UserName}"))
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("630A453A-CDD2-4AF9-8028-133FC4CC6A6E75D5E7E8-9E3E-464A-8A74-982F5854D1A8"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            tokenHandler = new JwtSecurityTokenHandler();
            token = tokenHandler.CreateToken(tokenDescriptor);
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<ActionResult> Logout() {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterViewModel model) {
            if (await _userManager.FindByNameAsync(model.Email) != null) {
                ModelState.AddModelError(nameof(model.Email), $"A user named '{model.Email}' already exists");
                return BadRequest(ModelState);
            }

            ApplicationUser applicationUser = new ApplicationUser { UserName = model.Email };
            var result = await _userManager.CreateAsync(applicationUser, model.Password);
            if (!result.Succeeded) {
                foreach (var error in result.Errors) {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }
            
            // Get user key from password
            applicationUser = await _userManager.FindByNameAsync(model.Email);
            await _userManager.UpdateAsync(applicationUser);
            return Ok();
        }

        [HttpPut]
        [Route("Password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model) {
            var applicationUser = await  _userManager.GetUserAsync(User);
            var result = await _userManager.ChangePasswordAsync(applicationUser, model.ConfirmPassword, model.NewPassword);
            if (!result.Succeeded) {
                foreach (var error in result.Errors) {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Authenticated")]
        public bool IsAuthenticated() {
            return User.Identity.IsAuthenticated;
        }
    }
}

