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
    public class UnSubscribeUserController : ControllerBase
    {
        IUnSubscribeUserService _unSubscribeUserService;
        public UnSubscribeUserController(IUnSubscribeUserService service)
        {
            _unSubscribeUserService = service;
        }
        // GET: api/<UnSubscribeUserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UnSubscribeUserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UnSubscribeUserController>
        [HttpPost]
        public Response UnSubscribeUser([FromBody] UnSubscribeUserRequest request)
        {
            return _unSubscribeUserService.UnSubscribeUser(request);
        }

        // PUT api/<UnSubscribeUserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UnSubscribeUserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
