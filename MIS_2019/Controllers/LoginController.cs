using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MIS_2019.Models;
using System.Web.Security;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace MIS_2019.Controllers
{
    public class LoginController : Controller

    {
        JEDMISDBEntities db = new JEDMISDBEntities();
        DataTable DT = new DataTable();
      

        //DataRowView row = TryCast(e.Item.DataItem, DataRowView);
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users model)
        {
            

            var userdtls = db.Users.Where(x => x.UserName == model.UserName && x.Password == model.Password).FirstOrDefault();

            if (userdtls == null)
            {
                //Session["userid"] = userdtls.FullName;
                //Session["username"] = userdtls.UserName;
                return Redirect("/Report/ViewReport");
            }

            else
            {

                TempData["NotValidUser"] = "User Does not Exists";
            }

            return View("LoginPage");
        }
        //public void GetMainMnu()
        //{
        //    var mnu = db.Objects.Where(x => x.ObjectType == "R").GroupBy(x => x.MainMnuName).ToList();

        //}
        public string Language
        {
            get
            {
                return Session.SessionID + "Language";
            }
            //set (string value)
            //{
            //  Session(Session.SessionID + "Language") = value;
            //}
        }
        DataTable MenuDic
        {
            get
            {
                if ((Session["MenuDic"] == null))
                {
                    string names = "";
                    foreach (DataRow r in MenuFormsDT.Rows)
                    {
                        
                        names = (names+ (r["MnuName"].ToString() + ";"));
                    }

                    foreach (DataRow r in MenuNamesDT.Rows)
                    {
                        names = (names+ (r["MnuName"].ToString() + ";"));
                    }

                    DataSet ds = DataTools.GetDic(names);
                    Session["MenuDic"] = ds.Tables[0];
                }

                return (Session["MenuDic"]as DataTable);
            }
        }

        DataTable MainMenuDic
        {
            get
            {
                if ((Session["MainMenuDic"] == null))
                {
                    string names = "";
                    foreach (DataRow r in MainMenuFormsDT.Rows)
                    {
                        
                        names = (names + (r["MainMnuName"].ToString() + ";"));
                    }

                    foreach (DataRow r in MainMenuNamesDT.Rows)
                    {
                        names = (names  + (r["MainMnuName"].ToString() + ";"));
                    }

                    DataSet ds = DataTools.GetDic(names);
                    Session["MainMenuDic"] = ds.Tables[0];
                }

                return (Session["MainMenuDic"]as DataTable);
            }
        }

        DataTable MenuFormsDT
        {
            get
            {
                if ((Session["MenuFormsDT"] == null))
                {
                    Session["MenuFormsDT"] = DataTools.DLookUp(DataTools.GetConnectionStr(), "Objects", "MnuName", "ObjectType=\'F\'","" ,"","" ,0, true);
                    // Dim dr As DataRow = Session("MenuFormsDT").NewRow
                    // dr(0) = "Reports"
                    // Session("MenuFormsDT").Rows.Add(dr)
                }

                return (Session["MenuFormsDT"]as DataTable);
            }
        }

        DataTable MainMenuFormsDT
        {
            get
            {
                if ((Session["MainMenuFormsDT"]== null))
                {
                    Session["MainMenuFormsDT"] = DataTools.DLookUp(DataTools.GetConnectionStr(), "Objects", "MainMnuName", "ObjectType=\'F\'","" ,"", "",0, true);
                }

                return (Session["MainMenuFormsDT"] as DataTable);
            }
        }
        DataTable MainMenuNamesDT
        {
            get
            {
                if ((Session["MainMenuNamesDT"] == null))
                {
                    Session["MainMenuNamesDT"] = DataTools.DLookUp(DataTools.GetConnectionStr(), "Objects", "MainMnuName,CASE WHEN Objects.MainMnuName = 'MnuRepSales' THEN 'A1' WHEN Objects.MainMnuName = \'MnuRe" +
                        "pItems' THEN 'A2' WHEN Objects.MainMnuName = 'MnuRepAccounts' THEN 'A3' ELSE Objects.MainMnuName END" + "  AS OrderBy", "ObjectType='R'","","", "OrderBy" ,0, true);
                }

                return (Session["MainMenuNamesDT"]as DataTable);
            }
        }
        DataTable MenuNamesDT
        {
            get
            {
                if ((Session["MenuNamesDT"] == null))
                {
                    Session["MenuNamesDT"] = DataTools.DLookUp(DataTools.GetConnectionStr(), "Objects", "MnuName", "ObjectType=\'R\'", "", "", "", 0, true);
                }

                return Session["MenuNamesDT"] as DataTable;
            }
           
            
        }
        void FillMainFormsMenu()
        {
            Session["MainFormsMenu"] = MainMenuFormsDT;
            
        }

        void FillMainReportsMenu()
        {
            Session["MainReportsMenu"] = MainMenuNamesDT;
        }

        protected void mainrptMenu_ItemDataBound(DataTable dataitem)
        {
            List<string> spanMainRepMenu = new List<string>();
            if (dataitem.Rows.Count < 1)
            {
                return;
            }

            try
            {
                //HtmlGenericControl divRepSubMenu = (HtmlGenericControl)(e.Item.FindControl("divRepSubMenu"));
                foreach (DataRow row in dataitem.Rows)
                {


                    if ((row == null))
                    {
                        return;
                    }

                    if (MainMenuDic != null)
                    {

                        DataRow[] r = MainMenuDic.Select(("FieldName='" + (row["MainMnuName"].ToString() + "'")));
                        if ((r.Length > 0))
                        {
                            if ((Language == "Arabic"))
                            {
                                if ((r[0]["ArabicCap"] == DBNull.Value))
                                {
                                    spanMainRepMenu.Add(r[0]["LatinCap"].ToString());
                                }
                                else
                                {
                                    spanMainRepMenu.Add(r[0]["ArabicCap"].ToString());
                                    // btn.Text = r(0)("LatinCap").ToString()
                                }

                            }
                            else
                            {
                                spanMainRepMenu.Add(r[0]["LatinCap"].ToString());
                                // btnFrmMenu.Text = r(0)("LatinCap").ToString()
                            }

                        }
                        else
                        {
                            // btn.Text = row("MnuName").ToString()
                            spanMainRepMenu.Add(row["MainMnuName"].ToString());
                        }

                    }
                    else
                    {
                        // btn.Text = row("MnuName").ToString()
                        spanMainRepMenu.Add(row["MainMnuName"].ToString());
                    }

                    DT = DataTools.DLookUp(DataTools.GetConnectionStr(), "Objects", "MnuName", ("MainMnuName='" + (row["MainMnuName"].ToString() + "' AND ObjectType='R' ")), "", "", "", 0, true);


                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        [HttpPost]
        public ActionResult LoginPage(Users _login)
        {

            if (ModelState.IsValid) //validating the user inputs
            {
                FillMainFormsMenu();
                FillMainReportsMenu();
                bool isExist = false;
                DataSet report_ds = new DataSet();
                DataSet form_ds = new DataSet();
                List<MainMenuModel> RPT = new List<MainMenuModel>();
                List<MainMenuModel> FRM = new List<MainMenuModel>();

                List<string> _menus2 = new List<string>() ;
                List<string> list = new List<string>();
                using (JEDMISDBEntities _entity = new JEDMISDBEntities())  // out Entity name is "JEDMISDBEntities"
                {
                    //validating the user name in tbl users table whether the user name is exist or not
                    isExist = _entity.Users.Where(x => x.UserName.Trim().ToLower() == _login.UserName.Trim().ToLower()).Any();
                    // Get the login user details and bind it to User class  
                    if (isExist)
                    {
                        UserModel _loginCredentials = _entity.UserRights.Where(x => x.UserName.Trim().ToLower() == _login.UserName.Trim().ToLower())
                            .Select(x => new UserModel
                        {
                            UserName = x.UserName,
                            CanRun = x.CanRun,
                            ObjectID = x.ObjectID,
                            
                           //UserRights = x.UserRights
                            }).FirstOrDefault();

                        Session["UserName"] = _loginCredentials.UserName;
                        //var mnu = db.Objects.Where(x => x.ObjectType == "R").GroupBy(x=>x.MainMnuName).ToList();

                        //Get the Menu details from entity and bind it in MenuModels list.
                        //List<MenuModels> _menus = _entity.Objects.Where(x => x.ObjectType == "R").Select(x => new MenuModels
                        //{
                        //    ObjectID = x.ObjectID,
                        //    ObjectName = x.ObjectName,
                        //    MainMnuName = x.MainMnuName,
                        //    ObjectTitle = x.ObjectTitle,
                        //    MenuIndex = x.MenuIndex,
                        //    MenuTitle = x.MenuTitle,
                        //    MnuName = x.MnuName,
                        //    CriteriaFields = x.CriteriaFields
                        //}).ToList();
            
                        //code goning to be enhance more
                        //here we load all report menus to datatable and save in in mainmenumodel 
                        foreach (DataRow r in MainMenuNamesDT.Rows)
                        {
                            //DT.Clear();
                            DT = DataTools.DLookUp(DataTools.GetConnectionStr(), "SELECT Objects.ObjectName, Objects.ObjectTitle, Objects.ObjectID, Objects.ObjectType, Objects.HlpHtmlFile, dic.LatinCap, dic.ArabicCap FROM Objects INNER JOIN (SELECT DISTINCT TOP 100 PERCENT ObjectID, UserName FROM UserRights WHERE (CanRun = 1) ORDER BY ObjectID, UserName) UR ON UR.ObjectID=Objects.ObjectID LEFT OUTER JOIN dic ON dic.FieldName = Objects.ObjectTitle ", "", "MainMnuName= '" + r["MainMnuName"].ToString() + "' AND UR.UserName='" + Session["UserName"] + "' AND Objects.Visible=1 AND Objects.MenuHidden=0", "", "", "MenuIndex", 0);
                            DT.TableName = r["MainMnuName"].ToString();
                            foreach (DataRow item in MenuDic.Rows)
                            {
                                if (r["MainMnuName"].ToString() == item["FieldName"].ToString())
                                {
                                    DT.TableName = item["LatinCap"].ToString();
                                }


                            }
                            report_ds.Tables.Add(DT);//this dataset save all submenu and name the table with name of menu name  
                            List<string> list2 = DT.AsEnumerable().Select(t => t.Field<string>("LatinCap")).ToList();
                            RPT.Add(new MainMenuModel { MnuName = DT.TableName.ToString(), SubMainName = list2 });


                        }

                        foreach (DataRow r in MainMenuFormsDT.Rows)
                        {
                            //DT.Clear();
                            DT = DataTools.DLookUp(DataTools.GetConnectionStr(), "SELECT Objects.ObjectName, Objects.ObjectTitle, Objects.ObjectID, Objects.ObjectType, Objects.HlpHtmlFile, dic.LatinCap, dic.ArabicCap FROM Objects INNER JOIN (SELECT DISTINCT TOP 100 PERCENT ObjectID, UserName FROM UserRights WHERE (CanRun = 1) ORDER BY ObjectID, UserName) UR ON UR.ObjectID=Objects.ObjectID LEFT OUTER JOIN dic ON dic.FieldName = Objects.ObjectTitle ", "", "MainMnuName= '" + r["MainMnuName"].ToString() + "' AND UR.UserName='" + Session["UserName"] + "' AND Objects.Visible=1 AND Objects.MenuHidden=0", "", "", "MenuIndex", 0);
                            DT.TableName = r["MainMnuName"].ToString();
                            foreach (DataRow item in MainMenuDic.Rows)
                            {
                                if (r["MainMnuName"].ToString() == item["FieldName"].ToString())
                                {
                                    DT.TableName = item["LatinCap"].ToString();
                                }


                            }
                            form_ds.Tables.Add(DT);
                            List<string> list2 = DT.AsEnumerable().Select(t => t.Field<string>("LatinCap")).ToList();
                            FRM.Add(new MainMenuModel { MnuName = DT.TableName.ToString(), SubMainName = list2 });


                        }
                        
                        FormsAuthentication.SetAuthCookie(_loginCredentials.UserName, false); // set the formauthentication cookie
                        Session["LoginCredentials"] = _loginCredentials; // Bind the _logincredentials details to "LoginCredentials" session
                        Session["ReportMenu"] = RPT; //Bind the _menus list to MenuMaster session
                        Session["FormMenu"] = FRM;


                        return RedirectToAction("ViewReport", "Report");
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Please enter the valid credentials!...";
                        return View();
                    }
                }
            }
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Login", "Login");
        }
        public ActionResult Logout()
        {
            //int userid = (int)Session["userid"];
            //Session.Abandon();
            return RedirectToAction("LoginPage", "Login");
        }
    }
}