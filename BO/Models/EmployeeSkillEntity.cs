using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BO.Models
{
    public class EmployeeSkillEntity : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public int skillId  { get; set; }
        public int Level { get; set; }

        [ForeignKey("skillId")]
        public SkillEnitity Skill { get; set; }
        [ForeignKey("EmployeeId")]
        public EmployeeEntity Employee { get; set; }
    }
}
