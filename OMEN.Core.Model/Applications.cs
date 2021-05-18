using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMEN.Core.Model
{
    public class Applications
    {
        public int ApplicationID { get; set; }
        public int UserID { get; set; }
        public int ApplicationTID { get; set; }
        public string ApplicationTName { get; set; }
        public string BeginTime { get; set; }

        public string EndTime { get; set; }

        public int DayNum { get; set; }
        public int Statu { get; set; }
        public string Reason { get; set; }
        public string Accessory { get; set; }
        public string Approver { get; set; }
        public string InformPerson { get; set; }
    }
}
