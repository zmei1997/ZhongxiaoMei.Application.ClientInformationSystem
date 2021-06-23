using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class InteractionsRepository : EfRepository<Interaction>, IInteractionsRepository
    {
        public InteractionsRepository(ClientInformationSystemDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Interaction>> GetInteractionsByClientId(int id)
        {
            return await _dbContext.Interactions.Where(i => i.ClientId == id).Include(i => i.Client).Include(i => i.Emp).ToListAsync();
        }

        public async Task<IEnumerable<Interaction>> GetInteractionsByEmployeeId(int id)
        {
            return await _dbContext.Interactions.Where(i => i.EmpId == id).Include(i => i.Client).Include(i => i.Emp).ToListAsync();
        }

        public async Task<IEnumerable<Interaction>> GetInteractionsWithClientAndEmployee()
        {
            return await _dbContext.Interactions.Include(i => i.Client).Include(i => i.Emp).ToListAsync();
        }
    }
}
