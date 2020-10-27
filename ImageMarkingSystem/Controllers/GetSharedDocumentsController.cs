using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIContract;
using ImageMarkingContract.DTO;
using ImageMarkingContract.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageMarkingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetSharedDocumentsController : ControllerBase
    {

        IGetSharedDocumentsService _getSharedDocumentsService;
        public GetSharedDocumentsController(IResolver resolver, IGetSharedDocumentsService service)
        {
            _getSharedDocumentsService = service;
        }

        // GET: api/<GetSharedDocumentsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GetSharedDocumentsController>/5
        [HttpGet("{id}")]
        public Response GetSharedDocument([FromBody] GetSharedDocumentsRequest request)
        {
            return _getSharedDocumentsService.GetSharedDocuments(request);
        }

        // POST api/<GetSharedDocumentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GetSharedDocumentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetSharedDocumentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
