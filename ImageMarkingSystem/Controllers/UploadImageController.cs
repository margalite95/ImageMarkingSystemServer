using System;
using System.Collections.Generic;
using System.IO;
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
    public class UploadImageController : ControllerBase
    {
        IUploadImageService _uploadImageService;
        public UploadImageController(IUploadImageService service)
        {
            _uploadImageService = service;
        }
        // GET: api/<UploadImageController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UploadImageController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UploadImageController>
        [HttpPost]
        public Response UploadImage([FromForm] UploadImageRequest request)
        {
            return _uploadImageService.UploadImage(request);
            }


        // PUT api/<UploadImageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UploadImageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
