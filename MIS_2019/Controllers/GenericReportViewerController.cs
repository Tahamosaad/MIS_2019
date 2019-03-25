using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;


namespace MIS_2019.Controllers
{
    public class GenericReportViewerController : Controller
    {
        //
        // GET: /GenericReportViewer/

        public ActionResult Index()
        {
            return View();
        }

        
        public void ShowGenericRpt()
        {
            try
            {
                bool isValid = true;

                //string strReportName = System.Web.HttpContext.Current.Session["ReportName"].ToString();    // Setting ReportName
          
                var rptSource = System.Web.HttpContext.Current.Session["rptSource"];

                if ((rptSource)==null)
                {
                    isValid = false;
                }

                if (isValid)
                {
                    ReportDocument rd = new ReportDocument();
                    rd =(ReportDocument) rptSource;
         
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");

                  
                }
                else
                {
                    Response.Write("<H2>Nothing Found; No Report name found</H2>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}
