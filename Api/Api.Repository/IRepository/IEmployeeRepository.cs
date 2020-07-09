using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.IRepository
{
    public interface IEmployeeRepository
    {
        Task<JArray> RetrieveEmployeeList();
    }
}
