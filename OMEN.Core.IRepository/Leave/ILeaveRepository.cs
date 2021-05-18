using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMEN.Core.IRepository.Leave
{
    public interface ILeaveRepository 
    {
        int Update(OMEN.Core.Model.Users Model);
        List<OMEN.Core.Model.Applications> GetList();
    }
}
