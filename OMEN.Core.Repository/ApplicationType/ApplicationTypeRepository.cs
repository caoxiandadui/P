using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMEN.Core.Common;
using OMEN.Core.IRepository.Applications;
using OMEN.Core.IRepository.ApplicationType;

namespace OMEN.Core.Repository.ApplicationType
{
    public class ApplicationTypeRepository : IApplicationTypeRepository
    {
        public int Insert(Model.ApplicationType Model)
        {
            throw new NotImplementedException();
        }

        public List<Model.ApplicationType> Query(string sql)
        {
           
            return  DapperHelper.GetList<Model.ApplicationType>(sql);
        }

        public int Remove(Model.ApplicationType Model)
        {
            throw new NotImplementedException();
        }
    }
}
