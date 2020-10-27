using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIContract;
using ImageMarkingContract.DTO.Requests;
using ImageMarkingContract.Interface.BLL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ImageMarkingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetReciversDocsController : ControllerBase
    {

        IGetReciversDocsService _getGetReciversDocsService;
        public GetReciversDocsController(IResolver resolver, IGetReciversDocsService service)
        {
            _getGetReciversDocsService = service;
        }

        // GET: api/<GetReciversDocsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GetReciversDocsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GetReciversDocsController>
        [HttpPost]
        public Response GetReciversDocs([FromBody] GetReciversDocsRequest request)
        {
            return _getGetReciversDocsService.GetReciversDocs(request);
        }
        // PUT api/<GetReciversDocsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetReciversDocsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
