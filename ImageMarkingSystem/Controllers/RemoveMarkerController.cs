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
    public class RemoveMarkerController : ControllerBase
    {

        IRemoveMarkerService _removeMarkerService;
        public RemoveMarkerController(IResolver resolver, IRemoveMarkerService service)
        {
            _removeMarkerService = service;
        }
        // GET: api/<RemoveMarkerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RemoveMarkerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RemoveMarkerController>
        [HttpPost]
        public Response RemoveMarker([FromBody] RemoveMarkerRequest request)
        {
            return _removeMarkerService.RemoveMarker(request);
        }

        // PUT api/<RemoveMarkerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RemoveMarkerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
