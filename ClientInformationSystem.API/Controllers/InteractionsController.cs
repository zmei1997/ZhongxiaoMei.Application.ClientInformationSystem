using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models.Request;

namespace ClientInformationSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InteractionsController : ControllerBase
    {
        private readonly IInteractionsService _interactionsService;

        public InteractionsController(IInteractionsService interactionsService)
        {
            _interactionsService = interactionsService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetInteractions()
        {
            var interactions = await _interactionsService.GetInteractions();
            if (interactions.Any())
            {
                return Ok(interactions);
            }
            return NotFound("Interaction Not Found");
        }

        [HttpGet]
        [Route("Client/{id:int}")]
        public async Task<IActionResult> GetInteractionsByClientId(int id)
        {
            var interactions = await _interactionsService.GetInteractionsByClientId(id);
            if (interactions.Any())
            {
                return Ok(interactions);
            }
            return NotFound("Interaction Not Found");
        }

        [HttpGet]
        [Route("Employee/{id:int}")]
        public async Task<IActionResult> GetInteractionsByEmployeeId(int id)
        {
            var interactions = await _interactionsService.GetInteractionsByEmployeeId(id);
            if (interactions.Any())
            {
                return Ok(interactions);
            }
            return NotFound("Interaction Not Found");
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddInteraction([FromBody] InteractionRequestModel model)
        {
            var interaction = await _interactionsService.AddInteraction(model);
            return Ok(interaction);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateInteraction(int id, [FromBody] InteractionRequestModel model)
        {
            var interaction = await _interactionsService.UpdateInteraction(id, model);
            return Ok(interaction);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteInteraction(int id)
        {
            await _interactionsService.DeleteInteraction(id);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetInteractionDetail(int id)
        {
            var interactions = await _interactionsService.GetInteractionDetail(id);
            if (interactions != null)
            {
                return Ok(interactions);
            }
            return NotFound("Interaction Not Found");
        }
    }
}
