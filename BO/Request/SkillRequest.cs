using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class SkillRequest
    {
        public Guid EmployeeId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int SkillId { get; set; }
        public int Level { get; set; }
    }
}
