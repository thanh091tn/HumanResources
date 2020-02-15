using System;
using System.Collections.Generic;
using System.Text;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface ICourseLogic
    {
        CourseDto GetCourse(Guid CourseId);
        List<CourseDto> GetCourses(BaseRequest request);
        bool InsertCourse(CourseRequest course);
        bool UpdateCourse(UpdateCourseRequest request);

    }
}
