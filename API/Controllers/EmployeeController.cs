using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using BO.Dtos;
using BO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class EmployeeController : BaseController
    {
        private readonly IEmployeeLogic _employeeLogic;

        public EmployeeController(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }

        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee(Guid employeeid)
        {
            var employee = _employeeLogic.GetEmployee(employeeid);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpGet("DeleteEmployee")]
        public IActionResult DeleteEmployee(Guid employeeid)
        {
            var employee = _employeeLogic.DeleteEmployee(employeeid);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("GetEmployees")]
        public IActionResult GetEmployee([FromBody]SearchEmployeeRequest employeeRequest)
        {
            var employee = _employeeLogic.GetEmployeesWithCondition(employeeRequest);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost("InsertEmployee")]
        public IActionResult InsertEmployee([FromBody]EmployeeDto employee)
        {
            var result = _employeeLogic.InsertEmployee(employee);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
        [HttpPost("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody]UpdateEmployeeRequest employee)
        {
            var result = _employeeLogic.UpdateEmployee(employee);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}