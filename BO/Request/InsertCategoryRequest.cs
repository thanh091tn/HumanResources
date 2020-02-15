using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class InsertCategoryRequest
    {
        public string CategoryName { get; set; }
        public List<int> ListSkillId { get; set; }
    }
}
