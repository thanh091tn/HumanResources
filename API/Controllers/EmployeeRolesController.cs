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
    public class EmployeeRolesController : BaseController
    {
        private readonly IEmployeeRoleLogic _employeeRoleLogic;

        public EmployeeRolesController(IEmployeeRoleLogic employeeRoleLogic)
        {
            _employeeRoleLogic = employeeRoleLogic;
        }



        [HttpGet]
        public IActionResult GetEmployeeRoles(Guid employeeid, int currentpage, int pagerange)
        {
            if (employeeid == null)
            {
                employeeid = new Guid();
            }
            var result = _employeeRoleLogic.GetEmployeeRoles(employeeid,currentpage,pagerange);

            if (result.Data == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult InsertEmployeeRole([FromBody]InsertOrUpdateEmployeeRoleRequest request)
        {
            var result = _employeeRoleLogic.InsertOrUpdateEmployeeRole(request);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpPost]
        public IActionResult UpdateEmployeeRole([FromBody]InsertOrUpdateEmployeeRoleRequest request)
        {
            var result = _employeeRoleLogic.InsertOrUpdateEmployeeRole(request);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeRole(Guid id)
        {
            var result = _employeeRoleLogic.DeleteEmployeeRole(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}