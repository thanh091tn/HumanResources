using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class SkillEnitity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CategorySkillEntity>  CategorySkill { get; set; }
        public ICollection<EmployeeSkillEntity> EmployeeSkill{ get; set; }
    }
}
