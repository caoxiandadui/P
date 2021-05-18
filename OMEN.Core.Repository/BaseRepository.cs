using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMEN.Core.Common;
using OMEN.Core.IRepository;

namespace OMEN.Core.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        public List<T> GetList(string sql)
        {
            throw new NotImplementedException();
        }

        public int Insert(T Model)
        {
            throw new NotImplementedException();
        }

        public List<T> Query(string sql)
        {
            return DapperHelper.GetList<T>(sql);
        }

        public int Remove(T Model)
        {
            throw new NotImplementedException();
        }
    }
}
