using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMEN.Core.Common;
using OMEN.Core.IRepository.Users;

namespace OMEN.Core.Repository.Users
{
    public class UserRepository : IUsersRepository
    {
        public List<Model.Users> GetList(string sql)
        {
            throw new NotImplementedException();
        }

        public List<Model.Users> GetUsersList(string UserNameOrPhone)
        {
            
            List<OMEN.Core.Model.Users> list = new List<Model.Users>();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select
                           Users.UserID,Users.UserName,Users.LoginName,Department.DeptName,Users.Birthday,Users.Email,Users.Gender
                           from Users join Department
                           on Users.DeptID=Department.DeptID where 1=1");
                if (!string.IsNullOrEmpty(UserNameOrPhone))
                {
                    sb.Append($"and(Users.UserName like '%{UserNameOrPhone}%' or Users.Phone='{UserNameOrPhone}')");

                }
                list = DapperHelper.GetList<OMEN.Core.Model.Users>(sb.ToString());
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }

        public int Insert(Model.Users Model)
        {
            Model.Pwd = DESEncrypt.GetMd5Str(Model.Pwd);
            string sql = $"insert into   Users  values ('{Model.DeptID}','{Model.UserCode}','{Model.FirstPY}','{Model.LoginName}','{Model.Pwd}','{Model.UserName}','{Model.UserType}','{Model.Gender}','{Model.Birthday}','{Model.Email}','{Model.Tel}','{Model.Phone}','{Model.QQ}','{Model.Description}','{Model.ProFessTitle}','{Model.IDCard}','{Model.NativePlace}','{Model.HomeAddress}','{Model.Nation}','{Model.Major}','{Model.Education}','{Model.School}','{Model.Degree}','{Model.JoinInDate}','{Model.DimissionDate}','{Model.DimissionCause}','{Model.DeleteMark}','1','1','1','系统管理员','{DateTime.Now}' ) ";

            return new DapperHelper().Add(sql);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns></returns>
        public int Login(string loginName, string pwd)
        {
            object result = DapperHelper.Scalar($"select count(1) from Users where LoginName='{loginName}' and pwd='{pwd}'");
            return result == null ? 0 : 1;
        }

        public List<Model.Users> Query(string sql)
        {
            throw new NotImplementedException();
        }

        public int Remove(Model.Users Model)
        {
            string sql = $"delete from users where userid={Model.UserID}";
            return new DapperHelper().Delete(sql);
        }

        public int Update(Model.Users Model)
        {
            Model.Pwd = DESEncrypt.GetMd5Str(Model.Pwd);
            string sql = $"update   Users  set DeptID='{Model.DeptID}',UserCode='{Model.UserCode}',FirstPY='{Model.FirstPY}',LoginName='{Model.LoginName}',Pwd='{Model.Pwd}',UserName='{Model.UserName}',UserType='{Model.UserType}',Gender='{Model.Gender}',Birthday='{Model.Birthday}',Email='{Model.Email}',Tel='{Model.Tel}',Phone='{Model.Phone}',QQ='{Model.QQ}',Description='{Model.Description}',ProFessTitle='{Model.ProFessTitle}',IDCard='{Model.IDCard}',NativePlace='{Model.NativePlace}',HomeAddress='{Model.HomeAddress}',Nation='{Model.Nation}',Major='{Model.Major}',Education='{Model.Education}',School='{Model.School}',Degree='{Model.Degree}',JoinInDate='{Model.JoinInDate}',DimissionCause='{Model.DimissionCause}',DeleteMark='{Model.DeleteMark}',IsAdmin='1',Status='{Model.Status}',CreateID='1',createname='系统管理员',createdate='{DateTime.Now}' where userid={Model.UserID}  ";
            return new DapperHelper().Upt(sql);
        }
        public int updatePWd(Model.Users Model)
        {
            Model.Pwd = DESEncrypt.GetMd5Str(Model.Pwd);
            string sql = $"update Users set Pwd='{Model.Pwd}' where userid={Model.UserID}";
            return new DapperHelper().Upt(sql);
        }
    }
}
