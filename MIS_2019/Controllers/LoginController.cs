using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MIS_2019.Models;
using System.Web.Security;
using System.Data;

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
        public void GetMainMnu()
        {
            var mnu = db.Objects.Where(x => x.ObjectType == "R").GroupBy(x => x.MainMnuName).ToList();
            
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


        [HttpPost]
        public ActionResult LoginPage(Users _login)
        {

            if (ModelState.IsValid) //validating the user inputs
            {
                FillMainFormsMenu();
                FillMainReportsMenu();
                bool isExist = false;
                DataSet ds = new DataSet();
                List<MainMenuModel> MN = new List<MainMenuModel>();
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
                        var mnu = db.Objects.Where(x => x.ObjectType == "R").GroupBy(x=>x.MainMnuName).ToList();
                       
                        

                        //Get the Menu details from entity and bind it in MenuModels list.
                        List<MenuModels> _menus = _entity.Objects.
                            Select(x => new MenuModels
                        {
                            ObjectID = x.ObjectID,
                            ObjectName = x.ObjectName,
                            MainMnuName = x.MainMnuName,
                            ObjectTitle = x.ObjectTitle,
                            MenuIndex = x.MenuIndex,
                            MenuTitle = x.MenuTitle,
                            MnuName = x.MnuName,
                            CriteriaFields = x.CriteriaFields
                        }).ToList();
                        //load sub menu 

                        foreach (DataRow r in MainMenuNamesDT.Rows)
                        {
                            DT.TableName = r["MainMnuName"].ToString();
                            DT = DataTools.DLookUp(DataTools.GetConnectionStr(), "SELECT Objects.ObjectName, Objects.ObjectTitle, Objects.ObjectID, Objects.ObjectType, Objects.HlpHtmlFile, dic.LatinCap, dic.ArabicCap FROM Objects INNER JOIN (SELECT DISTINCT TOP 100 PERCENT ObjectID, UserName FROM UserRights WHERE (CanRun = 1) ORDER BY ObjectID, UserName) UR ON UR.ObjectID=Objects.ObjectID LEFT OUTER JOIN dic ON dic.FieldName = Objects.ObjectTitle ", "", "MnuName= '" + r["MainMnuName"].ToString() + "' AND UR.UserName='" + Session["UserName"] + "' AND Objects.Visible=1 AND Objects.MenuHidden=0", "", "", "MenuIndex", 0);

                            ds.Tables.Add(DT);
                            List<string> list2 = DT.AsEnumerable().Select(t => t.Field<string>("LatinCap")).ToList();
                            MN.Add(new MainMenuModel { MnuName = DT.TableName.ToString(), SubMainName = list2 });


                        }
                   
                        //foreach (DataTable table in ds.Tables)
                        //{

                        //    foreach (DataRow dr in table.Rows)
                        //    {
                        //    }
                        //}
                        FormsAuthentication.SetAuthCookie(_loginCredentials.UserName, false); // set the formauthentication cookie
                        Session["LoginCredentials"] = _loginCredentials; // Bind the _logincredentials details to "LoginCredentials" session
                        Session["MenuMaster"] = _menus; //Bind the _menus list to MenuMaster session
                        Session["Menu"] = _menus2;


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