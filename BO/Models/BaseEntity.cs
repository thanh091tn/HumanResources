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
        public string CreatedBy { get; set; }

        /// <summary>
        /// UpdateBy
        /// </summary>
        public string UpdateBy { get; set; }

        /// <summary>
        /// RemovedBy
        /// </summary>
        public string RemovedBy { get; set; }
    }
}
