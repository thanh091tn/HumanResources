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
using Microsoft.EntityFrameworkCore;

namespace BL.BusinessLogic
{
    public class EmployeeRoleLogic : IEmployeeRoleLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public EmployeeRoleLogic(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public List<EmployeeRoleDto> GetEmployeeRoles(Guid employeeId)
        {
            var entity = _uow.GetRepository<EmployeeRoleEntity>().GetAll()
                .Include(c => c.Employee)
                .Where(c => c.EmployeeId == employeeId);


            return _mapper.Map<List<EmployeeRoleDto>>(entity);
        }

        public EmployeeRoleDto GetEmployeeRole(Guid employeeId)
        {
            var entity = _uow.GetRepository<EmployeeRoleEntity>().GetAll()
                .FirstOrDefault(c => c.EmployeeId == employeeId);
            
            return _mapper.Map<EmployeeRoleDto>(entity);
        }

        public bool InsertOrUpdateEmployeeRole(InsertOrUpdateEmployeeRoleRequest employeerole)
        {
            try
            {
                if(employeerole.Id == null) { 
                var t = _uow.GetRepository<EmployeeRoleEntity>().GetAll().Where(c => c.EmployeeId == employeerole.EmployeeId);
                foreach (var x in t)
                {
                    x.IsCurrent = false;
                }
                _uow.GetRepository<EmployeeRoleEntity>().Insert(new EmployeeRoleEntity()
                {
                    EmployeeId = employeerole.EmployeeId,
                    DateTime = employeerole.DateTime,
                    CreatedBy = employeerole.CreatedById,
                    StartRoleId = employeerole.StartRoleId,
                    EndRoleId = employeerole.EndRoleId,
                    IsCurrent = true

                });
                }
                else
                {
                    var entity = _uow.GetRepository<EmployeeRoleEntity>().GetAll()
                        .FirstOrDefault(c => c.Id == employeerole.Id);
                    entity.DateTime = employeerole.DateTime;
                    entity.StartRoleId = employeerole.StartRoleId;
                    entity.EndRoleId = employeerole.EndRoleId;
                    entity.EmployeeId = employeerole.EmployeeId;
                }
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
