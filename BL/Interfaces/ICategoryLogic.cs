using System;
using System.Collections.Generic;
using System.Text;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface ICategoryLogic
    {
        List<CategoryDto> GetCategories(BaseRequest request);
        List<CategorySkillDto> GetCategorySkill(Guid categoryId);
        bool InsertCategory(InsertCategoryRequest request);
    }
}
