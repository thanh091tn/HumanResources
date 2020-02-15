using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using BO.Dtos;
using BO.Models;
using BO.Request;
using DAL.Repository.UnitOfWorks;

namespace BL.BusinessLogic
{
    public class SkillLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SkillLogic(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public List<SkillDto> GetEmployeeSkills(Guid employeeId)
        {
            var entity = _uow.GetRepository<EmployeeSkillEntity>().GetAll()
                .Where(c => c.EmployeeId == employeeId);
            var result = _mapper.Map<List<SkillDto>>(entity);
            return result;
        }

        public bool InsertEmployeeSkill(SkillRequest request)
        {
            try
            {
                var check = _uow.GetRepository<EmployeeSkillEntity>().GetAll()
                    .FirstOrDefault(c => c.EmployeeId == request.EmployeeId);
                if (check == null)
                {
                    _uow.GetRepository<EmployeeSkillEntity>().Insert(new EmployeeSkillEntity
                    {
                        EmployeeId = request.EmployeeId,
                        Level =  request.Level,
                        skillId = request.SkillId,
                        });
                }
                else
                {
                    check.Level = request.Level;
                }
                _uow.SaveChange();

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
