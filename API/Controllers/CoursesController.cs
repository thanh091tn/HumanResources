using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BL.Interfaces;
using BO.Dtos;
using BO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class CoursesController : BaseController
    {
        private readonly ICourseLogic _courseLogic;

        public CoursesController(ICourseLogic courseLogic)
        {
            _courseLogic = courseLogic;
        }

        [HttpGet("{id}")]
        public IActionResult GetCourse(Guid id)
        {
            var result = _courseLogic.GetCourse(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetCourse(string keyword , int currentpage , int pagerange)
        {
            if (keyword == null)
            {
                keyword = "";
            }

            var result = _courseLogic.GetCourses(keyword,currentpage,pagerange);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult InsertCourse([FromBody]CourseRequest course)
        {
            var result = _courseLogic.InsertCourse(course);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpPost]
        public IActionResult UpdateCourse([FromBody]UpdateCourseRequest course)
        {
            var result = _courseLogic.UpdateCourse(course);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(Guid id)
        {
            var result = _courseLogic.DeleteCourse(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}