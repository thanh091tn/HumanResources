using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO.Models
{
    /// <summary>
    /// EmployeeEntity
    /// </summary>
    public class EmployeeEntity : BaseEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// IdentificationNumber
        /// </summary>
        public string IdentificationNumber { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gender
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// HouseholdAddress
        /// </summary>
        public string HouseholdAddress { get; set; }

        /// <summary>
        /// CityId
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///GraduatedAt
        /// </summary>
        public string GraduatedAt { get; set; }

        /// <summary>
        /// NativeLand
        /// </summary>
        public string NativeLand { get; set; }

        /// <summary>
        /// StartedDate
        /// </summary>
        public DateTime StartedDate { get; set; }

        /// <summary>
        /// EndedDate
        /// </summary>
        public DateTime? EndedDate { get; set; }

        /// <summary>
        /// Education
        /// </summary>
        public string Education { get; set; }

        /// <summary>
        ///Position
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        [ForeignKey("RoleId")]
        public RoleEntity Role { get; set; }


        /// <summary>
        /// EmployeeCourse
        /// </summary>
        public ICollection<EmployeeProgramEntity> EmployeeCourse { get; set; }

        /// <summary>
        /// StoreEmployee
        /// </summary>
        public ICollection<StoreEmployeeEntity> StoreEmployee { get; set; }

        public ICollection<AwAndPnEmployeeEntity> AwAndPnEmployee { get; set; }
    }
}
