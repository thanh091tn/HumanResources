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
    public class SkillController : BaseController
    {
        private readonly ISkillLogic _skillLogic;

        public SkillController(ISkillLogic skillLogic)
        {
            _skillLogic = skillLogic;
        }

        [HttpGet("GetEmployeeSkills")]
        public IActionResult GetEmployeeSkills(Guid employeeid)
        {
            var employee = _skillLogic.GetEmployeeSkills(employeeid);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [HttpPost("InsertEmployeeSkill")]
        public IActionResult InsertEmployeeRole([FromBody]SkillRequest request)
        {
            var result = _skillLogic.InsertEmployeeSkill(request);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}