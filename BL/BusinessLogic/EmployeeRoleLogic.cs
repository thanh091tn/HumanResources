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
    public class EmployeeRoleLogic : IEmployeeRoleLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly UserHelper _userHelper;
        public EmployeeRoleLogic(IUnitOfWork uow, IMapper mapper, UserHelper userHelper)
        {
            _uow = uow;
            _mapper = mapper;
            _userHelper = userHelper;
        }

        public BaseResponse<List<EmployeeRoleDto>> GetEmployeeRoles(Guid employeeId, int currentpage, int pagerange)
        {
            var respond = new BaseResponse<List<EmployeeRoleDto>>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            var result = new List<EmployeeRoleDto>();
            var entity = _uow.GetRepository<EmployeeRoleEntity>().GetAll()
                .Include(c => c.Employee)
                .Include(c => c.Employee.Role)
                .Where(c => c.EmployeeId == employeeId)
                .Skip((currentpage - 1) * pagerange)
                .Take(pagerange).ToList();

            result = _mapper.Map<List<EmployeeRoleDto>>(entity);
            foreach (var x in result)
            {
                x.StartRoleName = _uow.GetRepository<RoleEntity>().GetAll().FirstOrDefault(c => c.Id == x.StartRoleId).Name;
                x.EndRoleName = _uow.GetRepository<RoleEntity>().GetAll().FirstOrDefault(c => c.Id == x.EndRoleId).Name;
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

        public BaseResponse<EmployeeRoleDto> GetEmployeeRole(Guid employeeId)
        {
            var respond = new BaseResponse<EmployeeRoleDto>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            var entity = _uow.GetRepository<EmployeeRoleEntity>().GetAll()
                .FirstOrDefault(c => c.EmployeeId == employeeId);
            var result = _mapper.Map<EmployeeRoleDto>(entity);
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

        public BaseResponse<bool> InsertOrUpdateEmployeeRole(InsertOrUpdateEmployeeRoleRequest employeerole)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
            try
            {
                if(employeerole.Id == Guid.Empty) { 
                var t = _uow.GetRepository<EmployeeRoleEntity>().GetAll().Where(c => c.EmployeeId == employeerole.EmployeeId);
                foreach (var x in t)
                {
                    x.IsCurrent = false;
                }
                _uow.GetRepository<EmployeeRoleEntity>().Insert(new EmployeeRoleEntity()
                {
                    EmployeeId = employeerole.EmployeeId,
                    DateTime = DateTime.Now,
                    CreatedBy = _userHelper.GetUserId(),
                    StartRoleId = employeerole.StartRoleId,
                    EndRoleId = employeerole.EndRoleId,
                    IsCurrent = true

                });
                }
                else
                {
                    var entity = _uow.GetRepository<EmployeeRoleEntity>().GetAll()
                        .FirstOrDefault(c => c.Id == employeerole.Id);
                    entity.DateTime = DateTime.Now;
                    entity.StartRoleId = employeerole.StartRoleId;
                    entity.EndRoleId = employeerole.EndRoleId;
                    entity.EmployeeId = employeerole.EmployeeId;
                }
                _uow.SaveChange();
            }
            catch (Exception e)
            {
                respond.Data = false;
                respond.Success = false;
                respond.ErrorsMessages = e.ToString();
            }
            return respond;
        }

        public BaseResponse<bool> DeleteEmployeeRole(Guid id)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };

            try
            {
                var entity = _uow.GetRepository<EmployeeRoleEntity>().GetAll()
                    .FirstOrDefault(c => c.Id == id);
                _uow.GetRepository<EmployeeRoleEntity>().Delete(entity);
                _uow.SaveChange();
                
            }
            catch (Exception e)
            {
                respond.Success = false;
                respond.Data = false;
                respond.ErrorsMessages = "Invalid ID";
            }

            return respond;
        }
    }
}
