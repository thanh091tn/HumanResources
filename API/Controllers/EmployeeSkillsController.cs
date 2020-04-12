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
    
    public class EmployeeSkillsController : BaseController
    {
        private readonly ISkillLogic _skillLogic;

        public EmployeeSkillsController(ISkillLogic skillLogic)
        {
            _skillLogic = skillLogic;
        }

        [HttpGet]
        public IActionResult GetEmployeeSkills(Guid employeeid, int currentpage, int pagerange)
        {
            if (employeeid == null)
            {
                employeeid = new Guid();
            }
            var employee = _skillLogic.GetEmployeeSkills(employeeid,currentpage,pagerange);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [HttpPut]
        public IActionResult InsertEmployeeSkill([FromBody]SkillRequest request)
        {
            var result = _skillLogic.InsertEmployeeSkill(request);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpPost]
        public IActionResult UpdateEmployeeSkill([FromBody]SkillRequest request)
        {
            var result = _skillLogic.InsertEmployeeSkill(request);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeSkill(Guid id)
        {
            var result = _skillLogic.DeleteEmployeeSkills(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}