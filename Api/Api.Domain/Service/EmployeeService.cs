using Api.Common.Contracts;
using Api.Domain.Factory;
using Api.Domain.IService;
using Api.Repository.Entities;
using Api.Repository.IRepository;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly EmployeeFactory _factory;
        public EmployeeService(IEmployeeRepository employeeRepository, EmployeeFactory factory)
        {
            _employeeRepository = employeeRepository;
            _factory = factory;
        }

        public async Task<DataTransferObject<Employee>> RetrieveEmployeeById(int id)
        {
            var employees = await _employeeRepository.RetrieveEmployeeList();
            var employee = employees.FirstOrDefault(x => x["id"].ToObject<int>() == id);
            var contractTypeName = employee["contractTypeName"].ToString();
            var concreteEmployee = _factory.GetEmployee(contractTypeName);
            concreteEmployee.MonthlySalary = employee["monthlySalary"].ToObject<int>();
            concreteEmployee.HourlySalary = employee["hourlySalary"].ToObject<int>();
            concreteEmployee.ContractTypeName = contractTypeName;
            return new DataTransferObject<Employee>() { Data = concreteEmployee };
        }

        public async Task<DataTransferObject<List<Employee>>> RetrieveEmployeeList()
        {            
            var employees = await _employeeRepository.RetrieveEmployeeList();
            var data = new List<Employee>();

            foreach (var employee in employees)
            {
                var contractTypeName = employee["contractTypeName"].ToString();
                var concreteEmployee = _factory.GetEmployee(contractTypeName);
                concreteEmployee.MonthlySalary = employee["monthlySalary"].ToObject<int>();
                concreteEmployee.HourlySalary = employee["hourlySalary"].ToObject<int>();
                concreteEmployee.ContractTypeName = contractTypeName;
                data.Add(concreteEmployee);
            }

            return new DataTransferObject<List<Employee>>() { Data = data };
        }
    }
}
