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

    public class EmployeeProgramsController : BaseController
    {
        private readonly IProgramLogic _programLogic;

        public EmployeeProgramsController(IProgramLogic programLogic)
        {
            _programLogic = programLogic;
        }
        [HttpGet("{userid}")]
        public IActionResult GetEmployeeProgram(Guid userid, int currentpage, int pagerange)
        {
            if (userid == null)
            {
                userid = new Guid();
            }
            var employee = _programLogic.GetEmployeePrograms(userid, currentpage, pagerange);

            if (employee.Success == false)
            {
                return NotFound(employee);
            }

            return Ok(employee);
        }

        [HttpPut]
        public IActionResult InsertEmployeeProgram(EmployeeProgramRequest request)
        {
            var result = _programLogic.InsertEmployeeProgram(request);

            if (result.Success == false)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpPost]
        public IActionResult UpdateEmployeeProgram(EmployeeProgramRequest request)
        {
            var result = _programLogic.UpdateEmployeeProgram(request);

            if (result.Success == false)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpDelete]
        public IActionResult DeleteEmployeeProgram(Guid employeeProgramId)
        {
            var result = _programLogic.DeleteEmployeeProgram(employeeProgramId);

            if (result.Success == false)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}