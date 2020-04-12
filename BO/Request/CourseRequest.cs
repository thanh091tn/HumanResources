using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class CourseRequest
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Level ( caculate by hours)
        /// </summary>
        public double Time { get; set; }
        /// <summary>
        /// IsAvailable
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}
