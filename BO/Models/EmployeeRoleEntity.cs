using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BO.Models
{
    public class EmployeeRoleEntity : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public int StartRoleId { get; set; }
        public int EndRoleId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsCurrent { get; set; }
        [ForeignKey("EmployeeId")]
        public EmployeeEntity Employee { get; set; }

    }
}
