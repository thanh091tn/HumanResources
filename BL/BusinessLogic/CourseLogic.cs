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

namespace BL.BusinessLogic
{
    public class CourseLogic : ICourseLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public CourseLogic(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }

        public BaseResponse<CourseDto> GetCourse(Guid CourseId)
        {
            var respond = new BaseResponse<CourseDto>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            var entity = _uow.GetRepository<CourseEntity>().GetAll()
                
                .FirstOrDefault(c => c.Id == CourseId);

            var result = _mapper.Map<CourseDto>(entity);
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

        public BaseResponse<List<CourseDto>> GetCourses(string keyword , int currentpage , int pagerange)
        {
            var respond = new BaseResponse<List<CourseDto>>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            var entity = new List<CourseEntity>();
            
            if (keyword.Trim().Length == 0) { 
             entity = _uow.GetRepository<CourseEntity>().GetAll()
                .Skip((currentpage - 1) * pagerange)
                .Take(pagerange)
                .ToList();
            }
            else
            {
                 entity = _uow.GetRepository<CourseEntity>().GetAll()
                    .Where(c => c.Name.Contains(keyword))
                    .Skip((currentpage - 1) * pagerange)
                    .Take(pagerange)
                    .ToList();
            }
            var result = _mapper.Map<List<CourseDto>>(entity);
            if (result.Count !=0)
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

        public BaseResponse<bool> InsertCourse(CourseRequest course)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                _uow.GetRepository<CourseEntity>().Insert(new CourseEntity()
                {
                    Name = course.Name,
                    IsAvailable = true,
                    Time = course.Time,
                    CreatedBy = _userHelper.GetUserId()

                });
                _uow.SaveChange();
            }
            catch (Exception e)
            {
                respond.Success = false;
                respond.Data = false;
                respond.ErrorsMessages = e.ToString();
            }

            return respond;
        }

        public BaseResponse<bool> UpdateCourse(UpdateCourseRequest request)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var entity = _uow.GetRepository<CourseEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == request.CourseId);
                if (entity !=null)
                {
                    entity.Name = request.Name;
                    entity.Time = request.Time;
                    entity.IsAvailable = request.IsAvailable;
                    _uow.SaveChange();
                }
                else
                {
                    respond.Success = false;
                    respond.Data = false;
                    respond.ErrorsMessages = "Not Found";
                }
                
            }
            catch (Exception e)
            {
                respond.Success = false;
                respond.Data = false;
                respond.ErrorsMessages = e.ToString();
            }

            return respond;
        }

        public BaseResponse<bool> DeleteCourse(Guid id)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var entity = _uow.GetRepository<CourseEntity>().GetAll().FirstOrDefault(c => c.Id == id);
                _uow.GetRepository<CourseEntity>().Delete(entity);
                _uow.SaveChange();
            }
            catch (Exception e)
            {
                respond.Success = false;
                respond.Data = false;
                respond.ErrorsMessages = e.ToString();
            }

            return respond;
        }
    }
}
