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

    public class EmployeesController : BaseController
    {
        private readonly IEmployeeLogic _employeeLogic;

        public EmployeesController(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
        }

        [HttpGet("{employeeid}")]
        public IActionResult GetEmployee(Guid employeeid)
        {
            var result = _employeeLogic.GetEmployee(employeeid);

            if (result.Data == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpDelete("{employeeid}")]
        public IActionResult DeleteEmployee(Guid employeeid)
        {
            var result = _employeeLogic.DeleteEmployee(employeeid);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpGet()]
        public IActionResult GetEmployee(String keyword, int roleId, int currentpage, int pagerange)
        {
            if (keyword == null)
            {
                keyword = "";
            }
            var result = _employeeLogic.GetEmployeesWithCondition(keyword,roleId,currentpage,pagerange);

            if (result.Data == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult InsertEmployee([FromBody]EmployeeDto employee)
        {
            var result = _employeeLogic.InsertEmployee(employee);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpPost]
        public IActionResult UpdateEmployee([FromBody]UpdateEmployeeRequest employee)
        {
            var result = _employeeLogic.UpdateEmployee(employee);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}