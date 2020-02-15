using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class ProgramCourseEntity : BaseEntity
    {
        public Guid ProgramId { get; set; }
        public Guid CourseId { get; set; }
        /// <summary>
        ///Point
        /// </summary>
        public double Point { get; set; }
        public ProgramEntity Program { get; set; }
        public CourseEntity Course { get; set; }
    }
}
