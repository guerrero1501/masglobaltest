using Api.Domain.ConcreteEmployee;
using Api.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Test
{
    public static class Constants
    {
        public static readonly List<Employee> EMPLOYEES = new List<Employee>
        {
            new HourlySalaryEmployee
            {
                Id = 5,
                Name = "Guerrero",
                ContractTypeName = "HourlySalaryEmployee",
                RoleId = 1,
                RoleName = "Administrator",
                HourlySalary = 10000,
                MonthlySalary = 3500000
            },
            new MonthlySalaryEmployee
            {
                Id = 2,
                Name = "Andres",
                ContractTypeName = "MonthlySalaryEmployee",
                RoleId = 1,
                RoleName = "Contractor",
                HourlySalary = 12000,
                MonthlySalary = 2500000
            }
        };
    }
}
