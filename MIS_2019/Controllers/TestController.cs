using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MIS_2019.Models;
namespace MIS_2019.Controllers
{
    public class TestController : Controller
    {
        JEDMISDBEntities db = new JEDMISDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        // GET: Test
        public JsonResult GetCountries()
        {
            var Countries = new List<string>();
            var query = db.Objects.Where(x => x.ObjectID == 11).FirstOrDefault();

            ViewBag.Title = query.CriteriaFields.Split(';').ToList();
            ViewBag.Item = db.Items.ToList();
           
            return Json(query.CriteriaFields.Split(';').ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetStates(string country)
        {
            var States = new List<string>();
            if (!string.IsNullOrWhiteSpace(country))
            {
                if (country.Equals("Australia"))
                {
                    States.Add("Sydney");
                    States.Add("Perth");
                }
                if (country.Equals("India"))
                {
                    States.Add("Delhi");
                    States.Add("Mumbai");
                }
                if (country.Equals("Russia"))
                {
                    States.Add("Minsk");
                    States.Add("Moscow");
                }
            }
            return Json(States, JsonRequestBehavior.AllowGet);
        }
    }
}