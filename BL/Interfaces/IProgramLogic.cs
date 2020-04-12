using System;
using System.Collections.Generic;
using System.Text;
using BL.Commons;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface IProgramLogic
    {
        BaseResponse<List<ProgramDto>> GetPrograms(string keyword, int currentpage, int pagerange);
        BaseResponse<bool> InsertEmployeeProgram(EmployeeProgramRequest request);
        BaseResponse<bool> UpdateEmployeeProgram(EmployeeProgramRequest request);
        BaseResponse<List<EmployeeProgramDto>> GetEmployeePrograms(Guid userid, int currentpage, int pagerange);
        BaseResponse<bool> InsertProgram(InsertProgramRequest request);
        BaseResponse<bool> DeleteEmployeeProgram(Guid id);
        BaseResponse<bool> DeleteProgram(Guid id);
        BaseResponse<bool> UpdateProgram(Guid id, string name);
        BaseResponse<ProgramDto> GetProgram(Guid id);
    }
}
