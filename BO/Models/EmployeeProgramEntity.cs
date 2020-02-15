using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO.Models
{
    public class EmployeeProgramEntity :BaseEntity
    {
        /// <summary>
        /// EmployeeId
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// CourseId
        /// </summary>
        public Guid ProgramId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsRemove { get; set; }
        /// <summary>
        /// IsPassed
        /// </summary>
        public bool IsPassed { get; set; }
        /// <summary>
        ///Employee
        /// </summary>
        [ForeignKey("EmployeeId")]
        public EmployeeEntity Employee { get; set; }
        /// <summary>
        /// Course
        /// </summary>
        [ForeignKey("ProgramId")]
        public ProgramEntity Program { get; set; }
    }
}
