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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Web.Caching;
using System.IO;
using System.Globalization;

namespace MIS_2019.Controllers
{[LogActionFilter]
    public class ReportController : Controller

        //taha 2019
    {
        //note: most of this controller method(which deal with DB) should be moved to api as planning in archtecture but we put them here for fast testing 
        //JEDMISDBEntities db = new JEDMISDBEntities();
        DataTable dtObject = new DataTable();
        public long _ReportID, _RepDest;
        public string _RepCap, _RepTitle, _RepCriteria, _RepSort, _RepLan;
        DataSet dsReport = new DataSet();
        //Objects Obj = new Objects();
        ReportDocument rpt = new ReportDocument();
        List<string> ddlFields = new List<string>();

        //    List<Paramters> parameters = new List<Paramters>() {
        //    new Paramters {RepID=1,RepPath="path1",RepDest=0,RepCriteria="crit1",RepCap="cap1" },
        //     new Paramters {RepID=2,RepPath="path2",RepDest=0,RepCriteria="crit2",RepCap="cap2" }
        //};

        // GET: Report
        public ActionResult ViewReport()
        {
            
            //ViewBag.operation = new SelectList(db.Objects, "ObjectID", "CriteriaFieldsOperators");
            return View();
        }
        [HttpPost]
        public JsonResult SetReport(int ReportId)
        {
            
            Paramters par = new Paramters();
            var ddlFields = new List<string>();
            if ((ReportId)!=0)
            {
                ddlFields = LoadCriteria(ReportId);
                if (ddlFields == null)
                {
                    TempData["error"] = "no item found";
                    return null;
                }
                
            }
            Load_Parameter(ReportId);
            par.RepCriteria = Session["CriteriaCap"].ToString();
            par.RepCriteria_val = Session["Criteria"].ToString();
            //Session["Criterialist"] = Criterialist;
            par.Criterialist = ddlFields;
            return Json(par, JsonRequestBehavior.AllowGet);
            
        }
        public List<string> LoadCriteria(int obid) {
            DataTable dtObject = new DataTable();
            var Criteria = new List<string>();
            SqlDataAdapter daObject = new SqlDataAdapter(("SELECT * FROM Objects WHERE ObjectID=" + obid), DataTools.GetConnectionStr());
            daObject.Fill(dtObject);
            List<string> Criterias = dtObject.AsEnumerable().Select(t => t.Field<string>("CriteriaFields")).ToList();
            Criterias = Criterias[0].Split(';').ToList();


            //var query = db.Objects.Where(x => x.ObjectID == obid).FirstOrDefault();
            return Criterias;
        }
        [HttpPost]
        public DataTable OpenPopup( string ddl) {
            DataTable SearchResult = new DataTable();
           string SQL = "SELECT ItemCode, ItemName, PartNumber From ItemsDirectory ORDER BY ItemsDirectory.ItemCode; SELECT ItemName From ItemsDirectory ORDER BY ItemName; SELECT Cat1Code,Cat1Name From ItemCategory1 ORDER BY Cat1Code; SELECT Cat1Name From ItemCategory1 ORDER BY Cat1Name; SELECT Cat2Code,Cat2Name From ItemCategory2 ORDER BY Cat2Code; SELECT Cat2Name From ItemCategory2 ORDER BY Cat2Name; SELECT Cat3Code,Cat3Name From ItemCategory3 ORDER BY Cat3Code; SELECT Cat3Name From ItemCategory3 ORDER BY Cat3Name; SELECT Cat4Code,Cat4Name From ItemCategory4 ORDER BY Cat4Code; SELECT Cat4Name From ItemCategory4 ORDER BY Cat4Name; SELECT PersonCode As VendCode,PersonName As VendName FROM Persons Where(Active=1 AND PersonType=2) Order By PersonCode; SELECT PartNumber From ItemsDirectory ORDER BY PartNumber; SELECT GroupID, ItemGroup FROM ItemsGroups ORDER BY GroupID; SELECT ManufacturerCode,Manufacturer FROM Manufacturers ORDER BY ManufacturerCode; Select BranchCode, BranchName From BranchCodes Order By BranchCode;";

            SqlDataAdapter daObject = new SqlDataAdapter((SQL), DataTools.GetConnectionStr());
            daObject.Fill(SearchResult);
            return SearchResult;

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
        //[HttpPost]
        //public JsonResult GetOperation(string Criteria)
        //{
        //    //Criteria = Criteria.Replace("\n", string.Empty);
        
        //    var operation = new List<string>();
        //    if (!string.IsNullOrWhiteSpace(Criteria))
        //    {

        //      operation =  Loadoperation(Criteria);//to get list of operation depend on selected coloumns

        //    }
        //    return Json(operation, JsonRequestBehavior.AllowGet);
        //}
        //public List<string> Loadoperation(string crit)
        //{
        //    var Criteria = new List<string>();
        //    var query = db.Objects.Where(x => x.ObjectTitle == crit).FirstOrDefault();
        //    return query.CriteriaFieldsOperators.Split(';').ToList();
        //}

        //[HttpGet]
        //public JsonResult Get(int id)
        //{

        //    return Json(parameters.FirstOrDefault(x => x.RepID == id), JsonRequestBehavior.AllowGet);
        //}
        //[HttpGet]
        //public JsonResult GetAll()
        //{

        //    return Json(parameters, JsonRequestBehavior.AllowGet);
        //}

       
        [HttpPost]
        public void ViewReport(Paramters reportparameter)
        {
            _ReportID = reportparameter.ReportID;
            _RepCriteria = reportparameter.RepCriteria;
            _RepDest = reportparameter.RepDest;
            _RepSort = reportparameter.RepSort;
            _RepTitle = reportparameter.RepTitle;
            _RepCap = reportparameter.RepCap;
            _RepLan = reportparameter.RepLanguage;
            if (IsPostBack())
            {
               
                PrepareReport();
                if ((_RepLan == "Arabic"))
                {
                    //RTL(rpt);
                }

                if ((_RepDest == 0))
                {
                    Session["dsReports"] = dsReport;
                    //Cache["rpt" + ReportID] = rpt;
                }

                DataTools.dbExecute((" INSERT INTO UsersRecent(UserName,ObjectID,Criteria,AccessDate)VALUES('"+ (DataTools.GetUserName() + ("'," + (_ReportID + (",'"+ (_RepCriteria + "',getdate())")))))), DataTools.GetConnectionStr());
            }
            else
            {
                //rpt = Cache[("rpt" + ReportID)];
                _RepDest = long.Parse(Session["RepDest"].ToString());
            }
            //try
            //{
            var Criterialist = new List<string>();
                if ((Request.HttpMethod == "POST"))
                {
                DataTools.dbExecute((" INSERT INTO UsersRecent(UserName,ObjectID,Criteria,AccessDate)VALUES('" + (DataTools.GetUserName() + ("'," + (_ReportID + (",'" + (_RepCriteria + "',getdate())")))))), DataTools.GetConnectionStr());

                    switch (_RepDest)
                    {
                        case 0:

                        this.HttpContext.Session["rptSource"] = rpt;

                        break;
                        case 1:
                            ExportReport((_RepTitle + ".pdf"), CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                            break;
                        case 2:
                            ExportReport((_RepTitle + ".xls"), CrystalDecisions.Shared.ExportFormatType.Excel);
                            break;
                        case 3:
                            ExportReport((_RepTitle + ".xls"), CrystalDecisions.Shared.ExportFormatType.ExcelRecord);
                            break;
                        case 4:
                            ExportReport((_RepTitle + ".rtf"), CrystalDecisions.Shared.ExportFormatType.RichText);
                            break;
                        case 5:
                            ExportReport((_RepTitle + ".htm"), CrystalDecisions.Shared.ExportFormatType.HTML40);
                            break;
                        case 6:
                            ExportReport((_RepTitle + ".doc"), CrystalDecisions.Shared.ExportFormatType.WordForWindows);
                            break;
                        case 7:
                            ExportReport((_RepTitle + ".rpt"), CrystalDecisions.Shared.ExportFormatType.CrystalReport);
                            break;
                        case 11:
                            PrintReport();
                            break;
                    }
                }
            //return Json(Criterialist, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("ShowGenericRpt", "GenericReportViewer");

            //}
            //catch
            //{
            //    return null;
            //}
        }

    
       
    //----------------------------------- converted from ASP.net ---------------------------//
        void PrintReport()
        {
            rpt.PrintToPrinter(1, true, 0, 0);
        }

        public ReportDocument PrepareReport()
        {
            int i;
            DataTable dtObject = new DataTable();
            string Op;
            string SQL = "";
            string Criteria = "";
            string CritFormula = "";
            string T;
            //DateTime Vdate = new DateTime();
            SqlDataAdapter daObject = new SqlDataAdapter(("SELECT * FROM Objects WHERE ObjectID=" + _ReportID), DataTools.GetConnectionStr());
            bool SP;
            daObject.Fill(dtObject);
            SQL = dtObject.Rows[0]["SqlStatment"].ToString();
            _RepTitle = dtObject.Rows[0]["ObjectTitle"].ToString();
            string RepPath = DataTools.GetConfigSetting("RepPath");
            if ((RepPath == ""))
            {
                RepPath = Server.MapPath("Reports/");
            }
           
            rpt.Load((RepPath + dtObject.Rows[0]["ObjectName"].ToString().Split(';')[0]));
           
            if ((bool)dtObject.Rows[0]["ConnectToSQL"])
            {
                SetReportConnections(dtObject);
                try
                {
                    rpt.VerifyDatabase();
                }
                catch 
                {

                    
                }
                
            }

            ReadCriteria(ref Criteria ,ref CritFormula, dtObject);

            if (!(bool)dtObject.Rows[0]["ConnectToSQL"])
            {
                if ((Criteria != ""))
                {
                    SQL = DataTools.AddCriteriaToSql(SQL, Criteria);
                }

                SqlDataAdapter daReport = new SqlDataAdapter(SQL, DataTools.GetConnectionStr());
                if ((SQL.IndexOf("@Crit") + 1 == 0))
                {
                    daReport.Fill(dsReport, dtObject.Rows[0]["Source"].ToString());
                }
            }
            else
            {
                rpt.SetParameterValue(SQL, Criteria);
            }

                if ((CritFormula != ""))
                {
                    if ((rpt.RecordSelectionFormula == ""))
                    {
                        rpt.RecordSelectionFormula = CritFormula;
                    }
                    else
                    {
                        rpt.RecordSelectionFormula = ("("+ (rpt.RecordSelectionFormula + (") AND ("+ (CritFormula + ")"))));
                    }

                }

                SQL = DataTools.ReadField(dtObject.Rows[0]["SqlNext"]);
                if ((SQL != ""))
                {
                    string[] NArr;
                    string NCrit;
                    string TmpStr;
                    string Sstr;
                    NArr = SQL.Split(';');
                    for (i = 0; (i<= (NArr.Length - 1)); i++)
                    {
                        NCrit = "";
                        SQL = DataTools.GetStrPart(NArr[i].ToString(), 0, "^");
                        TmpStr = DataTools.GetStrPart(NArr[i].ToString(), 3, "^");
                        Sstr = DataTools.GetStrPart(NArr[i].ToString(), 10, "^");
                        if ((Sstr.Substring(0, 1) == "S"))
                        {
                            NCrit = Criteria;
                            string[] Sarr = Sstr.Split('=');
                            if (((Sarr).Length > 0))
                            {
                                for (int k = 1; k < Sarr.Length; k++)
                                {
                                   // If InStr(1, Sarr(k), ">") Then
                                    if ((Sarr[k].IndexOf(">", 0)+1)!=0)//not sure
                                    {
                                        NCrit = NCrit.Replace(DataTools.GetStrPart(Sarr[k], 0, ">"), DataTools.GetStrPart(Sarr[k], 1, ">"));
                                    }
                                    else
                                    {
                                        NCrit = DelSQLFldCriteria(Sarr[k], NCrit);
                                    }

                                }

                            }

                        }

                        if ((TmpStr != ""))
                        {
                            string MinMax;
                            string DataField = DataTools.GetStrPart(NArr[i].ToString(), 4, "^");
                            DataField = ((DataField == "") ? TmpStr : DataField);
                            Op = DataTools.GetStrPart(NArr[i].ToString(), 6, "^");
                            Op = ((Op == "") ? "<" : Op);
                            if ((DataTools.GetStrPart(NArr[i].ToString(), 5, "^") == "MAX"))
                            {
                                MinMax = GetFldCriteriaLmt(TmpStr, Criteria, true);
                                if ((MinMax == ""))
                                {
                                    //If MinMax = "" Then MinMax = Format(DateAdd(DateInterval.Year, 100, Date.Today), "MM/dd/yyyy")

                                    MinMax = string.Format( "MM/dd/yyyy", DateTime.Today.AddYears(100));//increase date by 100y
                                }
                                else
                                {
                                    MinMax = GetFldCriteriaLmt(TmpStr, Criteria, false);
                                    if ((MinMax == ""))
                                    {
                                        MinMax = string.Format( "MM/dd/yyyy", DateTime.Today.AddYears(-100));
                                    }

                                    if ((NCrit != ""))
                                    {
                                        NCrit = (NCrit + " AND ");
                                    }

                                    NCrit = (NCrit + ("("+ (DataField+ (Op + ("'" + (MinMax + "')"))))));
                                }

                                if (!(bool)dtObject.Rows[0]["ConnectToSQL"])
                                {
                                    //                SP = GenericMethods.GetStrPart(NArr(i), 11, "^") = "SP"
                                    //If NCrit <> "" And Not SP Then
                                    //    SQL = GenericMethods.AddCriteriaToSql(SQL, NCrit)
                                    //End If
                                    SP = (DataTools.GetStrPart(NArr[i].ToString(), 11, "^")=="SP") ;
                                    if (((NCrit != "") && !SP))
                                    {
                                        SQL = DataTools.AddCriteriaToSql(SQL, NCrit);
                                    }

                                    string IndexName = DataTools.GetStrPart(NArr[i].ToString(), 2, "^");
                                    //Dim Access As Boolean = UCase(GenericMethods.GetStrPart(NArr(i), 7, "^")) = "Y"

                                    bool Access = (DataTools.GetStrPart(NArr[i].ToString(), 7, "^")).ToUpper() == "Y";
                                    //IIf(IndexName = "", False, True) Or UCase(GenericMethods.GetStrPart(NArr(i), 8, "^")) = "T"
                                    bool TB = (((IndexName == "") ? false : true) | (DataTools.GetStrPart(NArr[i].ToString(), 8, "^").ToUpper()) == "T"); 

                                    string AppToTb = DataTools.GetStrPart(NArr[i].ToString(), 9, "^");
                                    T = DataTools.GetStrPart(NArr[i].ToString(), 1, "^");
                                    if (!Access)
                                    {
                                        SqlConnection Cnn = new SqlConnection(DataTools.GetConnectionStr());
                                        SqlCommand cmd = new SqlCommand(SQL, Cnn);
                                        if (SP)
                                        {
                                            cmd.CommandType = CommandType.StoredProcedure;
                                            cmd.Parameters.AddWithValue("@Crit", NCrit);
                                        }

                                        SqlDataAdapter daN = new SqlDataAdapter(cmd);
                                        if ((AppToTb != ""))
                                        {
                                            daN.Fill(dsReport.Tables[AppToTb]);
                                        }
                                        else
                                        {
                                            daN.Fill(dsReport, T);
                                        }

                                    }
                                    else
                                    {
                                        // 'lbl()
                                    }

                                }
                                else
                                {
                                    rpt.SetParameterValue(SQL, NCrit);
                                }

                            }

                            //  Connection Info Was Here '''''''''''''''''''''''''
                            //  Connection Info '''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            if (!(bool)dtObject.Rows[0]["ConnectToSQL"])
                            {
                                SetReportConnections(dtObject);
                            }

                            // ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            // '''''''''''''''''''''''''''''''''''''''''''''''''''
                            string objectTitle = dtObject.Rows[0]["ObjectTitle"].ToString();
                            rpt.DataDefinition.FormulaFields["CompanyName"].Text = "'Saudisoft Company Limited'";
                            if ((_RepLan == "Arabic"))
                            {
                                dtObject.Rows[0]["ObjectTitle"] = DataTools.GetDataTable(("Select ArabicCap From Dic Where FieldName='" + (objectTitle + "'")), DataTools.GetConnectionStr());
                            }

                            rpt.DataDefinition.FormulaFields["ReportTitle"].Text = ("'" + (objectTitle + "'"));
                            rpt.DataDefinition.FormulaFields["CompanyBranch"].Text = "'Jeddah Branch'";
                            rpt.DataDefinition.FormulaFields["Issuedby"].Text = ("'"+ (DataTools.GetUserName() + "'"));
                        }

                 

                }

            }
            return rpt;

        }
        public void ReadCriteria(ref string Criteria, ref string CritFormula, DataTable dtObject)
        {
            int i, Sort;
            string  Fld, Op, Link, T;
            string[] Crit;
            int Typ, Idx;
            string Value;
            DateTime Vdate = new DateTime();
            if ((_RepCriteria != ""))
            {
                Crit = Regex.Split(_RepCriteria, ";");
                //Crit = _RepCriteria.Split(';');
                for ( i = 0; i <= (Crit.Length - 1); i++)
                {
                    if ((Crit[i].ToString().Trim() == ""))
                    {
                        // TODO: Continue For... Warning!!! not translated
                    }

                    Fld = DataTools.GetStrPart(Crit[i].ToString(), 0, "^^^" );
                    Op = DataTools.GetStrPart(Crit[i].ToString(), 1, "^^^");
                    Value = DataTools.GetStrPart(Crit[i].ToString(), 2, "^^^");
                    Sort =( DataTools.GetStrPart(Crit[i].ToString(), 3, "^^^")=="" ? 0: Int32.Parse(DataTools.GetStrPart(Crit[i].ToString(), 3, "^^^")));
                    Link = DataTools.GetStrPart(Crit[i].ToString(), 4, "^^^");
                    Idx = DataTools.GetStrSerial(DataTools.ReadField(dtObject.Rows[0]["CriteriaFields"]), Fld);
                    T = DataTools.GetStrPart(DataTools.ReadField(dtObject.Rows[0]["CriteriaFieldsTables"]), Idx);
                    //Val(GenericMethods.GetStrPart(GenericMethods.ReadField(dtObject.Rows(0)("CriteriaFieldsTypes")), Idx))
                    Typ = (DataTools.GetStrPart(DataTools.ReadField(dtObject.Rows[0]["CriteriaFieldsTypes"]), Idx)==""?0: Int32.Parse(DataTools.GetStrPart(DataTools.ReadField(dtObject.Rows[0]["CriteriaFieldsTypes"]), Idx)));
                    if ((Typ == 7))
                    {
                        Value = Value.Replace("-", "/").Replace(" ", "/").Replace("\\", "/");
                        Vdate = new DateTime(Int32.Parse(Value.Split('/')[2]), Int32.Parse( Value.Split('/')[1]), Int32.Parse( Value.Split('/')[0]));
                    }

                    //if ((Sort != 0))//later
                    //{
                    //    rpt.DataDefinition.SortFields.Item[rpt.DataDefinition.SortFields.Count].SortDirection = ((Sort == 1) ? SortDirection.AscendingOrder : SortDirection.DescendingOrder);
                    //    if ((T.Substring(0, 1) == "@"))
                    //    {
                    //        rpt.DataDefinition.SortFields.Item[rpt.DataDefinition.SortFields.Count].Field = rpt.DataDefinition.FormulaFields[Fld];
                    //    }
                    //    else
                    //    {
                    //        rpt.DataDefinition.SortFields.Item[rpt.DataDefinition.SortFields.Count].Field = rpt.Database.Tables[dtObject.Rows[0]["Source"].ToString()].Fields[Fld];
                    //    }

                    //}

                    if ((T == "@@"))
                    {
                        if ((Typ == 7))
                        {
                            rpt.DataDefinition.FormulaFields[Fld].Text = ("Date (" + (Vdate.Year + ("," + (Vdate.Month + ("," + (Vdate.Day + ")"))))));
                        }
                        else if ((Typ == 3))
                        {
                            rpt.DataDefinition.FormulaFields[Fld].Text = Value;
                        }
                        else
                        {
                            rpt.DataDefinition.FormulaFields[Fld].Text = ("\'"+ (Value + "\'"));
                        }

                    }
                    else if ((T.Substring(0, 1) == "@"))
                    {
                        if ((T == "@"))
                        {
                            T = ("@" + dtObject.Rows[0]["Source"]);
                        }

                        T = T.Substring(1);
                        if ((Value == "NULL"))
                        {
                            CritFormula = (CritFormula + ("(IsNull({"+ (((Fld.Substring(0, 1) == "@") ? Fld : (T + ("." + Fld))) + ("})= " + ((Op == "<>") ? "FALSE" : "TRUE")))));
                        }
                        else
                        {
                            CritFormula = (CritFormula + ("({" + (((Fld.Substring(0, 1) == "@") ? Fld : (T + ("." + Fld))) + "} ")));
                            if ((Typ == 7))
                            {
                                CritFormula = (CritFormula + (Op + (" Date ("+ (Vdate.Year + (","+ (Vdate.Month + ("," + (Vdate.Day + ")"))))))));
                            }
                            else if ((Typ == 3))
                            {
                                CritFormula = (CritFormula+ (Op + (" " + Value)));
                            }
                            else
                            {
                                CritFormula = (CritFormula+ (Op + (" \'" + (Value + "\'"))));
                            }

                        }

                        CritFormula = (CritFormula + (") "+ (Link + " ")));
                    }
                    else
                    {
                        Value = Value.Replace("*", "%");
                        if ((Value == "NULL"))
                        {
                            Criteria = (Criteria + (((Op == "<>") ? " NOT" : "") + ("("+ (((T == "") ? Fld : (T + ("." + Fld))) + " IS Null"))));
                        }
                        else
                        {
                            Value = (((Typ == 3) ? "" : "\'") + (((Typ == 7) ? string.Format( "MM/dd/yyyy",Vdate) : Value) + ((Typ == 3) ? "" : "\'")));
                            Criteria = (Criteria + ("("+ (((T == "") ? "" : (T + "."))+ (Fld + (" "+ (Op + (" " + Value)))))));
                        }

                        Criteria = (Criteria + (") "+ (Link + " ")));
                    }

                }

            }

            if ((CritFormula != ""))
            {
                CritFormula = ("("+ (CritFormula.Substring(0, (CritFormula.Length - 4)) + ")"));
                CritFormula = CritFormula.Replace(" AND ", ") AND (");
            }

            if ((DataTools.ReadField(dtObject.Rows[0]["FilterOnFormula"]) != ""))
            {
                CritFormula = (CritFormula+ (((CritFormula == "") ? "" : " AND ") + ("(" + (DataTools.ReadField(dtObject.Rows[0]["FilterOnFormula"]) + ")"))));
            }

            if ((Criteria != ""))
            {
                Criteria = ("("+ (Criteria.Substring(0, (Criteria.Length - 4)) + ")"));
                Criteria = Criteria.Replace(") AND (", ")) AND ((");
            }

            if ((DataTools.ReadField(dtObject.Rows[0]["FilterOn"]) != ""))
            {
                Criteria = (Criteria + (((Criteria == "") ? "" : " AND ") + ("(" + (DataTools.ReadField(dtObject.Rows[0]["FilterOn"]) + ")"))));
            }

            Fld = ApplyBranchPermissions(dtObject);
            if ((Fld != ""))
            {
                if ((Fld.IndexOf("{") )==0)
                {
                    CritFormula = (CritFormula+ (((CritFormula == "") ? "" : " AND ") + ("("+ (Fld + ")"))));
                }
                else
                {
                    Criteria = (Criteria + (((Criteria == "") ? "" : " AND ") + ("(" + (Fld + ")"))));
                }

            }

            Fld = ApplySalesmanPermissions(dtObject);
            if ((Fld != ""))
            {
                if ((Fld.IndexOf("{") )==0)
                {
                    CritFormula = (CritFormula+ (((CritFormula == "") ? "" : " AND ") + ("("+ (Fld + ")"))));
                }
                else
                {
                    Criteria = (Criteria+ (((Criteria == "") ? "" : " AND ") + ("("+ (Fld + ")"))));
                }

            }

        }
        void SetReportConnections( DataTable dtObject)
        {
            int i;  SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(DataTools.GetConnectionStr());
            for (i = 0; (i <= (rpt.Database.Tables.Count - 1)); i++)
            {
                if ((bool)dtObject.Rows[0]["ConnectToSQL"])
                {

                    TableLogOnInfo Tlogin;
                    Tlogin = rpt.Database.Tables[i].LogOnInfo;
                  
                   
                    Tlogin.ConnectionInfo.DatabaseName = builder.InitialCatalog.ToString();
                    Tlogin.ConnectionInfo.ServerName = builder.DataSource.ToString();
                    Tlogin.ConnectionInfo.Password = builder.Password.ToString();
                    Tlogin.ConnectionInfo.UserID = builder.UserID.ToString();
                    // Tlogin.ConnectionInfo.IntegratedSecurity = False
                    Tlogin.ConnectionInfo.IntegratedSecurity = false;
                    rpt.Database.Tables[i].ApplyLogOnInfo(Tlogin);
                    //string DatabaseName = DataTools.GetConfigSetting("DatabaseName");
                    //string ServerName = DataTools.GetConfigSetting("ServerName");
                    //string Password = DataTools.GetConfigSetting("Pwd");
                    //string UserID = DataTools.GetConfigSetting("UserID");
                    //rpt.SetDatabaseLogon(UserID, Password, ServerName, DatabaseName, true);
                }
                else
                {
                    rpt.Database.Tables[i].SetDataSource(dsReport.Tables[rpt.Database.Tables[i].Name]);
                }

            }

            ReportDocument SubRep;
            for (i = 0; (i <= (rpt.Subreports.Count - 1)); i++)
            {
                SubRep = rpt.Subreports[i];
                for (int k = 0; (k <= (SubRep.Database.Tables.Count - 1)); k++)
                {
                    if ((bool)dtObject.Rows[0]["ConnectToSQL"])
                    {
                        TableLogOnInfo Tlogin;
                        Tlogin = SubRep.Database.Tables[k].LogOnInfo;
                        Tlogin.ConnectionInfo.DatabaseName = builder.InitialCatalog.ToString();
                        Tlogin.ConnectionInfo.ServerName = builder.DataSource.ToString();
                        Tlogin.ConnectionInfo.Password = builder.Password.ToString();
                        Tlogin.ConnectionInfo.UserID = builder.UserID.ToString();
                        Tlogin.ConnectionInfo.IntegratedSecurity = false;
                        SubRep.Database.Tables[k].ApplyLogOnInfo(Tlogin);
                    }
                    else
                    {
                        SubRep.Database.Tables[k].SetDataSource(dsReport.Tables[rpt.Database.Tables[k].Name]);
                    }

                }

            }

        }
        string ApplyBranchPermissions(DataTable dtObj)
        {
            if (!(bool)dtObj.Rows[0]["ByBranch"])
            {
                return "";
            }

            string SQL;
            string TabName;
            int FldIndex;
            SQL = ("SELECT BranchCode FROM UserRights WHERE UserName='" + (DataTools.GetUserName() + ("' AND ObjectID=" + (_ReportID + " AND CanRun=1"))));
            SqlDataAdapter daBrns = new SqlDataAdapter(SQL, DataTools.GetConnectionStr());
            DataTable dtBrns = new DataTable();
            daBrns.Fill(dtBrns);
            string Brns="";
            foreach (DataRow dtr in dtBrns.Rows)
            {
                Brns = (Brns + ("'"+ (dtr[0] + "',")));
            }

            if ((Brns != ""))
            {
                Brns = Brns.Substring(0, (Brns.Length - 1));
            }

            FldIndex = DataTools.GetStrSerial(DataTools.ReadField(dtObj.Rows[0]["CriteriaFields"]), "BranchCode");
            if ((FldIndex == -1))
            {
                TabName = "";
            }
            else
            {
                TabName = DataTools.GetStrPart(DataTools.ReadField(dtObj.Rows[0]["CriteriaFieldsTables"]), FldIndex);
            }

            if ((TabName.Substring(0, 1) == "@"))
            {
                if ((TabName == "@"))
                {
                    TabName = ("@" + DataTools.ReadField(dtObj.Rows[0]["Source"]));
                }

                SQL = ("({"+ (TabName.Substring(1) + ".BranchCode} IN ["));
                SQL = (SQL+ (Brns.Replace("'", "\"") + "])"));
            }
            else
            {
                SQL = ("((" + (((TabName == "") ? "BranchCode" : (TabName + ".BranchCode")) + (" IN ("+ (Brns + ")))"))));
            }

            return SQL;
        }
        string ApplySalesmanPermissions(DataTable dtObj)
        {
            // Check if salesman in criteria fields
            string SQL;
            int FldIndex = DataTools.GetStrSerial(DataTools.ReadField(dtObj.Rows[0]["CriteriaFields"]), "Salesman");
            if ((FldIndex == -1))
            {
                FldIndex = DataTools.GetStrSerial(DataTools.ReadField(dtObj.Rows[0]["CriteriaFieldsCaptions"]), "Salesman");
            }

            if ((FldIndex == -1))
            {
                return "";
            }

            DataTable dtr = DataTools.DLookUp(DataTools.GetConnectionStr(), "Persons", "PersonCode", ("PersonType=3  AND UserName='" + (DataTools.GetUserName() + "' AND Rank=1")));
            if ((dtr.Rows.Count == 0))
            {
                return "";
            }

            string Salesman = dtr.Rows[0][0].ToString();
            string TabName = DataTools.GetStrPart(DataTools.ReadField(dtObj.Rows[0]["CriteriaFieldsTables"]), FldIndex);
            string FldName = DataTools.GetStrPart(DataTools.ReadField(dtObj.Rows[0]["CriteriaFields"]), FldIndex);
            if ((TabName.Substring(0, 1) == "@"))
            {
                if ((TabName == "@"))
                {
                    TabName = ("@" + DataTools.ReadField(dtObj.Rows[0]["Source"]));
                }

                SQL = ("({" + (TabName.Substring(1) + ("."+ (FldName + ("} = '" + (Salesman + "'"))))));
            }
            else
            {
                SQL = ("((" + (((TabName == "") ? FldName : (TabName + ("." + FldName))) + (" = ('"+ (Salesman + "')))"))));
            }

            return SQL;
        }
        public string DelSQLFldCriteria(string FieldName, string Criteria)
        {
            int i, J;
            string TmpStr="";
            string[] Ands, Ors;
            //Ands = Split(Criteria, " AND ",  vbTextCompare);
            Ands =Criteria.Split(new[] {" AND "},StringSplitOptions.None);//taha
            for (i = 0; i < Ands.Length; i++)
            {
                //Ors = Split(Ands[i], " OR ",  vbTextCompare);
                Ors = Criteria.Split(new[] { " OR " }, StringSplitOptions.None);
                for (J = 0; J < Ors.Length; J++)
                {
                    if (((Ors[J].IndexOf(FieldName, 0, StringComparison.OrdinalIgnoreCase) + 1)== 0))
                    {
                        // Ands(i) = S_Lib.RemoveStrSerial(Ands(i), J, " OR ")
                        TmpStr = (TmpStr + (Ors[J] + " OR "));
                    }

                }

                if ((TmpStr != ""))
                {
                    TmpStr = (TmpStr.Substring(0, (TmpStr.Length - 4)) + " AND ");
                }

            }

            if ((TmpStr != ""))
            {
                TmpStr = TmpStr.Substring(0, (TmpStr.Length - 5));
            }

            return TmpStr;
        }
        public string GetFldCriteriaLmt(string FieldName, string Criteria, bool GetMax)
        {
            int i, k1, k2;
           
            string TmpStr, CmpStr="";
            DateTime Udate = new DateTime();
            DateTime Ldate = new DateTime();
            i = 0;
            LOP:;
            //i = InStr(i + 1, Criteria, FieldName, vbTextCompare)

            i = (Criteria.IndexOf(FieldName, i+ 1, StringComparison.OrdinalIgnoreCase) );

            if (i > 0)
            {

                k1 = (Criteria.IndexOf("\'", (i - 1)) + 1);
                k2 = (Criteria.IndexOf("\'", k1) + 1);
                if (k1 == 0 | k2 == 0)
                    goto LOP;
                TmpStr = Criteria.Substring(k1, (k2 - (k1 - 1)));
                DateTime d = new DateTime(int.Parse(TmpStr.Substring(6, 4)), int.Parse(TmpStr.Substring(0, 2)), int.Parse(TmpStr.Substring(3, 2)));
                //CmpStr = Trim(Replace(Replace(Mid(Criteria, i + Len(FieldName), k1 - (i + Len(FieldName))), "(", ""), ")", ""))
                CmpStr = Criteria.Substring(i + FieldName.Length, k1 - (i + FieldName.Length));
                CmpStr = CmpStr.Replace( "(", "");
                CmpStr = CmpStr.Replace(")", "");
                CmpStr = CmpStr.Trim();
                switch (CmpStr)
                {
                    case "<":
                        {
                            if (d > Udate | Udate == default(DateTime))
                                Udate = DateTime.Now.AddDays(-1);
                            break;
                        }

                    case "<=":
                        {
                            if (d > Udate | Udate == default(DateTime))
                                Udate = d;
                            break;
                        }

                    case "=":
                        {
                            Udate = d; Ldate = d;
                            break;
                        }

                    case ">":
                        {
                            if (d < Ldate | Ldate == default(DateTime))
                                Ldate = DateTime.Now.AddDays(1);
                            break;
                        }

                    case ">=":
                        {
                            if (d < Ldate | Ldate == default(DateTime))
                                Ldate = d;
                            break;
                        }
                }
                goto LOP;
            }
            if (GetMax)
            {
                if (Udate == default(DateTime))
                    return "";
                else
                    return string.Format( "MM/dd/yyyy", Udate);
            }
            else if (Ldate == default(DateTime))
                return "";
            else
                return string.Format( "MM/dd/yyyy", Ldate);
        }
        protected bool IsPostBack()
        {
            bool isPost = string.Compare(Request.HttpMethod, "POST",
               StringComparison.CurrentCultureIgnoreCase) == 0;
            if (Request.UrlReferrer == null) return false;

            bool isSameUrl = string.Compare(Request.Url.AbsolutePath,
               Request.UrlReferrer.AbsolutePath,
               StringComparison.CurrentCultureIgnoreCase) == 0;

            return isPost ;
        }
        private void ExportReport(string FileName, ExportFormatType FileFormat)
        {
            if ((FileFormat == ExportFormatType.Excel))
            {
                ExcelFormatOptions excelOpts = new ExcelFormatOptions();
                rpt.ExportOptions.FormatOptions = excelOpts;

            }

            rpt.ExportToStream(FileFormat);

            rpt.Dispose();rpt.Close();

        }
        private void Load_Parameter( long RepID)
        {
            string strTmp;
            string[] arrTmp;
            List<string> ddlLink = new List<string>();
            List<string> lstCriteria = new List<string>();
            
             DataSet dsDic = new DataSet();
            Paramters rep_par = new Paramters();
             SqlDataAdapter daObject = new SqlDataAdapter(("SELECT ObjectTitle, UseAndOnly,ByBranch,CriteriaFields,CriteriaFieldsCaptions,SortFieldsList,Criteria" +"FieldsUnique,CriteriaFieldsTypes,CriteriaFieldsOperators,CriteriaFieldsSources FROM Objects WHERE ObjectID=" + RepID), DataTools.GetConnectionStr());
                Session["ReportID"] = RepID;
                daObject.Fill(dtObject);
                Session["dtObject"] = dtObject;
                 rep_par.RepTitle = dtObject.Rows[0]["ObjectTitle"].ToString();
               
                strTmp = ((dtObject.Rows[0]["CriteriaFields"].ToString())==null ? "" : dtObject.Rows[0]["CriteriaFields"].ToString()).Replace("\r\n", "");
                arrTmp = strTmp.Split(';');
                string[] arrtmp2 =(string[]) arrTmp.Clone();
                for (int i = 0; (i<= (arrtmp2.Length - 1)); i++)
                {
                    if ((DataTools.GetStrPart(DataTools.ReadField(dtObject.Rows[0]["CriteriaFieldsCaptions"]), i) != ""))
                    {
                        arrtmp2[i] = DataTools.GetStrPart(DataTools.ReadField(dtObject.Rows[0]["CriteriaFieldsCaptions"]), i);
                    }

                }

            strTmp = string.Join(";", arrtmp2);
            dsDic = DataTools.GetDic(strTmp);
            strTmp = "";
            for (int i = 0; (i <= (arrTmp.Length - 1)); i++)
            {
                strTmp = "";
                foreach (DataRow dr in dsDic.Tables[0].Rows)
                {
                    if ((dr[0].ToString() == arrtmp2[i]))
                    {
                        strTmp = dr["LatinCap"].ToString();
                        break;
                    }

                }

                ddlFields.Add(((strTmp == "") ? arrTmp[i] : strTmp));
            }

            ddlLink.Add("AND");
            if (!(bool)dtObject.Rows[0]["UseAndOnly"])
            {
                ddlLink.Add("OR");
            }

            DataTable dtCrit = new DataTable();
            Session["Criteria"] = "";
            Session["CriteriaCap"] = "";
            dtCrit = DataTools.DLookUp(DataTools.GetConnectionStr(), "UsersRecent", "Criteria", ("UserName='" + (DataTools.GetUserName() + ("' AND ObjectID=" + RepID))),"","", "AccessDate DESC", 1);
           
            if ((dtCrit.Rows.Count > 0))
            {
                string CritFromTbl = dtCrit.Rows[0][0].ToString();
                if (CritFromTbl != null && (CritFromTbl.Trim() != ""))
                {

                    arrTmp = CritFromTbl.ToString().Split(';');
                    for (int i = 0; (i <= (arrTmp.Length - 1)); i++)
                    {
                        ValidateLine(DataTools.GetStrSerial(dtObject.Rows[0]["CriteriaFields"].ToString(), DataTools.GetStrPart(arrTmp[i], 0, "^^^")), DataTools.GetStrPart(arrTmp[i], 1, "^^^"), DataTools.GetStrPart(arrTmp[i], 2, "^^^"), DataTools.GetStrPart(arrTmp[i], 3, "^^^"), DataTools.GetStrPart(arrTmp[i], 4, "^^^"),ref strTmp);
                        lstCriteria.Add(DataTools.GetStrPart(Session["CriteriaCap"].ToString(), i));
                        //Session["lstCriteria"] = (DataTools.GetStrPart(Session["Criteria"].ToString(), i));
                        //Session["criteria_val"] = (DataTools.GetStrPart(Session["CriteriaCap"].ToString(), i));
                    }

                }

            }


        }
        public bool ValidateLine(int Index, string Op, string Value, string Sort, string Link, ref string Output)
        {
            DateTime dtf;
            string CriteriaCap="", Criteria="";
            string Ops = DataTools.GetStrPart(DataTools.ReadField(dtObject.Rows[0]["CriteriaFieldsOperators"]), Index);
            string Unqs = DataTools.GetStrPart(DataTools.ReadField(dtObject.Rows[0]["CriteriaFieldsUnique"]), Index);
            string FldType = DataTools.GetStrPart(DataTools.ReadField(dtObject.Rows[0]["CriteriaFieldsTypes"]), Index);
            string Fld = DataTools.GetStrPart(DataTools.ReadField(dtObject.Rows[0]["CriteriaFields"]), Index);
            if ((Index == -1))
            {
                Output = "Please select a field.";
                goto Insert_Err;
            }
            else if (((Ops != "") && (DataTools.GetStrSerial(Ops, Op) < 0)))
            {
                Output = ("Operator must be " + Ops);
                goto Insert_Err;
            }
            else if (((Value == "") && ((Sort == " ") || (Sort == ""))))
            {
                Output = "Please enter a valid value for field.";
                goto Insert_Err;
            }
            else if (((FldType.Trim() == "7") &&!DateTime.TryParse(Value, out dtf)))
            {
                Output = "Invalid Date.";
                goto Insert_Err;
            }
            else if ((((FldType.Trim() == "7")|| (FldType.Trim() == "3")) && (Op == "Like")))
            {
                Output = "Like operator is used with string fields only.";
                goto Insert_Err;
            }
            //Output = ddlFields.Items(Index).Text + " " + Op + " " + Value + " " + Link
            Output = (ddlFields[Index] + (" " + (Op + (" " + (Value + (" " + Link))))));
            Session["CriteriaCap"] = (Session["CriteriaCap"]+ (((Session["CriteriaCap"].ToString() == "") ? "" : ";") + Output));
            CriteriaCap = CriteriaCap + (((CriteriaCap == "") ? "" : ";") + Output);
            Output = (Fld + ("^^^" + (Op + ("^^^" + (Value + ("^^^"+ (Sort + ("^^^" + Link))))))));
            Session["Criteria"] = (Session["Criteria"]+ (((Session["Criteria"].ToString() == "") ? "" : ";") + Output));
            Criteria = (Criteria+ (((Criteria == "") ? "" : ";") + Output));
            return true;

            Insert_Err:
            return false;
        }

     //
    }
}