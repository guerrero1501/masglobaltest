using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Repository.Entities
{
    public abstract class Employee
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public int HourlySalary { get; set; }
        public int MonthlySalary { get; set; }
        public abstract int AnnualSalary { get;}
    }
}
