﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Dtos
{
    public class ProgramCourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CourseDto> ListCourse { get; set; }
    }
}
