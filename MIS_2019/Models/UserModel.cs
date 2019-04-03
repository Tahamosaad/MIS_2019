
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIS_2019.Models
{
    public class UserModel
    {

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        public int ObjectID { get; set; }
        public string BranchCode { get; set; }
        public bool CanRun { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanPrint { get; set; }
        public bool CanBrows { get; set; }
        public Nullable<bool> AllBranches { get; set; }
        public string ServerCode { get; set; }
        public Nullable<System.DateTime> AccessDate { get; set; }

        public virtual Objects Objects { get; set; }
        public virtual Users Users { get; set; }
        //public int? UserRoleId { get; set; }
        //public string RoleName { get; set; }
        //public string ObjectID { get; set; }
        //public string CanRun { get; set; }


    }
}