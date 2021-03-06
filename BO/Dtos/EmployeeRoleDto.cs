﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Dtos
{
    public class EmployeeRoleDto
    {
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime DateTime { get; set; }
        public string StartRoleName { get; set; }
        public string EndRoleName { get; set; }
        public int StartRoleId { get; set; }
        public int EndRoleId { get; set; }
    }
}
