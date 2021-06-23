using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
using ApplicationCore.Models.Request;

namespace ClientInformationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;
        private readonly IInteractionsService _interactionsService;

        public EmployeesController(IEmployeesService employeesService, IInteractionsService interactionsService)
        {
            _employeesService = employeesService;
            _interactionsService = interactionsService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeesService.GetAllEmployees();
            if (employees.Any())
            {
                return Ok(employees);
            }
            return NotFound("Employee Not Found");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployeeDetail(int id)
        {
            var employee = await _employeesService.GetEmployeeDetail(id);
            if (employee != null)
            {
                return Ok(employee);
            }
            return NotFound("Client Not Found");
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequestModel model)
        {
            var newEmp = await _employeesService.AddEmployee(model);
            return Ok(newEmp);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeesService.DeleteEmployeeById(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeRequestModel model)
        {
            var emp = await _employeesService.UpdateEmployeeById(id, model);
            return Ok(emp);
        }
    }
}
