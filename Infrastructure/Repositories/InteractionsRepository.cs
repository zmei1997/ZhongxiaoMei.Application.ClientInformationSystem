using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class InteractionsRepository : EfRepository<Interaction>, IInteractionsRepository
    {
        public InteractionsRepository(ClientInformationSystemDBContext dbContext) : base(dbContext)
        {
        }
    }
}
