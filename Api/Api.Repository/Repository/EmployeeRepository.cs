using Api.Common.Helper;
using Api.Repository.IRepository;
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
            return JArray.Parse(await _restApi.Get(""));
        }
    }
}
