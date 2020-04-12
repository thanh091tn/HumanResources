using System;
using System.Collections.Generic;
using System.Text;
using BL.Commons;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface IProgramCourseLogic
    {
        BaseResponse<List<CourseDto>> GetProgramCourse(Guid programId);
        BaseResponse<bool> UpdateProgramCourse(CreateProgramCourseRequest request);
    }
}
