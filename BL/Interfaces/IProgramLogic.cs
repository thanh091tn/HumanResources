using System;
using System.Collections.Generic;
using System.Text;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface IProgramLogic
    {
        List<ProgramDto> GetProgram(BaseRequest request);
        bool InsertEmployeeProgram(EmployeeProgramRequest request);
        bool UpdateEmployeeProgram(EmployeeProgramRequest request);

    }
}
