using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class EmployeeProgramRequest
    {
        public Guid ProgramId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid EmployeeProgramId { get; set; }
    }
}
