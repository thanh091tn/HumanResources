using System;
using System.Collections.Generic;
using System.Text;
using BL.Commons;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface ICourseLogic
    {
        BaseResponse<CourseDto> GetCourse(Guid CourseId);
        BaseResponse<bool> InsertCourse(CourseRequest course);
        BaseResponse<bool> UpdateCourse(UpdateCourseRequest request);
        BaseResponse<List<CourseDto>> GetCourses(string keyword, int currentpage, int pagerange);
        BaseResponse<bool> DeleteCourse(Guid id);

    }
}
