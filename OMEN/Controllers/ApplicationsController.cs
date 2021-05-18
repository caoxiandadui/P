using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMEN.Core.IRepository.Applications;
using OMEN.Core.IRepository.ApplicationType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMEN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private IApplicationsRepository _ia;
        private IApplicationTypeRepository _iat;
        public ApplicationsController(IApplicationsRepository ia, IApplicationTypeRepository iat)
        {
            _ia = ia;
            _iat = iat;
        }
        #region  绑定下拉
        /// <summary>
        /// 显示所有的申请
        /// </summary>
        /// <returns></returns>

        [Route("/api/BindAppType")]
        [HttpGet]
        public IActionResult BindAppType()
        {
            string sql = $"select * from ApplicationType";
           
            List<OMEN.Core.Model.ApplicationType> lat = _iat.Query(sql);

            return Ok(new { data = lat, code = 0 });
        }
        #endregion

        #region  显示一个反填
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="applicationid"></param>
        /// <returns></returns>
        [Route("/api/ShowApplicationOne")]
        [HttpGet]
        public IActionResult ShowApplicationOne(int applicationid)
        {
            string sql = $"select a.*,b.ApplicationTName  from Applications a join ApplicationType b on a.ApplicationTID=b.ApplicationTID";
            List<OMEN.Core.Model.Applications> la = _ia.Query(sql);
            la = la.Where(x => x.ApplicationID.Equals(applicationid)).ToList();
            return Ok(new { data = la, code = 0 });
        }
        #endregion

        #region 添加 
        /// <summary>
        /// 添加申请
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/AddApplication")]
        public int AddApplication(OMEN.Core.Model.Applications model)
        {
            return _ia.Insert(model);
        }
        #endregion

        #region  删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/DelApplication")]
        public int DelApplication(OMEN.Core.Model.Applications model)
        {
            return _ia.Remove(model);
        }
        #endregion

        #region 修改 
        /// <summary>
        /// 修改部门
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/UptApplication")]
        public int UptApplication(OMEN.Core.Model.Applications model)
        {
            return _ia.Upt(model);
        }
        #endregion

        #region  显示当前用户的所有申请
        /// <summary>
        /// 显示所有的申请
        /// </summary>
        /// <returns></returns>

        [Route("/api/ShowApplication")]
        [HttpGet]
        public IActionResult ShowApplication(int applicationid = 0, int typeid = 0, int state = -1, int userid = 0)
        {
            string sql = $"select a.*,b.ApplicationTName  from Applications a join ApplicationType b on a.ApplicationTID=b.ApplicationTID";
            List<OMEN.Core.Model.Applications> la = _ia.Query(sql);
            la = la.Where(x => x.UserID.Equals(userid)).ToList();
            if (applicationid != 0)
            {
                la = la.Where(x => x.ApplicationID.Equals(applicationid)).ToList();
            }
            if (typeid != 0)
            {
                la = la.Where(x => x.ApplicationTID.Equals(typeid)).ToList();
            }
            if (state != -1)
            {
                la = la.Where(x => x.Statu.Equals(state)).ToList();
            }
            return Ok(new { data = la, code = 0 });
        }
        #endregion

        #region  显示当前用户的（负责）需要审批的申请
        /// <summary>
        /// 显示所有的申请
        /// </summary>
        /// <returns></returns>

        [Route("/api/ShowApplicationByPre")]
        [HttpGet]
        public IActionResult ShowApplicationByPre(int applicationid = 0, int typeid = 0, int state = -1, int userid = 0)
        {
            string sql = $"select a.*,b.ApplicationTName  from Applications a join ApplicationType b on a.ApplicationTID=b.ApplicationTID";
            List<OMEN.Core.Model.Applications> la = _ia.Query(sql);
            la = la.Where(x => x.Approver.Equals(userid.ToString())).ToList();
            if (applicationid != 0)
            {
                la = la.Where(x => x.ApplicationID.Equals(applicationid)).ToList();
            }
            if (typeid != 0)
            {
                la = la.Where(x => x.ApplicationTID.Equals(typeid)).ToList();
            }
            if (state != -1)
            {
                la = la.Where(x => x.Statu.Equals(state)).ToList();
            }
            return Ok(new { data = la, code = 0 });
        }
        #endregion
    }
}
