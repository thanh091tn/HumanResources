using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Dtos
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public Guid EmployeeSkillId { get; set; }

    }
}
