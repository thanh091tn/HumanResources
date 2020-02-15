using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BO.Models
{
    public class AwAndPnEmployeeEntity : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid AwAndPnId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsRemove { get; set; }
        
        [ForeignKey("EmployeeId")]
        public EmployeeEntity EmployeeEntity { get; set; }
        [ForeignKey("AwAndPnId")]
        public AwAndPnEntity AwAndPnEntity { get; set; }
    }
}
