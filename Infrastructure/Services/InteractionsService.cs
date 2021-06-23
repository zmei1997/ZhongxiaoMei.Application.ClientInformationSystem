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
    public class InteractionsService : IInteractionsService
    {
        private readonly IInteractionsRepository _interactionsRepository;
        private readonly IClientsRepository _clientsRepository;
        private readonly IEmployeesRepository _employeesRepository;
        public InteractionsService(IInteractionsRepository interactionsRepository, IClientsRepository clientsRepository, IEmployeesRepository employeesRepository)
        {
            _interactionsRepository = interactionsRepository;
            _clientsRepository = clientsRepository;
            _employeesRepository = employeesRepository;
        }

        public async Task<InteractionsResponseModel> AddInteraction(InteractionRequestModel model)
        {
            var interaction = new Interaction
            {
                ClientId = model.ClientId,
                EmpId = model.EmpId,
                IntType = model.IntType,
                IntDate = model.IntDate,
                Remarks = model.Remarks
            };

            var newInteraction = new InteractionsResponseModel
            {
                Id = interaction.Id,
                ClientId = interaction.ClientId,
                EmpId = interaction.EmpId,
                IntType = interaction.IntType,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks
            };
            await _interactionsRepository.AddAsync(interaction);
            return newInteraction;
        }

        public async Task DeleteInteraction(int id)
        {
            var interaction = await _interactionsRepository.GetByIdAsync(id);
            await _interactionsRepository.DeleteAsync(interaction);
        }

        public async Task<InteractionsResponseModel> GetInteractionDetail(int id)
        {
            var interaction = await _interactionsRepository.GetByIdAsync(id);
            var intrDetail = new InteractionsResponseModel
            {
                Id = interaction.Id,
                ClientId = interaction.ClientId,
                EmpId = interaction.EmpId,
                IntType = interaction.IntType,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks
            };
            return intrDetail;
        }

        public async Task<List<InteractionsResponseModel>> GetInteractions()
        {
            var interactions = await _interactionsRepository.GetInteractionsWithClientAndEmployee();
            List<InteractionsResponseModel> interactionList = new List<InteractionsResponseModel>();
            foreach (var interaction in interactions)
            {
                var model = new InteractionsResponseModel();
                model.Id = interaction.Id;
                model.ClientId = interaction.ClientId;
                if (interaction.ClientId != null)
                {
                    model.ClientName = interaction.Client.Name;
                }
                model.EmpId = interaction.EmpId;
                if (interaction.EmpId != null)
                {
                    model.EmployeeName = interaction.Emp.Name;
                }
                model.IntType = interaction.IntType;
                model.IntDate = interaction.IntDate;
                model.Remarks = interaction.Remarks;
                interactionList.Add(model);
            }
            return interactionList;
        }

        public async Task<List<InteractionsResponseModel>> GetInteractionsByClientId(int id)
        {
            var interactions = await _interactionsRepository.GetInteractionsByClientId(id);
            List<InteractionsResponseModel> interactionList = new List<InteractionsResponseModel>();
            foreach (var interaction in interactions)
            {
                var model = new InteractionsResponseModel();
                model.Id = interaction.Id;
                model.ClientId = interaction.ClientId;
                if (interaction.ClientId != null)
                {
                    model.ClientName = interaction.Client.Name;
                }
                model.EmpId = interaction.EmpId;
                if (interaction.EmpId != null)
                {
                    model.EmployeeName = interaction.Emp.Name;
                }
                model.IntType = interaction.IntType;
                model.IntDate = interaction.IntDate;
                model.Remarks = interaction.Remarks;
                interactionList.Add(model);
            }
            return interactionList;
        }

        public async Task<List<InteractionsResponseModel>> GetInteractionsByEmployeeId(int id)
        {
            var interactions = await _interactionsRepository.GetInteractionsByEmployeeId(id);
            List<InteractionsResponseModel> interactionList = new List<InteractionsResponseModel>();
            foreach (var interaction in interactions)
            {
                var model = new InteractionsResponseModel();
                model.Id = interaction.Id;
                model.ClientId = interaction.ClientId;
                if (interaction.ClientId != null)
                {
                    model.ClientName = interaction.Client.Name;
                }
                model.EmpId = interaction.EmpId;
                if (interaction.EmpId != null)
                {
                    model.EmployeeName = interaction.Emp.Name;
                }
                model.IntType = interaction.IntType;
                model.IntDate = interaction.IntDate;
                model.Remarks = interaction.Remarks;
                interactionList.Add(model);
            }
            return interactionList;
        }

        public async Task<InteractionsResponseModel> UpdateInteraction(int id, InteractionRequestModel model)
        {
            var interaction = await _interactionsRepository.GetByIdAsync(id);
            interaction.ClientId = model.ClientId;
            interaction.EmpId = model.EmpId;
            interaction.IntType = model.IntType;
            interaction.IntDate = model.IntDate;
            interaction.Remarks = model.Remarks;

            var updatedInteraction = new InteractionsResponseModel
            {
                Id = interaction.Id,
                ClientId = interaction.ClientId,
                EmpId = interaction.EmpId,
                IntType = interaction.IntType,
                IntDate = interaction.IntDate,
                Remarks = interaction.Remarks
            };

            await _interactionsRepository.UpdateAsync(interaction);

            return updatedInteraction;
        }
    }
}
