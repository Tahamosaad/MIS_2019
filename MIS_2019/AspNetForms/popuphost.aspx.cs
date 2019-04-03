using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MIS_2019.AspNetForms
{
    public partial class popuphost : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            Session["PopUpSQL"] = Request.QueryString.Get("SQL");
        
        }
    }
}