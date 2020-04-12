using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using BO.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BO.Models;
using DAL;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{

    public class UsersController : BaseController
    {
        private readonly IUserLogic _userLogic;

        public UsersController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult GetUser([FromBody]UserDetailDto userlogindto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userLogic.Login(userlogindto.UserId, userlogindto.Password);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet("LoginFireBase")]
        public IActionResult GetUser(string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userLogic.LoginFirebase(token);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}