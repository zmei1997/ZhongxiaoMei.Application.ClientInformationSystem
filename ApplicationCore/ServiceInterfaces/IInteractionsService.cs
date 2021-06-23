using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IInteractionsService
    {
        Task<List<InteractionsResponseModel>> GetInteractions();
        Task<List<InteractionsResponseModel>> GetInteractionsByClientId(int id);
        Task<List<InteractionsResponseModel>> GetInteractionsByEmployeeId(int id);
        Task<InteractionsResponseModel> GetInteractionDetail(int id);
        //Task<InteractionWithClientsEmployeesResponseModel> GetInteractionDetail(int id);
        Task<InteractionsResponseModel> AddInteraction(InteractionRequestModel model);
        Task<InteractionsResponseModel> UpdateInteraction(int id, InteractionRequestModel model);
        Task DeleteInteraction(int id);
    }
}
