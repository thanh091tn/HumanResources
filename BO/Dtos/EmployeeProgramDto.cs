using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Dtos
{
    public class EmployeeProgramDto
    {
        public Guid Id { get; set; }
        public string ProgramName { get; set; }
        public bool IsPassed { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
