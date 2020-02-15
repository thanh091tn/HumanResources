using System.Collections.Generic;

namespace BO.Models
{
    /// <summary>
    /// CourseEntity
    /// </summary>
    public class CourseEntity : BaseEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Level ( caculate by hours)
        /// </summary>
        public double Time { get; set; }
        /// <summary>
        /// IsAvailable
        /// </summary>
        public bool IsAvailable { get; set; }
        /// <summary>
        /// EmployeeCourse
        /// </summary>
        public ICollection<ProgramCourseEntity> ProgramCourse { get; set; }
    }
}
