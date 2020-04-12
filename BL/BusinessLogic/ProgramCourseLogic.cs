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
     public class ProgramCourseLogic : IProgramCourseLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public ProgramCourseLogic(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }


        public BaseResponse<List<CourseDto>> GetProgramCourse(Guid programId)
        {
            var respond = new BaseResponse<List<CourseDto>>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            var entity = _uow.GetRepository<ProgramCourseEntity>().GetAll()
                .Include(c => c.Course)
                .Include(c => c.Program)
                .Where(c => c.ProgramId == programId);
           
            var result = new List<CourseDto>();
            foreach (var x in entity)
            {
                var temp = new CourseDto
                {
                    Id = x.Course.Id,
                    Name = x.Course.Name,
                    Time = x.Course.Time,
                    IsAvailable =  x.Course.IsAvailable
                };
                result.Add(temp);
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


        public BaseResponse<bool> UpdateProgramCourse(CreateProgramCourseRequest request)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var userid = _userHelper.GetUserId();
                var z =  _uow.GetRepository<ProgramCourseEntity>().GetAll().Where(c =>c.ProgramId == request.ProgramId).ToList();
                List<Guid> listid =  new List<Guid>();
                foreach (var x in z)
                {
                    listid.Add(x.CourseId);
                }
                foreach (var courseId in request.ListCourseId)
                {
                    if (!listid.Contains(courseId))
                    {
                        _uow.GetRepository<ProgramCourseEntity>().Insert(new ProgramCourseEntity
                        {
                            ProgramId = request.ProgramId,
                            CourseId = courseId,
                            CreatedBy = userid

                        });
                    }
                    
                }
                
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
