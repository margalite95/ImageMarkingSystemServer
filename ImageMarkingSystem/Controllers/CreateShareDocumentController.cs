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
    public class CreateShareDocumentController : ControllerBase
    {

        ICreateShareDocumentService _createShareDocumentsService;
        public CreateShareDocumentController(IResolver resolver, ICreateShareDocumentService service)
        {
            _createShareDocumentsService = service;
        }


        // GET: api/<CreateShareDocumentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CreateShareDocumentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CreateShareDocumentController>
        [HttpPost]
        public Response CreateDocument([FromBody] CreateShareDocumentRequest request)
        {
            return _createShareDocumentsService.CreateShareDocument(request);
        }

        // PUT api/<CreateShareDocumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CreateShareDocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
