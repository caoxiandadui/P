using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMEN.Core.Model
{
    public class OperateLog
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string IP { get; set; }
        public int OperateType { get; set; }
        public DateTime OperateTime { get; set; }
        public string MenuName { get; set; }
        public string Describe { get; set; }
    }
}
