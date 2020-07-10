using Api.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.ConcreteEmployee
{
    public class HourlySalaryEmployee : Employee
    {
        public override int AnnualSalary => 1440 * HourlySalary; 
    }
}
