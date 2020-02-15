using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class InsertOrUpdateEmployeeRoleRequest
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid CreatedById { get; set; }
        public int StartRoleId { get; set; }
        public int EndRoleId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
