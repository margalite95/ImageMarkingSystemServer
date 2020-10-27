using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIContract;
using ImageMarkingContract.DTO.Requests;
using ImageMarkingContract.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageMarkingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateMarkerController : ControllerBase
    {
        ICreateMarkerService _createMarkerService;

        public CreateMarkerController(IResolver resolver, ICreateMarkerService service)
        {
            _createMarkerService = service;
        }
        // GET: api/<CreateMarkerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CreateMarkerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CreateMarkerController>
        [HttpPost]
        public Response CreateMarker([FromBody] CreateMarkerRequest request)
        {
            return _createMarkerService.CreateMarker(request);
        }

        // PUT api/<CreateMarkerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CreateMarkerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
