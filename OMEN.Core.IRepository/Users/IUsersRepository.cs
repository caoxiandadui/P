using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMEN.Core.IRepository.Users
{
    public interface IUsersRepository :IBaseRepository<OMEN.Core.Model.Users>
    {
        int Update(OMEN.Core.Model.Users Model);
        int Login(string loginName, string pwd);

        List<OMEN.Core.Model.Users> GetUsersList(string UserNameOrPhone);
    }
}
