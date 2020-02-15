using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class CategorySkillEntity : BaseEntity
    {
        public int SkillId { get; set; }
        public Guid CategoryId { get; set; }
        public SkillEnitity Skill { get; set; }
        public CategoryEntity Category { get; set; }
    }
}
