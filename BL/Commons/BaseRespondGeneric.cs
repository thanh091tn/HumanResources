﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Commons
{
    /// <summary>
    /// This class contain default properties of reponses
    /// </summary>
    /// <typeparam name="T">The type of data</typeparam>
    public class BaseResponse<T> : BaseResponse
    {
        /// <summary>
        /// Gets or sets data
        /// </summary>
        public T Data { get; set; }
    }
}
