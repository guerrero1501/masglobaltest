using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Common.Contracts;
using Api.Domain.IService;
using Api.Repository.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<DataTransferObject<List<Employee>>> GetAsync()
        {

            DataTransferObject<List<Employee>> response = new DataTransferObject<List<Employee>>();

            try
            {
                response =  await _employeeService.RetrieveEmployeeList();
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpStatusCode.InternalServerError;
                response.Header.Message = ex.Message;
            }
            return response;
            
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<DataTransferObject<Employee>> Get(int id)
        {
            DataTransferObject<Employee> response = new DataTransferObject<Employee>();
            try
            {
                response = await _employeeService.RetrieveEmployeeById(id);
            }
            catch (Exception ex)
            {
                response.Header.Code = HttpStatusCode.InternalServerError;
                response.Header.Message = ex.Message;
            }
            return response;
        }
    }
}
