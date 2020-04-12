using System;
using System.Collections.Generic;
using System.Text;
using BO.Dtos;
using BO.Models;

namespace BO.Request
{
    public class SkillRequest
    {
        public Guid EmployeeId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SkillDto> Skill { get; set; }
    }
}
