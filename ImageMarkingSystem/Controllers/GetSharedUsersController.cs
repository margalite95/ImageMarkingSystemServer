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
    public class GetSharedUsersController : ControllerBase
    {
        IGetSharedUsersService _getSharedUsersService;
        public GetSharedUsersController(IResolver resolver, IGetSharedUsersService service)
        {
            _getSharedUsersService = service;
        }
        // GET: api/<GetSharedUsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GetSharedUsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GetSharedUsersController>
        [HttpPost]
        public Response GetSharedUsers([FromBody] GetSharedUsersRequest request)
        {
            return _getSharedUsersService.GetSharedUsers(request);
        }

        // PUT api/<GetSharedUsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GetSharedUsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
