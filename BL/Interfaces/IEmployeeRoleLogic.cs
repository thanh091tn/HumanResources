using System;
using System.Collections.Generic;
using System.Text;
using BL.Commons;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface IEmployeeRoleLogic
    {
        BaseResponse<List<EmployeeRoleDto>> GetEmployeeRoles(Guid employeeId, int currentpage, int pagerange);
        BaseResponse<EmployeeRoleDto> GetEmployeeRole(Guid employeeId);
        BaseResponse<bool> InsertOrUpdateEmployeeRole(InsertOrUpdateEmployeeRoleRequest employeerole);
        BaseResponse<bool> DeleteEmployeeRole(Guid id);
    }
}
