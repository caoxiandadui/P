using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMEN.Core.Common;
using OMEN.Core.IRepository;
using OMEN.Core.IRepository.Menu;

namespace OMEN.Core.Repository.Menu
{
    public class MenuRepository : BaseRepository<OMEN.Core.Model.Menu>, IMenuRepository
    {


        public List<Model.Menu> GetMenuList()
        {
            throw new NotImplementedException();
        }

        public new List<Model.Menu> Query(string sql)
        {
            return DapperHelper.GetList<Model.Menu>(sql);
        }
    }
}
