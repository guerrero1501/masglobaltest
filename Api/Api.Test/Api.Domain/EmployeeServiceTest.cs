using Api.Domain.ConcreteEmployee;
using Api.Domain.Factory;
using Api.Domain.IService;
using Api.Domain.Service;
using Api.Repository.IRepository;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;
using Xunit;

namespace Api.Test.Api.Domain
{
    public class EmployeeServiceTest
    {
        Mock<IEmployeeRepository> employeeRepository= new Mock<IEmployeeRepository>();
        Mock<EmployeeFactory> factory = new Mock<EmployeeFactory>();

        [Fact]
        public async Task RetrieveEmployeeByIdOKAsync()
        {
            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var jss = new JsonSerializer
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            };

            employeeRepository.Setup(x =>  x.RetrieveEmployeeList()).ReturnsAsync(JArray.FromObject(Constants.EMPLOYEES, jss));
            var service = new EmployeeService(employeeRepository.Object, factory.Object);
            var response = await service.RetrieveEmployeeById(5);
            Assert.IsType<HourlySalaryEmployee>(response.Data);
        }

    }
}
