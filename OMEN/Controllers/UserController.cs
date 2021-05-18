using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMEN.Core.Common;
using OMEN.Core.IRepository.Users;
using OMEN.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.DrawingCore;
//using System.DrawingCore.Imaging;

namespace OMEN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UserController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        [HttpGet]
        [Route("/api/Login")]
        public IActionResult Login(string loginName,string pwd)
        {
            return Ok(_usersRepository.Login(loginName,pwd));
        }
        [Route("/api/GetUserID")]
        [HttpGet]
        public int GetUserID(string username)
        {
            string sql = $"select * from Users";
            OMEN.Core.Model.Users us = _usersRepository.Query(sql).FirstOrDefault(x => x.LoginName.Equals(username));
            if (us != null)
            {
                return us.UserID;
            }
            else
            {
                return -1;
            }

        }
        [HttpGet]
        [Route("/api/GetUserList")]
        public IActionResult GetUserList(int page, int limit, string userNamePhone = "")
        {

            List<OMEN.Core.Model.Users> list = _usersRepository.GetUsersList(userNamePhone);
            return Ok(new
            {
                msg = "所有数据",
                code = 0,
                count = list.Count,
                data = list.Skip((page - 1) * limit).Take(limit)
            });
        }
        [HttpPost]
        [Route("/api/AddUser")]
        public IActionResult AddUser(OMEN.Core.Model.Users users)
        {
            return Ok();
        }


        
    }
}
