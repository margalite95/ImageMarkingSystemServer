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
    public class GetDocumentsController : ControllerBase
    {
        // GET: api/<GetDocumentsController>

        IGetDocumentsService _getDocumentsService;
        public GetDocumentsController(IResolver resolver, IGetDocumentsService service)
        {
            _getDocumentsService = service;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GetDocumentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GetDocumentsController>
        [HttpPost]
        public Response GetDocuments([FromBody] GetDocumentsRequest request)
        {
            return _getDocumentsService.GetDocuments(request);
        }

        // PUT api/<GetDocumentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetDocumentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
