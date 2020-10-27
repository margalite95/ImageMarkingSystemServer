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
    public class EditColorsController : ControllerBase
    {

        IEditColorsService _updateMarkerService;
        public EditColorsController(IResolver resolver, IEditColorsService service)
        {
            _updateMarkerService = service;
        }
        // GET: api/<EditColorsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EditColorsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EditColorsController>
        [HttpPost]
        public Response EditColors([FromBody] EditColorRequest request)
        {
            return _updateMarkerService.EditColors(request);
        }

        // PUT api/<EditColorsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EditColorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
