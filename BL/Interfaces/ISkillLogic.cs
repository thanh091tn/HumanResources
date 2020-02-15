using System;
using System.Collections.Generic;
using System.Text;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface ISkillLogic
    {
        bool InsertEmployeeSkill(SkillRequest request);
        List<SkillDto> GetEmployeeSkills(Guid employeeId);
    }
}
