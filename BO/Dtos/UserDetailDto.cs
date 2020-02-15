using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Dtos
{
    public class UserDetailDto
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }

        public string Password { get; set; }


    }
}
