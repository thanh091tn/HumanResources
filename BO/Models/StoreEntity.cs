using System;

namespace BO.Models
{
    public class StoreEntity : BaseEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Size
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// StartedDate
        /// </summary>
        public DateTime StartedDate { get; set; }

        /// <summary>
        /// EndedDate
        /// </summary>
        public DateTime EndedDate { get; set; }

    }
}
