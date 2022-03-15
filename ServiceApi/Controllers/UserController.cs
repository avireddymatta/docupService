using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceApi.Infrastructure;
using AutoMapper;
using Application.DTO;

namespace ServiceApi.Controllers
{
    public class UserController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [AllowAnonymous]
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(_unitOfWork.mapper.Map<UserDetailsDTO[]>(await _unitOfWork.Users.GetAll()));
        }
    }
}