using System;
using System.Collections.Generic;
using System.Text;
using BO.Dtos;

namespace BO.Request
{
    public class UpdateEmployeeRequest
    {
        public Guid EmployeeId { get; set; }
        public EmployeeDto EmployeeInfo { get; set; }
    }
}
