using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class EmployeeAwAndPnRequest
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid AwAndPnId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsRemove { get; set; }
    }
}
