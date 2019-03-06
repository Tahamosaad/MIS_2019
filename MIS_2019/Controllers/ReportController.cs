using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MIS_2019.Models;
using MIS_2019.App_Start;
using System.Data;
using MIS_2019;
using System.Data.SqlClient;
namespace MIS_2019.Controllers
{[LogActionFilter]
    public class ReportController : Controller

    {
        JEDMISDBEntities db = new JEDMISDBEntities();
        public int ReportId;
        Objects Obj = new Objects();

        List<Paramters> parameters = new List<Paramters>() {
        new Paramters {ReportID=1,RepPath="path1",Dest="dest",Criteria="crit1",CriteriaCap="cap1" },
         new Paramters {ReportID=2,RepPath="path2",Dest="dest2",Criteria="crit2",CriteriaCap="cap2" }
    };
      
        // GET: Report
        public ActionResult ViewReport()
        {
            ViewBag.operation = new SelectList(db.Objects, "ObjectID", "CriteriaFieldsOperators");
            return View();
        }
        [HttpPost]
        public JsonResult SetReport(string ReportName)
        {
            var Criterialist = new List<string>();
            if (!string.IsNullOrWhiteSpace(ReportName))
            {
                Criterialist = LoadCriteria(ReportName);
                if (Criterialist==null)
                {
                    TempData["error"] = "no item found";
                    return null;
                }
                
            }
            return Json(Criterialist, JsonRequestBehavior.AllowGet);
            
        }
        public List<string> LoadCriteria(string MenuTitle) {
            var Criteria = new List<string>();
            var query = db.Objects.Where(x => x.MenuTitle == MenuTitle).FirstOrDefault();
            return query.CriteriaFields.Split(';').ToList();
        }
        public JsonResult GetCriteria()
        {
            List<string> listitems =new List<string>();
            if (!(Request.HttpMethod == "POST"))
            { 
            //var q = (from c in db.Objects
            //         where c.MainMnuName == "MnuRepItems"
            //         select c.MenuTitle);
            DataSet ds = new DataSet();
            ds = DataTools.Execute_SP("SP_SubMnu", "MnuRepItems");
            //ViewBag.Title = query.MenuTitle.Split(';').ToList();
            //ViewBag.Item = db.Items.ToList();
             listitems = ds.Tables[0].AsEnumerable().Select(r => r.Field<string>("MenuTitle")).ToList();}

            return Json(listitems, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetOperation(string Criteria)
        {
            //Criteria = Criteria.Replace("\n", string.Empty);
        
            var operation = new List<string>();
            if (!string.IsNullOrWhiteSpace(Criteria))
            {

              operation =  Loadoperation(Criteria);//to get list of operation depend on selected coloumns

            }
            return Json(operation, JsonRequestBehavior.AllowGet);
        }
        public List<string> Loadoperation(string crit)
        {
            var Criteria = new List<string>();
            var query = db.Objects.Where(x => x.ObjectTitle == crit).FirstOrDefault();
            return query.CriteriaFieldsOperators.Split(';').ToList();
        }

        [HttpGet]
        public JsonResult Get(int id)
        {

            return Json(parameters.FirstOrDefault(x => x.ReportID == id), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAll()
        {

            return Json(parameters, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void ViewReport(Paramters pram)
        {
         

            try
            {
                var query = db.Objects.Where(x => x.ObjectID == pram.ReportID).FirstOrDefault();
       
                ViewBag.Title = query.CriteriaFields.Split(';').ToList();
               
                parameters.Add(pram);
              

                
            }
            catch
            {
               
            }
        }
        protected bool IsPostBack()
        {
            bool isPost = string.Compare(Request.HttpMethod, "POST",
               StringComparison.CurrentCultureIgnoreCase) == 0;
            if (Request.UrlReferrer == null) return false;

            bool isSameUrl = string.Compare(Request.Url.AbsolutePath,
               Request.UrlReferrer.AbsolutePath,
               StringComparison.CurrentCultureIgnoreCase) == 0;

            return isPost && isSameUrl;
        }
    }
}