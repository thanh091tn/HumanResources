using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Commons
{
    [Serializable]
    public class BaseResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets Errors
        /// </summary>
        public string ErrorsMessages { get; set; }
    }
}
