using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMEN.Core.IRepository.Menu
{
    public interface IMenuRepository
    {
        List<OMEN.Core.Model.Menu> GetMenuList();
    }
}
