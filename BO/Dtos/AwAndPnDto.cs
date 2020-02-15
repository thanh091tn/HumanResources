using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Dtos
{
    public class AwAndPnDto
    {
        public Guid EmployeeId { get; set; }
        public Guid AwAndPnId { get; set; }
        public DateTime DateTime { get; set; }
        public string EmployeeName { get; set; }
        public string AwAndPnName { get; set; }
    }
}
