using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class CategorySkillsController : BaseController
    {
        private readonly ICategoryLogic _categoryLogic;

        public CategorySkillsController(ICategoryLogic categoryLogic)
        {
            _categoryLogic = categoryLogic;
        }
        [HttpGet("{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var result = _categoryLogic.GetCategorySkill(id);

            if (result.Data == null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategorySkill(Guid id)
        {
            var result = _categoryLogic.DeleteCategorySkill(id);

            if (result.Success == false)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}