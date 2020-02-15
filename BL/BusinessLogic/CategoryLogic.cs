using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BO.Dtos;
using BO.Models;
using BO.Request;
using DAL.Repository.UnitOfWorks;

namespace BL.BusinessLogic
{
    public class CategoryLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CategoryLogic(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public List<CategoryDto> GetCategories(BaseRequest request)
        {
            var entity = _uow.GetRepository<CategoryEntity>().GetAll()
                .Where(c => c.Name.Contains(request.Keyword));
            var result = _mapper.Map<CategoryDto>(entity);
            return null;
        }

        public List<CategorySkillDto> GetCategorySkill(Guid categoryId)
        {
            var entity = _uow.GetRepository<CategorySkillEntity>().GetAll()
                .Where(c => c.CategoryId == categoryId);
            var result = _mapper.Map<CategoryDto>(entity);
            return null;
        }


        public bool InsertCategory(InsertCategoryRequest request)
        {
            try
            {
                var test =_uow.GetRepository<CategoryEntity>().GetAll()
                    .Where(c => c.Name.Equals(request.CategoryName));
                var id = Guid.NewGuid();
                if (test == null)
                {
                    _uow.GetRepository<CategoryEntity>().Insert(new CategoryEntity
                    {
                        Name = request.CategoryName,
                        Id = id
                    });
                    foreach (var x in request.ListSkillId)
                    {
                        _uow.GetRepository<CategorySkillEntity>().Insert(new CategorySkillEntity
                        {
                            SkillId = x,
                            CategoryId = id
                        });
                    }
                    _uow.SaveChange();
                    }
                }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return false;
        }
    }
}
