using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using BO.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmployeeRoleController : BaseController
    {
        private readonly IEmployeeRoleLogic _employeeRoleLogic;

        public EmployeeRoleController(IEmployeeRoleLogic employeeRoleLogic)
        {
            _employeeRoleLogic = employeeRoleLogic;
        }

        [HttpGet("GetEmployeeRole")]
        public IActionResult GetEmployeeRole(Guid id)
        {
            var employee = _employeeRoleLogic.GetEmployeeRole(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }


        [HttpGet("GetEmployeeRoles")]
        public IActionResult GetEmployeeRoles(Guid employeeid)
        {
            var employee = _employeeRoleLogic.GetEmployeeRoles(employeeid);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost("InsertEmployee")]
        public IActionResult InsertEmployeeRole([FromBody]InsertOrUpdateEmployeeRoleRequest request)
        {
            var result = _employeeRoleLogic.InsertOrUpdateEmployeeRole(request);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
        [HttpPost("UpdateEmployee")]
        public IActionResult UpdateEmployeeRole([FromBody]InsertOrUpdateEmployeeRoleRequest request)
        {
            var result = _employeeRoleLogic.InsertOrUpdateEmployeeRole(request);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}