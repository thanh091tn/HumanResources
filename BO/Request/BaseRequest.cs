using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class BaseRequest
    {
        public string Keyword { get; set; }
        public int CurrentPage { get; set; }
        public int PageRange { get; set; }
    }
}
