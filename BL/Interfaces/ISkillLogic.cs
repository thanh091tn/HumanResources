using System;
using System.Collections.Generic;
using System.Text;
using BL.Commons;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface ISkillLogic
    {
        BaseResponse<bool> InsertEmployeeSkill(SkillRequest request);
        BaseResponse<List<SkillDto>> GetEmployeeSkills(Guid employeeId, int currentpage, int pagerange);
        BaseResponse<bool> DeleteSkills(int id);
        BaseResponse<bool> DeleteEmployeeSkills(Guid id);
        BaseResponse<SkillDto> GetSkill(int id);
        BaseResponse<List<SkillDto>> GetSkills(string keyword, int currentpage, int pagerange);
        BaseResponse<bool> AddSkill(string name);
        BaseResponse<bool> UpdateSkill(int id, string name);
    }
}
