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
    public class SkillsController : BaseController
    {
        private readonly ISkillLogic _skillLogic;

        public SkillsController(ISkillLogic skillLogic)
        {
            _skillLogic = skillLogic;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSkill(int id)
        {
            var result = _skillLogic.DeleteSkills(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult AddSkill(string name)
        {
            var result = _skillLogic.AddSkill(name);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpPost]
        public IActionResult UpdateSkill(int id,string name)
        {
            var result = _skillLogic.UpdateSkill(id,name);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetSkill(int id)
        {
            var result = _skillLogic.GetSkill(id);

            if (result==null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpGet]
        public IActionResult GetSkills(string keyword,int currentpage , int pagerange)
        {
            if (keyword == null)
            {
                keyword = "";
            }
            var result = _skillLogic.GetSkills(keyword,currentpage,pagerange);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

    }
}