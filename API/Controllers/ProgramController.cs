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

    public class ProgramController : BaseController
    {

        private readonly IProgramLogic _programLogic;

        public ProgramController(IProgramLogic programLogic )
        {
            _programLogic = programLogic;
        }

        [HttpPost("GetProgramList")]
        public IActionResult GetEmployee(BaseRequest request)
        {
            var employee = _programLogic.GetProgram(request);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost("InsertEmployeeProgram")]
        public IActionResult InsertEmployeeProgram(EmployeeProgramRequest request)
        {
            var result = _programLogic.InsertEmployeeProgram(request);

            if (result == false)
            {
                return NotFound();
            }

            return Ok();
        }
        [HttpPost("UpdateEmployeeProgram")]
        public IActionResult UpdateEmployeeProgram(EmployeeProgramRequest request)
        {
            var result = _programLogic.UpdateEmployeeProgram(request);

            if (result == false)
            {
                return NotFound();
            }

            return Ok();
        }
        [HttpPost("DeleteEmployeeProgram")]
        public IActionResult DeleteEmployeeProgram(EmployeeProgramRequest request)
        {
            var result = _programLogic.UpdateEmployeeProgram(request);

            if (result == false)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}