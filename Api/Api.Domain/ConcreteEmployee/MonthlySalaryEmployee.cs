using Api.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.ConcreteEmployee
{
    public class MonthlySalaryEmployee : Employee
    {
        public override int AnnualSalary => MonthlySalary * 12;
    }
}
