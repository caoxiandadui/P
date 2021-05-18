                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMEN.Core.Model
{
    public class Menu
    {
        public int MenuID { get; set; }
        public int ModID { get; set; }
        public int ParentID { get; set; }
        public string MenuName { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int Status { get; set; }
        public int Type { get; set; }
        public int Sort { get; set; }
    }
}
