﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BO.Dtos
{
    public class CategorySkillDto
    {
        public Guid Id { get; set; }
        public int SkillId { get; set; }
        public string SkillName { get; set; }
    }
}
