using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMEN.Core.IRepository;
using OMEN.Core.IRepository.Users;

namespace OMEN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IBaseRepository<OMEN.Core.Model.Users> _user;
        private IUsersRepository _us;

        public TestController(IBaseRepository<OMEN.Core.Model.Users> user, IUsersRepository us)
        {
            _us = us;
            _user = user;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            _us.Query("");
            return "";
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
