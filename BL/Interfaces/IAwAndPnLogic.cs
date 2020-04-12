using System;
using System.Collections.Generic;
using System.Text;
using BL.Commons;
using BO.Dtos;
using BO.Models;
using BO.Request;

namespace BL.Interfaces
{
    public interface IAwAndPnLogic
    {
         BaseResponse<List<AwAndPnDto>> GetEmployeeAwAndPn(int currentpage, int pagerange);
         BaseResponse<List<AwAndPnEntity>> GetAwAndPnList(int currentpage, int pagerange);
         BaseResponse<bool> InsertEmployeeAwAndPn(EmployeeAwAndPnRequest request);
         BaseResponse<bool> UpdateEmployeeAwAndPn(EmployeeAwAndPnRequest request);
    }
}
