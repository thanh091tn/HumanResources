using System;
using System.Collections.Generic;
using System.Text;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface IEmployeeRoleLogic
    {
        List<EmployeeRoleDto> GetEmployeeRoles(Guid employeeId);
        EmployeeRoleDto GetEmployeeRole(Guid employeeId);
        bool InsertOrUpdateEmployeeRole(InsertOrUpdateEmployeeRoleRequest employeerole);
    }
}
