using System;
using System.Collections.Generic;
using System.Text;
using BL.Commons;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface IEmployeeLogic
    {
        BaseResponse<EmployeeDto> GetEmployee(Guid employeeid);
        BaseResponse<bool> InsertEmployee(EmployeeDto employee);
        BaseResponse<List<EmployeeDto>> GetEmployeesWithCondition(String keyword, int roleId, int currentpage, int pagerange);
        BaseResponse<bool> UpdateEmployee(UpdateEmployeeRequest request);
        BaseResponse<bool> DeleteEmployee(Guid employeeid);
    }
}
