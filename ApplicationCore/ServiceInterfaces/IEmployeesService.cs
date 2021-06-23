using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IEmployeesService
    {
        Task<List<EmployeesInfoResponseModel>> GetAllEmployees();
        Task<EmployeesInfoResponseModel> GetEmployeeDetail(int id);
        Task<EmployeesInfoResponseModel> AddEmployee(EmployeeRequestModel model);
        Task<EmployeesInfoResponseModel> UpdateEmployeeById(int id, EmployeeRequestModel model);
        Task DeleteEmployeeById(int id);
    }
}
