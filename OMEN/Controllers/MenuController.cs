using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMEN.Core.IRepository;
using OMEN.Core.IRepository.Menu;
using OMEN.Core.Repository;


namespace OMEN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IBaseRepository<OMEN.Core.Model.Menu> _menuRepository;
        public MenuController(IBaseRepository<OMEN.Core.Model.Menu> menuRepository)
        {
            _menuRepository = menuRepository;

        }
        [HttpGet]
        [Route("/api/ListMenu")]
        public IActionResult GetListMenu(/*int page, int limit*/)
        {
            string sql = "select * from Menu order by sort";
            var list = _menuRepository.Query(sql);
            return Ok(new
            {
                msg = "菜单",
                code = 0,
                data = list/*.Skip((page - 1) * limit).Take(limit)*/
            }) ;
        }
        
    }
}
