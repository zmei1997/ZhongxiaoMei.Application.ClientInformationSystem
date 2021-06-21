using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EmployeesRepository : EfRepository<Employee>, IEmployeesRepository
    {
        public EmployeesRepository(ClientInformationSystemDBContext dbContext) : base(dbContext)
        {
        }
    }
}
