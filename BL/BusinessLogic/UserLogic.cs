using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BL.Commons;
using BL.Helpers;
using BL.Interfaces;
using BO.Dtos;
using BO.Models;
using DAL.Repository.UnitOfWorks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BL.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly UserHelper _userHelper;

        private readonly IUnitOfWork _uow;
        private readonly AppSettings _appSettings;


        public UserLogic(IOptions<AppSettings> appSettings, UserHelper userHelper, IUnitOfWork uow)
        {

            _userHelper = userHelper;

            _uow = uow;
            _appSettings = appSettings.Value;
        }

        //business logic Login
        public UserDetailDto Login(string userid, string password)
        {


            var User = _uow.GetRepository<UserEntity>().GetAll()
                .FirstOrDefault(user => user.UserId == userid && user.Password == password);

            if (User == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, User.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new UserDetailDto
            {
                UserName = User.UserName,
                Token = tokenString,
                UserId = User.UserId
            };
        }


        public UserDetailDto LoginFirebase(string token)
        {
            var stream = token;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = handler.ReadToken(stream) as JwtSecurityToken;

            var userid = tokenS.Claims.First(claim => claim.Type == "sub").Value;
            var name = tokenS.Claims.First(claim => claim.Type == "name").Value;
            var email = tokenS.Claims.First(claim => claim.Type == "email").Value;
            var temp = _uow.GetRepository<UserEntity>().GetAll().FirstOrDefault(c => c.UserId.Equals(userid));
            if (temp == null)
            {
                _uow.GetRepository<UserEntity>().Insert(new UserEntity
                {
                    UserId = userid,
                    Password = "password",
                    RoleId = 1,
                    Email = email,
                    UserName = name
                });
                _uow.SaveChange();
            }

            return Login(userid, "password");
        }
    }
}
