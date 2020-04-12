using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.Interfaces;
using BO.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ProgramsController : BaseController
    {

        private readonly IProgramLogic _programLogic;

        public ProgramsController(IProgramLogic programLogic )
        {
            _programLogic = programLogic;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetPrograms(string keyword, int currentpage, int pagerange)
        {
            if (keyword == null)
            {
                keyword = "";
            }
            var program = _programLogic.GetPrograms(keyword,currentpage,pagerange);

            if (program.Data.Count == 0)
            {
                return NotFound(program);
            }

            return Ok(program);
        }

        [HttpGet("{id}")]
        public IActionResult GetProgram(Guid id)
        {
            var program = _programLogic.GetProgram(id);

            if (!program.Success)
            {
                return NotFound(program);
            }

            return Ok(program);
        }


        [HttpPost("{id}")]
        public IActionResult UpdateProgram(Guid id , string name)
        {
            var result = _programLogic.UpdateProgram(id,name);

            if (result.Success == false)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        

        [HttpDelete("{id}")]
        public IActionResult DeleteProgram(Guid id)
        {
            var result = _programLogic.DeleteProgram(id);

            if (result.Success == false)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult InsertProgram(InsertProgramRequest request)
        {
            var result = _programLogic.InsertProgram(request);

            if (result.Success == false)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}