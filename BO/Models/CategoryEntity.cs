using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<CategorySkillEntity> CategorySkill { get; set; }
    }
}
