using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClientController : ControllerBase
    {
        private readonly IClientManager ClientManager;
        public ClientController(IClientManager ClientManager)
        {
            this.ClientManager = ClientManager;
        }
        /// <summary>
        /// Gets all phone numbers that are close to the given phone number according to the given sensitivity
        /// </summary>
        /// <remarks>
        /// Use this endpoint to suggest to the user the phone number that is being typed.<br/>
        /// The sensitivity is the smallests amount of changes that can happen to any phone number to become exactly like the one you inserted
        /// </remarks>
        /// <param name="request">The suspect phone number</param>
        /// <response code="200">Found close matches for the given sensitivity</response>
        /// <response code="404">No close matches found</response>
        [ProducesResponseType(200, Type = typeof(GetCloseMatchesResponse))]
        [ProducesResponseType(404, Type = null)]
        [Authorize(Roles = "Admin")]
        [HttpGet("GetCloseMatches")]
        public IActionResult GetCloseMatches([FromBody]GetCloseMatchesRequest request)
        {
            IEnumerable<string> res = ClientManager.GetCloseMatches(request.Phonenumber, request.Sensitivity);
            if (res.Count() == 0) return NotFound();
            return Ok(new GetCloseMatchesResponse { Phonenumbers = res });
        }
    }
}