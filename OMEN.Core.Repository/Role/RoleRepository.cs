using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMEN.Core.IRepository.Role;
using OMEN.Core.Model;
using OMEN.Core.Common;

namespace OMEN.Core.Repository.Role
{
    public class RoleRepository : IRoleRepository
    {
        public List<Roles> GetList(string sql)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        public int Insert(Roles Model)
        {
            string sql = $"insert into Roles values ('{Model.RoleName}',{Model.Sort},'{Model.Remark}')";
            return DapperHelper.Execute(sql);
        }

        public List<Roles> Query(string sql)
        {
            return DapperHelper.GetList<Roles>(sql);
        }

        public int Remove(Roles Model)
        {
            string sql = $"delete from Roles where RoleId={Model.RoleId}";
            return DapperHelper.Execute(sql);
        }

        public int Update(Roles model)
        {
            string sql = $"update Roles set RoleName='{model.RoleName}',Sort={model.Sort},Remaek='{model.Remark}' where RoleId={model.RoleId}";
            return DapperHelper.Execute(sql);
        }
    }
}
