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
    public class RemoveShareDocumentController : ControllerBase
    {

        IRemoveShareDocumentService _removeShareDocumentsService;
        public RemoveShareDocumentController(IResolver resolver, IRemoveShareDocumentService service)
        {
            _removeShareDocumentsService = service;
        }
        // GET: api/<RemoveShareDocumentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RemoveShareDocumentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RemoveShareDocumentController>
        [HttpPost]
        public Response RemoveShareDocument([FromBody] RemoveSharedDocumentsRequest request)
        {
            return _removeShareDocumentsService.RemoveSharedDocuments(request);
        }

        // PUT api/<RemoveShareDocumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RemoveShareDocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
