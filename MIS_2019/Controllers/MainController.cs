using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MIS_2019.Controllers
{
    public class MainController : Controller
    {
        private static List<Craiteria> criteria = new List<Craiteria>()
        {
            new Craiteria {Id = 1,name="Morethan" },
        new Craiteria {Id =2,name="Lessthan"}
        };
    
        [HttpGet]
    public JsonResult Get(int id)
    {

            return Json(criteria.FirstOrDefault(x => x.Id == id), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetAll()
        {

            return Json(criteria, JsonRequestBehavior.AllowGet);
        }
        [HttpPut]
        public void Add(Craiteria cri) {
            criteria.Add(cri);
        }
        [HttpPost]
        public void modify(Craiteria cri)
        {
            criteria.RemoveAll(x => x.Id == cri.Id);
            criteria.Add(cri);
        }
        [HttpDelete]
        public void delete (int id)
        {
            criteria.RemoveAll(x => x.Id == id);
        }
        public class Craiteria
    {
        public int Id { get; set; }
        public string name { get; set; }
    }
    }
}