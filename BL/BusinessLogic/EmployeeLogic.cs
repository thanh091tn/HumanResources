using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BL.Commons;
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
        private readonly UserHelper _userHelper;
        public EmployeeLogic( IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }

        public BaseResponse<EmployeeDto> GetEmployee (Guid  employeeid )
        {
            var respond = new BaseResponse<EmployeeDto>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            var employee = _uow.GetRepository<EmployeeEntity>().GetAll()
                .Include(c => c.Role)
                
                .FirstOrDefault(c => c.Id == employeeid);

            var result = _mapper.Map<EmployeeDto>(employee);
            if (result != null)
            {
                respond.Data = result;

            }
            else
            {
                respond.Success = false;
            }
            return respond;
        }

        public BaseResponse<bool> DeleteEmployee(Guid employeeid)
        {
            var respond = new BaseResponse<bool>
            {
                Data = false,
                Success = true,
                ErrorsMessages = ""
            };

            var employee = _uow.GetRepository<EmployeeEntity>().GetAll()
                .FirstOrDefault(c => c.Id == employeeid);
            if (employee == null)
            {
                respond.Success = false;
                respond.ErrorsMessages = "Not Found";
                return respond;
            }
            _uow.GetRepository<EmployeeEntity>().Delete(employee);
            _uow.SaveChange();
            var result = _mapper.Map<EmployeeDto>(employee);
            if (result != null)
            {
                respond.Data = true;

            }
            else
            {
                respond.Success = false;
            }
            return respond;
        }

        public BaseResponse<List<EmployeeDto>> GetEmployeesWithCondition(String keyword, int roleId, int currentpage, int pagerange)
        {
            var respond = new BaseResponse<List<EmployeeDto>>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            List<EmployeeDto> listEmployee = new List<EmployeeDto>();
            var result = new List<EmployeeEntity>();
            var employee = _uow.GetRepository<EmployeeEntity>().GetAll()
                .Include(c => c.Role)
                ;

            if (keyword.Length == 0 && roleId!=0)
            {
                result = employee.Where(c => c.RoleId == roleId).OrderBy(c => c.Name)
                    .Skip((currentpage - 1) * pagerange)
                    .Take(pagerange).ToList();
            }
            if (keyword.Length != 0 && roleId != 0)
            {
                result= employee.Where(c => c.RoleId == roleId && c.Name.Contains(keyword)).OrderBy(c => c.Name)
                    .Skip((currentpage - 1) * pagerange)
                    .Take(pagerange).ToList();
            }
            if (keyword.Length != 0 && roleId == 0)
            {
                result = employee.Where(c => c.Name.Contains(keyword)).OrderBy(c => c.Name)
                    .Skip((currentpage - 1) * pagerange)
                    .Take(pagerange).ToList();
            }
            if (keyword.Length == 0 && roleId == 0)
            {
                result = employee.OrderBy(c => c.Name)
                    .Skip((currentpage - 1) * pagerange)
                    .Take(pagerange).ToList();
            }

            listEmployee = _mapper.Map<List<EmployeeDto>>(result);
            if (listEmployee.Count != 0)
            {
                respond.Data = listEmployee;

            }
            else
            {
                respond.Success = false;
                respond.ErrorsMessages = "Not Found !";
            }
            return respond;
            
        }

        public BaseResponse<bool> InsertEmployee(EmployeeDto employee)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
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
                    City = employee.City,
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
                respond.Success = false;
                respond.Data = false;
                respond.ErrorsMessages = e.ToString();
            }
            return respond;
        }
        public BaseResponse<bool> UpdateEmployee(UpdateEmployeeRequest request)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                var employee = _uow.GetRepository<EmployeeEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == request.EmployeeId);
                if (employee != null)
                {
                    employee.Name = request.EmployeeInfo.Name;
                    employee.IdentificationNumber = request.EmployeeInfo.IdentificationNumber;
                    employee.Address = request.EmployeeInfo.Address;
                    employee.Gender = request.EmployeeInfo.Gender;
                    employee.HouseholdAddress = request.EmployeeInfo.HouseholdAddress;
                    employee.City = request.EmployeeInfo.City;
                    employee.Email = request.EmployeeInfo.Email;
                    employee.GraduatedAt = request.EmployeeInfo.GraduatedAt;
                    employee.NativeLand = request.EmployeeInfo.NativeLand;
                    employee.Education = request.EmployeeInfo.Education;
                    employee.RoleId = request.EmployeeInfo.RoleId;

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
    }
}
