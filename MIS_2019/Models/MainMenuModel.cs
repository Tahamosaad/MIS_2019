using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MIS_2019.Models
{
    public class MainMenuModel
    {

        public string MnuName { get; set; }
        //public List <int> SubMainId { get; set; }
        public List<string> SubMainName { get; set; }
        public Dictionary<int,string> Rep_submnu { get; set; }
        public Dictionary<int, string> Frm_submnu { get; set; }
    }
}