using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMEN.Core.Model
{
    public class Notice
    {
        public int NtID { get; set; }
        public string NtTitle { get; set; }
        public int NtType { get; set; }
        public string NtContent { get; set; }
        public int CreateID { get; set; }
        public string CreateName { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
