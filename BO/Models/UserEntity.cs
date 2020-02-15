using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO.Models
{
    public class UserEntity 
    {
        /// <summary>
        ///UserId
        /// </summary>
        [Key]
        public string UserId { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// RoleId
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// UserRole
        /// </summary>
        [ForeignKey("RoleId")]
        public UserRoleEntity UserRole { get; set; }
    }
}
