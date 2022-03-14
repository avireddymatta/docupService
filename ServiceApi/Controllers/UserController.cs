using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceApi.Infrastructure;

namespace ServiceApi.Controllers
{
    public class UserController : BaseApiController
    {
        private IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _unitOfWork.Users.GetAll());
        }
    }
}