using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BO.Dtos;
using BO.Models;
using BO.Request;

namespace API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<EmployeeEntity, EmployeeDto>();
            CreateMap<EmployeeDto, EmployeeEntity>();
            CreateMap<EmployeeRoleEntity, EmployeeRoleDto>();
            CreateMap<EmployeeRoleDto, EmployeeRoleEntity>();
            CreateMap<EmployeeSkillEntity, SkillDto>();
            CreateMap<SkillDto, EmployeeSkillEntity>();
            CreateMap<ProgramEntity, ProgramDto>();
            CreateMap<ProgramDto, ProgramEntity>();
            CreateMap<EmployeeProgramEntity, EmployeeProgramDto>();
            CreateMap<EmployeeProgramDto, EmployeeProgramEntity>();
            CreateMap<CourseEntity, CourseDto>();
            CreateMap<CourseDto, CourseEntity>();
            CreateMap<EmployeeSkillEntity, SkillRequest>();
            CreateMap<SkillRequest, EmployeeSkillEntity>();
            CreateMap<SkillEnitity, SkillDto>();
            CreateMap<SkillDto, SkillEnitity>();
            CreateMap<EmployeeSkillEntity, SkillDto>();
            CreateMap<SkillDto, EmployeeSkillEntity>();
            CreateMap<ProgramCourseEntity, CourseDto>();
            CreateMap<CourseDto, ProgramCourseEntity>();

        }
    }
}
