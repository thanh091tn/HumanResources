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

namespace BL.BusinessLogic
{
    public class AwAndPnLogic :IAwAndPnLogic
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public AwAndPnLogic(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public BaseResponse<List<AwAndPnDto>> GetEmployeeAwAndPn(int currentpage, int pagerange)
        {
            var respond = new BaseResponse<List<AwAndPnDto>>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };
            var employeeAwAndPn = _uow.GetRepository<AwAndPnEmployeeEntity>().GetAll()
                .OrderBy(c => c.DateTime)
                .Skip((currentpage - 1) * pagerange)
                .Take(pagerange)
                .ToList();
            var result = _mapper.Map<List<AwAndPnDto>>(employeeAwAndPn);
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

        public BaseResponse<List<AwAndPnEntity>> GetAwAndPnList(int currentpage, int pagerange)
        {
            var respond = new BaseResponse<List<AwAndPnEntity>>
            {
                Data = null,
                Success = true,
                ErrorsMessages = ""
            };

            var result =  _uow.GetRepository<AwAndPnEntity>().GetAll()
                .OrderBy(c => c.Name).Skip((currentpage - 1) * pagerange)
                .Take(pagerange).ToList();
            if (result.Count() != 0)
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
        public BaseResponse<bool> InsertEmployeeAwAndPn(EmployeeAwAndPnRequest request)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };

            try
            {
                _uow.GetRepository<AwAndPnEmployeeEntity>().Insert(new AwAndPnEmployeeEntity
                {
                    EmployeeId = request.EmployeeId,
                    AwAndPnId = request.AwAndPnId,
                    DateTime = request.DateTime
                });
                _uow.SaveChange();
                
            }
            catch (Exception e)
            {
                respond.Success = false;
                respond.ErrorsMessages = e.ToString();
            }

            return respond;
        }
        public BaseResponse<bool> UpdateEmployeeAwAndPn(EmployeeAwAndPnRequest request)
        {
            var respond = new BaseResponse<bool>
            {
                Data = true,
                Success = true,
                ErrorsMessages = ""
            };
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
                
                
            }
            catch (Exception e)
            {
                respond.Success = false;
                respond.ErrorsMessages = e.ToString();
                respond.Data = false;
            }

            return respond;
        }
    }
}
