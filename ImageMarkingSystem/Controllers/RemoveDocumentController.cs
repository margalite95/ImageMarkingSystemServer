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
    public class RemoveDocumentController : ControllerBase
    {
        // GET: api/<RemoveDocumentController>


        IRemoveDocumentService _removeDocumentService;
        public RemoveDocumentController(IResolver resolver, IRemoveDocumentService service)
        {
            _removeDocumentService = service;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RemoveDocumentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RemoveDocumentController>
        [HttpPost]
        public Response RemoveDocument([FromBody] RemoveDocumentsRequest request)
        {
            return _removeDocumentService.RemoveDocument(request);
        }


        // PUT api/<RemoveDocumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RemoveDocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
