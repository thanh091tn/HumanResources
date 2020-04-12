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
    public class ProgramLogic :IProgramLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ProgramLogic(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public BaseResponse<List<ProgramDto>> GetPrograms(string keyword, int currentpage, int pagerange)
        {
            var result =  new List<ProgramDto>();
            if(keyword.Length == 0) { 
            var listprogram = _uow.GetRepository<ProgramEntity>().GetAll().OrderBy(c => c.Name)
                .Skip((currentpage - 1) * pagerange)
                .Take(pagerange)
                .ToList();
                result = _mapper.Map<List<ProgramDto>>(listprogram);
                
            }
            else
            {
                var listprogram = _uow.GetRepository<ProgramEntity>().GetAll()
                    .Where(c => c.Name.Contains(keyword))
                    .OrderBy(c => c.Name)
                    .Skip((currentpage - 1) * pagerange)
                    .Take(pagerange)
                    .ToList();
                result = _mapper.Map<List<ProgramDto>>(listprogram);
               
            }
            var respond  = new BaseResponse<List<ProgramDto>>
            {
                Data = result,
                Success = true,
                ErrorsMessages = ""
            };
            if (result.Count == 0)
            {
                respond.Success = false;
                respond.ErrorsMessages = "Not Found";
            }
            return respond;
        }

        public BaseResponse<ProgramDto> GetProgram(Guid id)
        {
            var respond = new BaseResponse<ProgramDto>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var program = _uow.GetRepository<ProgramEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == id);
                if (program != null)
                {
                    var rs = _mapper.Map<ProgramDto>(program);
                    respond.Data = rs;
                    return respond;
                }

                respond.Success = false;
                respond.ErrorsMessages = "Not Found";
                return respond;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                respond.Success = false;
                respond.ErrorsMessages = e.ToString();
                return respond;
            }
            
        }
        

         public BaseResponse<List<EmployeeProgramDto>> GetEmployeePrograms(Guid userid, int currentpage, int pagerange)
        {
            var respond = new BaseResponse<List<EmployeeProgramDto>>
            {
                Data = null,
                Success = false,
                ErrorsMessages = ""
            };
            var entity = _uow.GetRepository<EmployeeProgramEntity>().GetAll()
                .Where(c => c.EmployeeId == userid)
                .Include(c => c.Program)
                .OrderByDescending(c => c.StartTime)
                .Skip((currentpage - 1) * pagerange)
                .Take(pagerange)
                .ToList();
            var result = _mapper.Map<List<EmployeeProgramDto>>(entity);
            if (result != null)
            {
                respond.Data = result;
                respond.Success = true;
            }
            else
            {
                respond.Success = false;
                respond.ErrorsMessages = "Not Found ";
            }
            return respond;
        }

        public BaseResponse<bool> InsertEmployeeProgram(EmployeeProgramRequest request)
        {
            var respond = new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                ErrorsMessages = ""
            };

            try
            {
                if(request.EndDate > request.StartDate) { 
                _uow.GetRepository<EmployeeProgramEntity>().Insert(new EmployeeProgramEntity
                {
                    EmployeeId = request.EmployeeId,
                    IsPassed = false,
                    ProgramId = request.ProgramId,
                    StartTime = request.StartDate,
                    EndTime = request.EndDate

                });
                respond.Success = true;
                respond.Data = true;
                _uow.SaveChange();
                return respond;
                }
                else
                {
                    respond.Success = false;
                    respond.Data = false;
                    respond.ErrorsMessages = "Invalid Startdate or EndDate";
                    return respond;
                }
            }
            catch (Exception e)
            {
                respond.Success = false;
                respond.Data = false;
                respond.ErrorsMessages = e.ToString();
                return respond;
            }
        }


        public BaseResponse<bool> DeleteEmployeeProgram(Guid id)
        {
            var respond = new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                ErrorsMessages = ""
            };
            try
            {
                var employeeProgram = _uow.GetRepository<EmployeeProgramEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == id);
                _uow.GetRepository<EmployeeProgramEntity>().Delete(employeeProgram);
                _uow.SaveChange();
                respond.Success = true;
                respond.Data = true;
                return respond;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                respond.Success = false;
                respond.Data = false;
                respond.ErrorsMessages = "Invalid ID";
                return respond;
            }
        }
        public BaseResponse<bool> DeleteProgram(Guid id)
        {
            var respond = new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                ErrorsMessages = ""
            };
            try
            {
                var program = _uow.GetRepository<ProgramEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == id);
                _uow.GetRepository<ProgramEntity>().Delete(program);
                _uow.SaveChange();
                respond.Success = true;
                respond.Data = true;
                return respond;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                respond.Success = false;
                respond.Data = false;
                respond.ErrorsMessages = "Invalid ID";
                return respond;
            }

        }


        public BaseResponse<bool> UpdateProgram(Guid id,string name)
        {
            var respond = new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                ErrorsMessages = ""
            };
            try
            {
                var program = _uow.GetRepository<ProgramEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == id);
                program.Name = name;
                _uow.GetRepository<ProgramEntity>().Update(program);
                _uow.SaveChange();
                respond.Success = true;
                respond.Data = true;
                return respond;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                respond.Success = false;
                respond.Data = false;
                respond.ErrorsMessages = "Invalid ProgramId";
                return respond;
            }

        }

        public BaseResponse<bool> UpdateEmployeeProgram(EmployeeProgramRequest request)
        {
            var respond = new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                ErrorsMessages = ""
            };
            try
            {
                var employeeProgram = _uow.GetRepository<EmployeeProgramEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == request.EmployeeProgramId);
                employeeProgram.StartTime = request.StartDate;
                employeeProgram.EndTime = request.EndDate;
                employeeProgram.ProgramId = request.ProgramId;
                employeeProgram.EmployeeId = request.EmployeeId;
                _uow.GetRepository<EmployeeProgramEntity>().Update(employeeProgram);
                _uow.SaveChange();
                respond.Success = true;
                respond.Data = true;
                return respond;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                respond.Success = false;
                respond.Data = false;
                respond.ErrorsMessages = "Invalid ID";
                return respond;
            }
        }

        public BaseResponse<bool> InsertProgram(InsertProgramRequest request)
        {
            var respond = new BaseResponse<bool>
            {
                Data = false,
                Success = false,
                ErrorsMessages = ""
            };
            try
            {
                var id =  Guid.NewGuid();
                  _uow.GetRepository<ProgramEntity>().Insert(new ProgramEntity()
                    {
                        Id = id ,
                        Name = request.Name

                    });
                  _uow.SaveChange();
                foreach (var courseid in request.Courses)
                {
                    _uow.GetRepository<ProgramCourseEntity>().Insert(new ProgramCourseEntity()
                    {
                        ProgramId = id,
                        CourseId = courseid

                    });
                }
                    _uow.SaveChange();
                respond.Success = true;
                respond.Data = true;
                return respond;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                respond.Success = false;
                respond.Data = false;
                respond.ErrorsMessages = "One or more CourseId is Invalid";
                return respond;
            }
        }

    }
}
