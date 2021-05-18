using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMEN.Core.IRepository
{
    public interface IBaseRepository<T>
    {
        //基础接口

        //三个方法 增删查
        int Insert(T Model);

        int Remove(T Model);

        List<T> Query(string sql);

    }
}
