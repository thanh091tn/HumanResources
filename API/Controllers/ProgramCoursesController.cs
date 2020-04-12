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

    public class ProgramCoursesController : BaseController
    {
        private readonly IProgramCourseLogic _programCourseLogic;

        public ProgramCoursesController(IProgramCourseLogic courseLogic)
        {
            _programCourseLogic = courseLogic;
        }
        [HttpGet]
        public IActionResult GetProgramCourses(Guid programId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _programCourseLogic.GetProgramCourse(programId);

            if (result.Success == false)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        [HttpPost]
        public IActionResult GetProgramCourses(CreateProgramCourseRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _programCourseLogic.UpdateProgramCourse(request);

            if (result.Success == false)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}