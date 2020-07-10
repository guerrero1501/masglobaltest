using Api.Common.Helper;
using Api.Repository.Entities;
using Api.Repository.IRepository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly RestApiHelper _restApi;
        public EmployeeRepository(RestApiHelper restApi)
        {
            _restApi = restApi;
        }
        public async Task<JArray> RetrieveEmployeeList()
        {
            var response = await _restApi.Get("https://masglobaltestapi.azurewebsites.net/api/Employees");
            return JArray.Parse(response);
        }
    }
}
