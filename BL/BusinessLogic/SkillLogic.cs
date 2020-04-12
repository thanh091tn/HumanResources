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
    public class SkillLogic : ISkillLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SkillLogic(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public BaseResponse<List<SkillDto>> GetEmployeeSkills(Guid employeeId, int currentpage, int pagerange)
        {
            var respond = new BaseResponse<List<SkillDto>>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            var result = new List<SkillDto>();
            var entity = _uow.GetRepository<EmployeeSkillEntity>().GetAll()
                .Include(c => c.Skill)
                .Where(c => c.EmployeeId == employeeId)
                .Skip((currentpage - 1) * pagerange)
                .Take(pagerange).ToList(); ;
            foreach (var e in entity)
            {
                result.Add(new SkillDto
                {
                    Id =  e.skillId,
                    EmployeeSkillId = e.Id,
                    Level = e.Level,
                    Name = e.Skill.Name
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

        public BaseResponse<bool> InsertEmployeeSkill(SkillRequest request)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var check = _uow.GetRepository<EmployeeSkillEntity>().GetAll()
                   .Where(c => c.EmployeeId == request.EmployeeId);
                if (!check.Any())
                {
                    /*var entity = _mapper.Map<List<EmployeeSkillEntity>>(request);
                    _uow.GetRepository<EmployeeSkillEntity>().BulkInsert(entity);*/
                    foreach (var skill in request.Skill)
                    {
                        _uow.GetRepository<EmployeeSkillEntity>().Insert(new EmployeeSkillEntity
                        {
                            EmployeeId = request.EmployeeId,
                            Level = skill.Level,
                            skillId = skill.Id,
                        });
                    }
                    
                }
                else
                {
                    _uow.GetRepository<EmployeeSkillEntity>().BulkDelete(check);
                    foreach (var skill in request.Skill)
                    {
                        _uow.GetRepository<EmployeeSkillEntity>().Insert(new EmployeeSkillEntity
                        {
                            EmployeeId = request.EmployeeId,
                            Level = skill.Level,
                            skillId = skill.Id,
                        });
                    }
                }
                _uow.SaveChange();

            }
            catch (Exception e)
            {
                respond.Data = false;
                respond.Success = false;
                respond.ErrorsMessages = "Invalid ID ";
                return respond;
            }

            return respond;
        }

        public BaseResponse<bool> DeleteEmployeeSkills(Guid id)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var entity = _uow.GetRepository<EmployeeSkillEntity>().GetAll().FirstOrDefault(c => c.Id == id);
                _uow.GetRepository<EmployeeSkillEntity>().Delete(entity);
                _uow.SaveChange();
                return respond;
            }
            catch (Exception e)
            {
                respond.ErrorsMessages = "Invalid ID";
                respond.Data = false;
                respond.Success = false;
                return respond;
            }
        }
        public BaseResponse<bool> DeleteSkills(int id)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var entity = _uow.GetRepository<SkillEnitity>().GetAll().FirstOrDefault(c => c.Id == id);
                _uow.GetRepository<SkillEnitity>().Delete(entity);
                _uow.SaveChange();
                return respond;
            }
            catch (Exception e)
            {
                respond.ErrorsMessages = "Invalid ID";
                respond.Data = false;
                respond.Success = false;
                return respond;
            }
        }

        public BaseResponse<bool> AddSkill(string name)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                //To do if exited return false
                _uow.GetRepository<SkillEnitity>().Insert(new SkillEnitity
                {
                    Name = name
                });
                _uow.SaveChange();
                return respond;
            }
            catch (Exception e)
            {
                respond.ErrorsMessages = "Invalid ID";
                respond.Data = false;
                respond.Success = false;
                return respond;
            }
        }
        public BaseResponse<bool> UpdateSkill(int id,string name)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var entity = _uow.GetRepository<SkillEnitity>().GetAll().FirstOrDefault(c => c.Id == id);
                if(entity != null) { 
                    entity.Name = name;
                    _uow.SaveChange();
                    return respond;
                }
                else
                {
                    respond.ErrorsMessages = "Not Found";
                    respond.Data = false;
                    respond.Success = false;
                    return respond;
                }
            }
            catch (Exception e)
            {
                respond.ErrorsMessages = "Invalid ID";
                respond.Data = false;
                respond.Success = false;
                return respond;
            }

            
        }

        public BaseResponse<SkillDto> GetSkill(int id)
        {
            var respond = new BaseResponse<SkillDto>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var entity = _uow.GetRepository<SkillEnitity>().GetAll().FirstOrDefault(c => c.Id == id);
                var result = _mapper.Map<SkillDto>(entity);
                if (result !=null)
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
            catch (Exception e)
            {
                respond.Success = false;
                respond.ErrorsMessages = e.ToString();
                return respond;
            }
        }
        public BaseResponse<List<SkillDto>> GetSkills(string keyword,int currentpage, int pagerange)
        {
            var respond = new BaseResponse<List<SkillDto>>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var entity = new List<SkillEnitity>();
                if (keyword.Trim().Length == 0)
                {
                     entity = _uow.GetRepository<SkillEnitity>().GetAll().Where(c => c.Name.Contains(keyword))
                         .OrderBy(c => c.Id)
                         .Skip((currentpage - 1) * pagerange)
                         .Take(pagerange).ToList();
                }
                else
                {
                     entity = _uow.GetRepository<SkillEnitity>().GetAll().OrderBy(c => c.Name)
                         .Skip((currentpage - 1) * pagerange)
                         .Take(pagerange).ToList();
                }
               
                var result = _mapper.Map<List<SkillDto>>(entity);
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
            catch (Exception e)
            {
                respond.Success = false;
                respond.ErrorsMessages = e.ToString();
                return respond;
            }
        }
    }
}
