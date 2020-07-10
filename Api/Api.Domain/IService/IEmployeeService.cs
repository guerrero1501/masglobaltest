using Api.Common.Contracts;
using Api.Repository.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.IService
{
    public interface IEmployeeService
    {
        Task<DataTransferObject<List<Employee>>> RetrieveEmployeeList();
        Task<DataTransferObject<Employee>> RetrieveEmployeeById(int id);
    }
}
