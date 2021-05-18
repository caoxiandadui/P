using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMEN.Core.Common;
using OMEN.Core.IRepository.Applications;

namespace OMEN.Core.Repository.Applications
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        public int Insert(Model.Applications Model)
        {
            string sql = $"insert into Applications select '{Model.UserID}','{Model.ApplicationTID}','{Model.BeginTime}','{Model.EndTime}','{Model.DayNum}','{Model.Statu}','{Model.Reason}','{Model.Accessory}','{Model.Approver}','{Model.InformPerson}' ";
            return new DapperHelper().Add(sql);
        }

        public List<Model.Applications> Query(string sql)
        {
            
            return  DapperHelper.GetList<Model.Applications>(sql);
        }

        public int Remove(Model.Applications Model)
        {
            string sql = $"delete  from Applications where ApplicationID ={Model.ApplicationID} ";
            return new DapperHelper().Delete(sql);
        }

        public int Upt(Model.Applications model)
        {
            string sql =  $"update Applications  set   Statu='{model.Statu}' where   ApplicationID={model.ApplicationID} ";
            return new DapperHelper().Upt(sql);
        }
    }
}
