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

    public class CourseController : BaseController
    {
        private readonly ICourseLogic _courseLogic;

        public CourseController(ICourseLogic courseLogic)
        {
            _courseLogic = courseLogic;
        }

        [HttpGet("GetCourse")]
        public IActionResult GetCourse(Guid Courseid)
        {
            var Course = _courseLogic.GetCourse(Courseid);

            if (Course == null)
            {
                return NotFound();
            }

            return Ok(Course);
        }



        [HttpPost("GetCourses")]
        public IActionResult GetCourse([FromBody]BaseRequest courseRequest)
        {
            var Course = _courseLogic.GetCourses(courseRequest);

            if (Course == null)
            {
                return NotFound();
            }

            return Ok(Course);
        }

        [HttpPost("InsertCourse")]
        public IActionResult InsertCourse([FromBody]CourseRequest course)
        {
            var result = _courseLogic.InsertCourse(course);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
        [HttpPost("UpdateCourse")]
        public IActionResult InsertCourse([FromBody]UpdateCourseRequest course)
        {
            var result = _courseLogic.UpdateCourse(course);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}