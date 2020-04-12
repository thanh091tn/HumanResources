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
    public class CategoriesController : BaseController
    {
        private readonly ICategoryLogic _categoryLogic;

        public CategoriesController(ICategoryLogic categoryLogic)
        {
            _categoryLogic = categoryLogic;
        }

        
        [HttpGet]
        public IActionResult GetCategory(string keyword , int currentpage, int pagerange)
        {
            if (keyword == null)
            {
                keyword = "";
            }
            var result = _categoryLogic.GetCategories(keyword,currentpage,pagerange);

            if (result.Success == false)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpPut]
        public IActionResult InsertCategory([FromBody]InsertCategoryRequest request)
        {
            var result = _categoryLogic.InsertCategory(request);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var result = _categoryLogic.DeleteCategory(id);

            if (result.Success == false)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}