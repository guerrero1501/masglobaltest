using Api.Common.Contracts;
using Api.Domain.Factory;
using Api.Domain.IService;
using Api.Repository.Entities;
using Api.Repository.IRepository;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
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
            JArray employees = await _employeeRepository.RetrieveEmployeeList();
            JToken employee = employees.FirstOrDefault(x => x["id"].ToObject<int>() == id);
            
            return new DataTransferObject<Employee>() { Data = MapEmployee(employee) };
        }

        public async Task<DataTransferObject<List<Employee>>> RetrieveEmployeeList()
        {
            JArray employees = await _employeeRepository.RetrieveEmployeeList();
            List<Employee> data = new List<Employee>();

            foreach (JToken employee in employees)
            {
                
                data.Add(MapEmployee(employee));
            }

            return new DataTransferObject<List<Employee>>() { Data = data };
        }

        private Employee MapEmployee(JToken employee)
        {
            string contractTypeName = employee["contractTypeName"].ToString();
            Employee concreteEmployee = _factory.GetEmployee(contractTypeName);
            concreteEmployee.Id = employee["id"].ToObject<int>();
            concreteEmployee.Name = employee["name"].ToString();
            concreteEmployee.RoleName = employee["roleName"].ToString();
            concreteEmployee.MonthlySalary = employee["monthlySalary"].ToObject<int>();
            concreteEmployee.RoleId = employee["roleId"].ToObject<int>();
            concreteEmployee.MonthlySalary = employee["monthlySalary"].ToObject<int>();
            concreteEmployee.HourlySalary = employee["hourlySalary"].ToObject<int>();
            concreteEmployee.ContractTypeName = contractTypeName;
            return concreteEmployee;
        }
    }
}
