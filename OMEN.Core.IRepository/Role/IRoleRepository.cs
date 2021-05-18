using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMEN.Core.IRepository.Role
{
    public interface IRoleRepository : IBaseRepository<OMEN.Core.Model.Roles>
    {
        int Update(OMEN.Core.Model.Roles model);
    }
}
