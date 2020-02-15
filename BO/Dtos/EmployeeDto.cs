using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Dtos
{
    public class EmployeeDto
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
        public int CityId { get; set; }

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
        public DateTime EndedDate { get; set; }

        /// <summary>
        /// Education
        /// </summary>
        public string Education { get; set; }

        /// <summary>
        ///Position
        /// </summary>
        public string RoleName { get; set; }

        public int RoleId { get; set; }
    }
}
