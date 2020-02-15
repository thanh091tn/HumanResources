using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO.Models
{
    public class StoreEmployeeEntity : BaseEntity
    {
        /// <summary>
        /// EmployeeId
        /// </summary>
        public Guid EmployeeId { get; set; }
        /// <summary>
        ///StoreId
        /// </summary>
        public Guid StoreId { get; set; }

        public bool IsPrimary { get; set; }
        /// <summary>
        ///Store
        /// </summary>
        [ForeignKey("StoreId")]
        public StoreEntity Store { get; set; }
        /// <summary>
        /// Employee
        /// </summary>
        [ForeignKey("EmployeeId")]
        public EmployeeEntity Employee { get; set; }
    }
}
