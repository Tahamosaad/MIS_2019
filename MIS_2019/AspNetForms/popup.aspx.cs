using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MIS_2019.AspNetForms
{
    public partial class popup : System.Web.UI.Page
    {
        int CurrentPage = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
            DataGrid1.CurrentPageIndex = 0;
             BindGrid(true);
            }
        }
        public void PagerButtonClick(string arg)
        {
            switch (arg)
            {
                case "next": // The next Button was Clicked
                        CurrentPage = Int32.Parse(lblPage.Text) + 1;
                     break;
                case "prev" : // The prev button was clicked
                        CurrentPage = Int32.Parse(lblPage.Text) - 1;
                        break;
                case "last": // The Last Page button was clicked
                        CurrentPage = Int32.Parse(lblPageCount.Text);
                        break;
                case "first" : // The First Page button was clicked
                        CurrentPage = 1;
                        break;
                    
            }
            if (CurrentPage < 1)
                CurrentPage = Int32.Parse(lblPageCount.Text);
            else if (CurrentPage > Int32.Parse(lblPageCount.Text))
                CurrentPage = 1;
            // Now, bind the data!
            BindGrid();
        }

        private void BindGrid(bool FillData = false)
        {
            string SQL = Session["PopUpSQL"].ToString();
            // Warning!!! Optional parameters not supported
            int i=0;
            HyperLinkColumn C = new HyperLinkColumn();
            SqlDataAdapter daList = new SqlDataAdapter(SQL, DataTools.GetConnectionStr());
            DataSet dsList = new DataSet();
            if (FillData)
            {
                daList.Fill(dsList);
                Session["dsList"] = dsList;
            }
            else
            {
                dsList =(DataSet) Session["dsList"];
            }

            C.HeaderText = dsList.Tables[0].Columns[i].ColumnName;
            C.DataNavigateUrlField = dsList.Tables[0].Columns[0].ColumnName;
            // C.DataNavigateUrlFormatString = "JavaScript:setTextContent(window.parent.opener.document.getElementById('txtValue'),'{0}');top.returnValue='{0}';top.window.close();"
            C.DataNavigateUrlFormatString = "JavaScript:window.parent.opener.setTargetField(\'{0}\');top.returnValue=\'{0}\';top.window.close();";
            C.DataTextField = dsList.Tables[0].Columns[0].ColumnName;
            C.ItemStyle.ForeColor = System.Drawing.Color.Blue;
            DataGrid1.Columns.Add(C);
            for (i = 0; (i
                        <= (dsList.Tables[0].Columns.Count - 1)); i++)
            {
                if ((i > 0))
                {
                    BoundColumn cln = new BoundColumn();
                    cln.HeaderText = dsList.Tables[0].Columns[i].ColumnName;
                    cln.DataField = dsList.Tables[0].Columns[i].ColumnName;
                    DataGrid1.Columns.Add(cln);
                }

            }

            //if ((Session[(Session.SessionID + "Language")].ToString() == "Arabic"))
            //{
            //    // pageBody.Attributes.Add("dir", "rtl")
            //    //DataTools.Translate(DataGrid1, true);
            //}

            DataGrid1.DataSource = Session["dsList"];
            DataGrid1.CurrentPageIndex = (CurrentPage - 1);
            DataGrid1.DataBind();
            lblPageCount.Text = DataGrid1.PageCount.ToString();
            lblPage.Text = (DataGrid1.CurrentPageIndex.ToString() + 1);
        }
        protected void butNext_Click(object sender, ImageClickEventArgs e)
        {
            PagerButtonClick("Next");

        }

        protected void butLast_Click(object sender, ImageClickEventArgs e)
        {
            PagerButtonClick("Last");

        }

        protected void butPrev_Click(object sender, ImageClickEventArgs e)
        {
            PagerButtonClick("Prev");

        }

        protected void butFirst_Click(object sender, ImageClickEventArgs e)
        {
            PagerButtonClick("First");

        }
    }
}