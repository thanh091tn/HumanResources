using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class ProgramEntity : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProgramCourseEntity> ProgramCourse { get; set; }
    }
}
