using System;
using System.Collections.Generic;
using System.Text;
using BO.Models;

namespace BO.Request
{
    public class UpdateCourseRequest
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public double Time { get; set; }
        public bool IsAvailable { get; set; }
    }
}
