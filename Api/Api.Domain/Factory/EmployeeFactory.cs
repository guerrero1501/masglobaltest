using Api.Common;
using Api.Domain.ConcreteEmployee;
using Api.Repository.Entities;
using System;

namespace Api.Domain.Factory
{
    public class EmployeeFactory
    {
        public Employee GetEmployee(string contractTypeName)
        {
            switch (contractTypeName)
            {
                case ContractTypeName.HOURLY_SALARY_EMPLOYEE:
                    return new HourlySalaryEmployee();
                    
                case ContractTypeName.MONTHLY_SALARY_EMPLOYEE:
                    return new MonthlySalaryEmployee();
                default:
                    throw new Exception("Failed to create an employee.");                    
            }
        }
    }
}
