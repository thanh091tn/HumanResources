using System;
using System.Collections.Generic;
using System.Text;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface IEmployeeLogic
    {
        EmployeeDto GetEmployee(Guid employeeid);
        bool InsertEmployee(EmployeeDto employee);
        List<EmployeeDto> GetEmployeesWithCondition(SearchEmployeeRequest request);
        EmployeeDto DeleteEmployee(Guid employeeid);
        bool UpdateEmployee(UpdateEmployeeRequest request);
    }
}
