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
    public class CategoryController : BaseController
    {
        private readonly ICategoryLogic _categoryLogic;

        public CategoryController(ICategoryLogic categoryLogic)
        {
            _categoryLogic = categoryLogic;
        }

        [HttpGet("GetCategorySkill")]
        public IActionResult GetEmployee(Guid categoryId)
        {
            var employee = _categoryLogic.GetCategorySkill(categoryId);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [HttpPost("GetCategories")]
        public IActionResult GetEmployee([FromBody]BaseRequest request)
        {
            var employee = _categoryLogic.GetCategories(request);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        [HttpPost("InsertCategory")]
        public IActionResult InsertEmployee([FromBody]InsertCategoryRequest request)
        {
            var result = _categoryLogic.InsertCategory(request);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}