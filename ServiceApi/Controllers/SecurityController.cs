using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceApi.Infrastructure;
using ServiceApi.services;

namespace ServiceApi.Controllers
{
    [AllowAnonymous]
    public class SecurityController : BaseApiController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly TokenService tokenService;

        public SecurityController(UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetData()
        {
            return new UserDTO()
            {
                Email = "Random",
                Token = "ASDS",
                UserName = "FK"
            };
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] LoginDTO loginDetails)
        {
            var user = await this.userManager.FindByEmailAsync(loginDetails.Email);

            if (user == null) return NotFound();

            var authentication = await this.signInManager.CheckPasswordSignInAsync(user, loginDetails.Password, false);

            if (!authentication.Succeeded)
            {
                return Unauthorized();
            }
            else
            {
                return new UserDTO()
                {
                    Email = user.Email,
                    Token = this.tokenService.CreateToken(user),
                    UserName = user.UserName
                };
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(UserRegisterDTO register)
        {
            var emailUser = await this.userManager.FindByEmailAsync(register.Email);

            if (emailUser != null) return BadRequest("Email Already Exists");

            var nameUser = await this.userManager.FindByNameAsync(register.UserName);

            if (nameUser != null) return BadRequest("UserName already Exists");

            var userApp = new User
            {
                UserName = register.UserName,
                Email = register.Email,
            };

            var registration = await userManager.CreateAsync(userApp, register.Password);

            if (registration.Succeeded)
            {
                return CreateUserObject(userApp);
            }

            return BadRequest();
        }

        [Authorize]
        [HttpGet("GetCurrentUser/{email}")]
        public async Task<ActionResult<UserDTO>> GetCurrentUser(string Email)
        {
            //var user = await this.userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            var user = await this.userManager.FindByEmailAsync(Email);
            return CreateUserObject(user);
        }

        private UserDTO CreateUserObject(User user)
        {
            return new UserDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }
    }
}