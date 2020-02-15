using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
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

        public CourseLogic(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public CourseDto GetCourse(Guid CourseId)
        {
            var employee = _uow.GetRepository<CourseEntity>().GetAll()
                
                .FirstOrDefault(c => c.Id == CourseId);

            var result = _mapper.Map<CourseDto>(employee);
            return result;
        }

        public List<CourseDto> GetCourses(BaseRequest request)
        {
            var entity = new List<CourseEntity>();
            if (request.Keyword.Length == 0) { 
             entity = _uow.GetRepository<CourseEntity>().GetAll()
                .Skip((request.CurrentPage - 1) * request.PageRange)
                .Take(request.PageRange)
                .ToList();
            }
            else
            {
                 entity = _uow.GetRepository<CourseEntity>().GetAll()
                    .Where(c => c.Name.Contains(request.Keyword))
                    .Skip((request.CurrentPage - 1) * request.PageRange)
                    .Take(request.PageRange)
                    .ToList();
            }

            return _mapper.Map<List<CourseDto>>(entity);
        }

        public bool InsertCourse(CourseRequest course)
        {
            try
            {
                _uow.GetRepository<CourseEntity>().Insert(new CourseEntity()
                {
                    Name = course.Name,
                    IsAvailable = true,
                    Time = course.Time,
                    CreatedBy = course.Createdby

                });
                _uow.SaveChange();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }

        public bool UpdateCourse(UpdateCourseRequest request)
        {
            try
            {
                var employee = _uow.GetRepository<CourseEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == request.CourseId);
                var temp = _mapper.Map<CourseEntity>(request.CourseInfo);
                employee = temp;
                _uow.SaveChange();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return true;
        }
    }
}
