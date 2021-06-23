using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;

namespace Infrastructure.Services
{
    public class EmployeesService:IEmployeesService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IInteractionsRepository _interactionsRepository;

        public EmployeesService(IEmployeesRepository employeesRepository, IInteractionsRepository interactionsRepository)
        {
            _employeesRepository = employeesRepository;
            _interactionsRepository = interactionsRepository;
        }

        // Add Employee
        public async Task<EmployeesInfoResponseModel> AddEmployee(EmployeeRequestModel model)
        {
            var employee = new Employee
            {
                Name = model.Name,
                Password = model.Password,
                Designation = model.Designation
            };

            var newEmployee = new EmployeesInfoResponseModel
            {
                Name = employee.Name,
                Password = employee.Password,
                Designation = employee.Designation
            };

            await _employeesRepository.AddAsync(employee);

            return newEmployee;
        }

        // Delete employee by its id
        public async Task DeleteEmployeeById(int id)
        {
            var employee = await _employeesRepository.GetByIdAsync(id);
            var empInters = await _interactionsRepository.GetInteractionsByEmployeeId(id);
            foreach (var item in empInters)
            {
                //item.ClientId = null;
                item.EmpId = null;
            }
            await _employeesRepository.DeleteAsync(employee);
        }

        // Get a list of employee records
        public async Task<List<EmployeesInfoResponseModel>> GetAllEmployees()
        {
            var employees = await _employeesRepository.ListAllAsync();
            List<EmployeesInfoResponseModel> employeeList = new List<EmployeesInfoResponseModel>();
            foreach (var employee in employees)
            {
                employeeList.Add(new EmployeesInfoResponseModel {
                    Id = employee.Id,
                    Name = employee.Name,
                    Password = employee.Password,
                    Designation = employee.Designation
                });
            }
            return employeeList;
        }

        // Get employee detail by Id
        public async Task<EmployeesInfoResponseModel> GetEmployeeDetail(int id)
        {
            var employee = await _employeesRepository.GetByIdAsync(id);
            var employeeDetail = new EmployeesInfoResponseModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Password = employee.Password,
                Designation = employee.Designation
            };
            return employeeDetail;
        }

        // update employee by id
        public async Task<EmployeesInfoResponseModel> UpdateEmployeeById(int id, EmployeeRequestModel model)
        {
            var employee = await _employeesRepository.GetByIdAsync(id);
            employee.Name = model.Name;
            employee.Password = model.Password;
            employee.Designation = model.Designation;

            var updatedEmp = new EmployeesInfoResponseModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Password = employee.Password,
                Designation = employee.Designation
            };

            await _employeesRepository.UpdateAsync(employee);
            return updatedEmp;
        }
    }
}
