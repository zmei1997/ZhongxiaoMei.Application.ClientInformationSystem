using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IInteractionsRepository : IAsyncRepository<Interaction>
    {
        Task<IEnumerable<Interaction>> GetInteractionsWithClientAndEmployee();
        Task<IEnumerable<Interaction>> GetInteractionsByClientId(int id);
        Task<IEnumerable<Interaction>> GetInteractionsByEmployeeId(int id);
    }
}
