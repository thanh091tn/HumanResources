using System;
using System.Collections.Generic;
using System.Text;
using BL.Commons;
using BO.Dtos;
using BO.Request;

namespace BL.Interfaces
{
    public interface ICategoryLogic
    {
        BaseResponse<List<CategoryDto>> GetCategories(string keyword, int currentpage, int pagerange);
        BaseResponse<List<CategorySkillDto>> GetCategorySkill(Guid categoryId);
        BaseResponse<bool> InsertCategory(InsertCategoryRequest request);
        BaseResponse<bool> DeleteCategorySkill(Guid id);
        BaseResponse<bool> DeleteCategory(Guid id);
    }
}
