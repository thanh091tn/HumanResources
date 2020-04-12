using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BO.Models
{
    public class ProgramCourseEntity : BaseEntity
    {
        public Guid ProgramId { get; set; }
        public Guid CourseId { get; set; }
        [ForeignKey("ProgramId")]
        public ProgramEntity Program { get; set; }
        [ForeignKey("CourseId")]
        public CourseEntity Course { get; set; }
    }
}
