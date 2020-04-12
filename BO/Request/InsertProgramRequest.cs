using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class InsertProgramRequest
    {
        public string Name { get; set; }
        public List<Guid> Courses { get; set; }
    }
}
