using System;

namespace BO.Models
{
    /// <summary>
    /// BaseEntity
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// CreatedBy
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// UpdateBy
        /// </summary>
        public Guid? UpdateBy { get; set; }

        /// <summary>
        /// RemovedBy
        /// </summary>
        public Guid? RemovedBy { get; set; }
    }
}
