using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Models
{
    public class AwAndPnEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public ICollection<AwAndPnEmployeeEntity> AwAndPnEmployee { get; set; }
    }
}
