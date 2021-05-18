using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMEN.Core.Model;
using OMEN.Core.IRepository.Role;

namespace OMEN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        public RoleController(IRoleRepository roleRepository)
        {
             _roleRepository = roleRepository;
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        
        [HttpPost]
        [Route("/api/Insert")]

        public int Insert(Roles Model)
        {
            return _roleRepository.Insert(Model);
        }
        /// <summary>
        /// 修改角色
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/Update")]

        public int Update(Roles Model)
        {
            return _roleRepository.Update(Model);
        }

        [HttpGet]
        [Route("/api/Query")]

        public IActionResult Query(/*int page, int limit,*/string roleName="" )
        {
            //List<OMEN.Core.Model.Roles> list = _roleRepository.Query(roleName);
            string sql= $"select * from Roles where roleName like '%{roleName}%'";

            return Ok(new
            {
                msg = "",
                code = 0,
                data = _roleRepository.Query(sql)
            });
        }

        [HttpPost]
        [Route("/api/Rmove")]
        public int Remove([FromForm] int RoleId)
        {
            Roles roles = new Roles() { RoleId = RoleId };
            return _roleRepository.Remove(roles);
        }
    }
}
