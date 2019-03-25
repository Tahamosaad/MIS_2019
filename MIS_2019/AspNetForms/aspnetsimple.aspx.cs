using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MIS_2019.Controllers;
namespace MIS_2019
{
    public partial class aspnetsimple : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            Controllers.ReportController obj = new ReportController();

            rd.Load(Server.MapPath("~/Reports/") + "itemcard.rpt");
            Viewer.ReportSource = rd;

            //Viewer.ReportSource = obj.ViewReport();
        }
    }
}