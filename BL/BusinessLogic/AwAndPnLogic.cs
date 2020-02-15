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
    public class AwAndPnLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public AwAndPnLogic(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public List<AwAndPnDto> GetEmployeeAwAndPn(BaseRequest request)
        {
            var employeeAwAndPn = _uow.GetRepository<AwAndPnEmployeeEntity>().GetAll().OrderBy(c => c.DateTime).ToList();
            var result = _mapper.Map<List<AwAndPnDto>>(employeeAwAndPn);
            return result;
        }
        public List<AwAndPnEntity> GetAwAndPnList(BaseRequest request)
        {
            return _uow.GetRepository<AwAndPnEntity>().GetAll().ToList();
           
        }
        public bool InsertEmployeeAwAndPn(EmployeeAwAndPnRequest request)
        {
            try
            {
                _uow.GetRepository<AwAndPnEmployeeEntity>().Insert(new AwAndPnEmployeeEntity
                {
                    EmployeeId = request.EmployeeId,
                    AwAndPnId = request.AwAndPnId,
                    DateTime = request.DateTime
                });
                _uow.SaveChange();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }

            return false;
        }
        public bool UpdateEmployeeAwAndPn(EmployeeAwAndPnRequest request)
        {
            try
            {
                if(request.IsRemove== false) { 
                var awAndPnEmployee =
                    _uow.GetRepository<AwAndPnEmployeeEntity>().GetAll()
                        .FirstOrDefault(c => c.Id == request.Id);
                awAndPnEmployee.DateTime = request.DateTime;
                awAndPnEmployee.AwAndPnId = request.AwAndPnId;
                awAndPnEmployee.EmployeeId = request.EmployeeId;
                }
                else
                {
                    var awAndPnEmployee =
                        _uow.GetRepository<AwAndPnEmployeeEntity>().GetAll()
                            .FirstOrDefault(c => c.Id == request.Id);
                    awAndPnEmployee.IsRemove = true;
                }
                _uow.SaveChange();
                return true;
                
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
