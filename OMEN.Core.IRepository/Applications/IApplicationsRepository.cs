using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMEN.Core.IRepository.Applications
{
    public interface IApplicationsRepository:IBaseRepository<OMEN.Core.Model.Applications>
    {
        int Upt(OMEN.Core.Model.Applications model);
    }
}
