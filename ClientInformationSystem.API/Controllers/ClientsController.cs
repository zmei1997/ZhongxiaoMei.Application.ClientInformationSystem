using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
using ApplicationCore.Models.Request;

namespace ClientInformationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;
        private readonly IInteractionsService _interactionsService;
        public ClientsController(IClientsService clientsService, IInteractionsService interactionsService)
        {
            _clientsService = clientsService;
            _interactionsService = interactionsService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await _clientsService.GetClientList();
            if (clients.Any())
            {
                return Ok(clients);
            }
            return NotFound("Client Not Found");
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetClientDetail(int id)
        {
            var client = await _clientsService.GetClientDetail(id);
            if (client != null)
            {
                return Ok(client);
            }
            return NotFound("Client Not Found");
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddClient([FromBody] ClientRequestModel model)
        {
            var newClient = await _clientsService.AddClient(model);
            return Ok(newClient);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _clientsService.DeleteClientById(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientRequestModel model)
        {
            var clientUpdated = await _clientsService.UpdateClientById(id, model);
            return Ok(clientUpdated);
        }
    }
}
