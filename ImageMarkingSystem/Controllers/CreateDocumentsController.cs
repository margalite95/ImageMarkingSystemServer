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
    public class CreateDocumentsController : ControllerBase
    {
        ICreateDocumentsService _createDocumentsService;
       
        public CreateDocumentsController(IResolver resolver, ICreateDocumentsService service)
        {
            _createDocumentsService = service;     
        }

        // GET: api/<CreateDocumentsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CreateDocumentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CreateDocumentsController>
        [HttpPost]
        public Response CreateDocument([FromBody] CreateDocumentsRequest request)
        {
            return _createDocumentsService.CreateDocument(request);
        }

        // PUT api/<CreateDocumentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CreateDocumentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
