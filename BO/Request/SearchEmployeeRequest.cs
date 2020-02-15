using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Request
{
    public class SearchEmployeeRequest : BaseRequest
    {
        public string Name { get; set; }
        public int CityId { get; set; }
        public int RoleId { get; set; }
    }
}
