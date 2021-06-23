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
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _clientsRepository;
        private readonly IInteractionsRepository _interactionsRepository;
        public ClientsService(IClientsRepository clientsRepository, IInteractionsRepository interactionsRepository)
        {
            _clientsRepository = clientsRepository;
            _interactionsRepository = interactionsRepository;
        }

        public async Task<ClientsInfoResponseModel> AddClient(ClientRequestModel model)
        {
            var client = new Client
            {
                Name = model.Name,
                Email = model.Email,
                Phones = model.Phones,
                Address = model.Address,
                AddedOn = model.AddedOn
            };

            var clientsInfo = new ClientsInfoResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
                AddedOn = client.AddedOn
            };

            await _clientsRepository.AddAsync(client);
            return clientsInfo;
        }

        public async Task DeleteClientById(int id)
        {
            var client = await _clientsRepository.GetByIdAsync(id);
            var clientInteractions = await _interactionsRepository.GetInteractionsByClientId(id);
            foreach (var item in clientInteractions)
            {
                item.ClientId = null;
                //item.EmpId = null;
            }
            await _clientsRepository.DeleteAsync(client);
        }

        public async Task<ClientsInfoResponseModel> GetClientDetail(int id)
        {
            var client = await _clientsRepository.GetByIdAsync(id);
            var clientDetail = new ClientsInfoResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
                AddedOn = client.AddedOn
            };
            return clientDetail;
        }

        public async Task<List<ClientsInfoResponseModel>> GetClientList()
        {
            var clients = await _clientsRepository.ListAllAsync();
            List<ClientsInfoResponseModel> clientList = new List<ClientsInfoResponseModel>();
            foreach (var client in clients)
            {
                clientList.Add(new ClientsInfoResponseModel { 
                    Id = client.Id,
                    Name = client.Name,
                    Email = client.Email,
                    Phones = client.Phones,
                    Address = client.Address,
                    AddedOn = client.AddedOn
                });
            }
            return clientList;
        }

        public async Task<ClientsInfoResponseModel> UpdateClientById(int id, ClientRequestModel model)
        {
            var client = await _clientsRepository.GetByIdAsync(id);
            client.Name = model.Name;
            client.Email = model.Email;
            client.Phones = model.Phones;
            client.Address = model.Address;
            client.AddedOn = model.AddedOn;

            var clientsInfo = new ClientsInfoResponseModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                Phones = client.Phones,
                Address = client.Address,
                AddedOn = client.AddedOn
            };

            await _clientsRepository.UpdateAsync(client);

            return clientsInfo;

        }
    }
}
