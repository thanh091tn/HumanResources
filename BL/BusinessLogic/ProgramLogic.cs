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
    public class ProgramLogic :IProgramLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ProgramLogic(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public List<ProgramDto> GetProgram(BaseRequest request)
        {
            var listprogram = _uow.GetRepository<ProgramEntity>().GetAll().OrderBy(c => c.Name)
                .Skip((request.CurrentPage - 1) * request.PageRange)
                .Take(request.PageRange)
                .ToList();
            var result = _mapper.Map<List<ProgramDto>>(listprogram);
            return result;
        }

        public bool InsertEmployeeProgram(EmployeeProgramRequest request)
        {
            try
            {
                if(request.EndDate > request.StartDate) { 
                _uow.GetRepository<EmployeeProgramEntity>().Insert(new EmployeeProgramEntity
                {
                    EmployeeId = request.EmployeeId,
                    IsPassed = false,
                    ProgramId = request.EmployeeId,
                    StartTime = request.StartDate,
                    EndTime = request.EndDate

                });
                _uow.SaveChange();
                return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
            return false;
        }

        public bool UpdateEmployeeProgram(EmployeeProgramRequest request)
        {
            try
            {
                if(request.IsRemove == false) {
                var employeeProgram = _uow.GetRepository<EmployeeProgramEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == request.EmployeeProgramId);
                employeeProgram.StartTime = request.StartDate;
                employeeProgram.EndTime = request.EndDate;
                _uow.SaveChange();
                return true;
                }
                else
                {
                    var employeeProgram = _uow.GetRepository<EmployeeProgramEntity>().GetAll()
                        .FirstOrDefault(c => c.Id == request.EmployeeProgramId);
                    employeeProgram.IsRemove = true;
                    _uow.SaveChange();
                    return true;
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
