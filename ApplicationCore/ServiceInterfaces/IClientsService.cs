using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IClientsService
    {
        Task<List<ClientsInfoResponseModel>> GetClientList();
        Task<ClientsInfoResponseModel> GetClientDetail(int id);
        Task<ClientsInfoResponseModel> AddClient(ClientRequestModel model);
        Task<ClientsInfoResponseModel> UpdateClientById(int id, ClientRequestModel model);
        Task DeleteClientById(int id);
    }
}
