using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class CreateProgramCourseRequest
    {
        public Guid ProgramId { get; set; }
        public List<Guid> ListCourseId { get; set; }
    }
}
