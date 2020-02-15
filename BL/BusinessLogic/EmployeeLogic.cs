using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BL.Interfaces;
using BO.Dtos;
using BO.Models;
using BO.Request;
using DAL.Repository.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BL.BusinessLogic
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public EmployeeLogic( IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public EmployeeDto GetEmployee (Guid  employeeid )
        {
            
            var employee = _uow.GetRepository<EmployeeEntity>().GetAll()
                .Include(c => c.Role)
                .FirstOrDefault(c => c.Id == employeeid);

            var result = _mapper.Map<EmployeeDto>(employee);
            return result;
        }

        public EmployeeDto DeleteEmployee(Guid employeeid)
        {

            var employee = _uow.GetRepository<EmployeeEntity>().GetAll()
                .FirstOrDefault(c => c.Id == employeeid);
            _uow.GetRepository<EmployeeEntity>().Delete(employee);
            _uow.SaveChange();
            var result = _mapper.Map<EmployeeDto>(employee);
            return result;
        }

        public List<EmployeeDto> GetEmployeesWithCondition(SearchEmployeeRequest request)
        {
            List<EmployeeDto> listEmployee = new List<EmployeeDto>();

            var employee = _uow.GetRepository<EmployeeEntity>().GetAll()
                .Include(c => c.Role)
                .Include(c => c.City);
            //001
            if (request.RoleId == 0 && request.CityId==0 && request.Name.Length !=0)
            {
                employee.Where(c =>  c.Name.Contains(request.Name))
                    .Skip((request.CurrentPage - 1) * request.PageRange)
                    .Take(request.PageRange)
                    .ToList();
            }
            //011
            if (request.RoleId == 0 && request.CityId != 0 && request.Name.Length != 0)
            {
                employee.Where(c => c.CityId== request.CityId && c.Name.Contains(request.Name))
                    .Skip((request.CurrentPage - 1) * request.PageRange)
                    .Take(request.PageRange)
                    .ToList();
            }
            //101
            if (request.RoleId != 0 && request.CityId == 0 && request.Name.Length != 0)
            {
                employee.Where(c => c.CityId == request.CityId && c.Name.Contains(request.Name))
                    .Skip((request.CurrentPage - 1) * request.PageRange)
                    .Take(request.PageRange)
                    .ToList();
            }
            //100
            if (request.RoleId != 0 && request.CityId == 0 && request.Name.Length == 0)
            {
                employee.Where(c => c.RoleId == request.RoleId)
                    .Skip((request.CurrentPage - 1) * request.PageRange)
                    .Take(request.PageRange)
                    .ToList();
            }
            //110
            if (request.RoleId != 0 && request.CityId != 0 && request.Name.Length == 0)
            {
                employee.Where(c => c.CityId == request.CityId && c.RoleId == request.RoleId)
                    .Skip((request.CurrentPage - 1) * request.PageRange)
                    .Take(request.PageRange)
                    .ToList();
            }
            //010
            if (request.RoleId == 0 && request.CityId != 0 && request.Name.Length == 0)
            {
                employee.Where(c => c.CityId == request.CityId )
                    .Skip((request.CurrentPage - 1) * request.PageRange)
                    .Take(request.PageRange)
                    .ToList();
            }
            //111
            if (request.RoleId != 0 && request.CityId != 0 && request.Name.Length != 0)
            {
                employee.Where(c => c.CityId== request.CityId && c.RoleId == request.RoleId && c.Name.Contains(request.Name))
                    .Skip((request.CurrentPage - 1) * request.PageRange)
                    .Take(request.PageRange)
                    .ToList();
            }
            //000
            if (request.RoleId == 0 && request.CityId == 0 && request.Name.Length == 0)
            {
                employee
                    .Skip((request.CurrentPage - 1) * request.PageRange)
                    .Take(request.PageRange)
                    .OrderBy(c => c.RoleId)
                    .ToList();
            }

            listEmployee = _mapper.Map<List<EmployeeDto>>(employee);
            return listEmployee;
        }

        public bool InsertEmployee(EmployeeDto employee)
        {
            try
            {
                _uow.GetRepository<EmployeeEntity>().Insert(new EmployeeEntity()
                {
                    Name = employee.Name,
                    Address = employee.Address,
                    RoleId = employee.RoleId,
                    Education = employee.Education,
                    Email = employee.Email,
                    Gender = employee.Gender,
                    CityId = employee.CityId,
                    IdentificationNumber = employee.IdentificationNumber,
                    GraduatedAt = employee.GraduatedAt,
                    HouseholdAddress = employee.HouseholdAddress,
                    NativeLand = employee.NativeLand,
                    StartedDate = DateTime.Now
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
        public bool UpdateEmployee(UpdateEmployeeRequest request)
        {
            try
            {
                var employee = _uow.GetRepository<EmployeeEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == request.EmployeeId);
                var temp = _mapper.Map<EmployeeEntity>(request.EmployeeInfo);
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
