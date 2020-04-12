using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BL.Commons;
using BL.Interfaces;
using BO.Dtos;
using BO.Models;
using BO.Request;
using DAL.Repository.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace BL.BusinessLogic
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CategoryLogic(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public BaseResponse<List<CategoryDto>> GetCategories(string keyword , int currentpage , int pagerange)
        {
            var respond = new BaseResponse<List<CategoryDto>>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            var entity = new List<CategoryEntity>();
            if (keyword.Trim().Length !=0)
            {
                 entity = _uow.GetRepository<CategoryEntity>().GetAll()
                    .Where(c => c.Name.Contains(keyword)).Skip((currentpage - 1) * pagerange)
                    .Take(pagerange).ToList();
            }
            else
            {
                 entity = _uow.GetRepository<CategoryEntity>().GetAll()
                    .Skip((currentpage - 1) * pagerange)
                    .Take(pagerange).ToList();
            }
            var result = new List<CategoryDto>();
            foreach (var category in entity)
            {
                result.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            if (result.Count != 0)
            {
                respond.Data = result;
            }
            else
            {
                respond.Success = false;
                respond.ErrorsMessages = "Not Found";
            }

            return respond;
        }

        public BaseResponse<List<CategorySkillDto>> GetCategorySkill(Guid categoryId)
        {
            var respond = new BaseResponse<List<CategorySkillDto>>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            var result = new List<CategorySkillDto>();
            var entity = _uow.GetRepository<CategorySkillEntity>().GetAll()
                .Include(c => c.Skill)
                .Where(c => c.CategoryId == categoryId);
            foreach (var category in entity)
            {
                result.Add(new CategorySkillDto
                {
                    Id = category.Id,
                    SkillId = category.SkillId,
                    SkillName =  category.Skill.Name
                });
            }
            if (result != null)
            {
                respond.Data = result;
            }
            else
            {
                respond.Success = false;
                respond.ErrorsMessages = "Not Found";
            }

            return respond;
        }

        public BaseResponse<bool> DeleteCategorySkill(Guid id)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var entity = _uow.GetRepository<CategorySkillEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == id);
                if (entity != null)
                {
                    _uow.GetRepository<CategorySkillEntity>().Delete(entity);
                    _uow.SaveChange();
                }
                else
                {
                    respond.Data = false;
                    respond.Success = false;
                    respond.ErrorsMessages = "Invalid ID";
                }
                
            }
            catch (Exception e)
            {
                respond.Data = false;
                respond.Success = false;
                respond.ErrorsMessages = "Invalid ID";
            }

            return respond;
        }
        public BaseResponse<bool> DeleteCategory(Guid id)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var entity = _uow.GetRepository<CategoryEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == id);
                _uow.GetRepository<CategoryEntity>().Delete(entity);
                _uow.SaveChange();
                
            }
            catch (Exception e)
            {
                respond.Data = false;
                respond.Success = false;
                respond.ErrorsMessages = "Invalid ID";
            }
            return respond;
        }

        public BaseResponse<bool> InsertCategory(InsertCategoryRequest request)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var test =_uow.GetRepository<CategoryEntity>().GetAll()
                    .FirstOrDefault(c => c.Name.Equals(request.CategoryName));
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
                else
                {
                    var entity = _uow.GetRepository<CategorySkillEntity>().GetAll().Where(c => c.CategoryId == test.Id)
                        .ToList();
                    _uow.GetRepository<CategorySkillEntity>().BulkDelete(entity);
                    foreach (var x in request.ListSkillId)
                    {
                        _uow.GetRepository<CategorySkillEntity>().Insert(new CategorySkillEntity
                        {
                            SkillId = x,
                            CategoryId = test.Id
                        });
                    }
                    _uow.SaveChange();
                    
                }
            }
            catch (Exception e)
            {
                respond.Data = false;
                respond.Success = false;
                respond.ErrorsMessages = "Invalid ID";
            }

            return respond;
        }
    }
}
