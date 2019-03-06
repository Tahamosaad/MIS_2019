using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using MIS_2019.Models;

namespace MIS_2019
{
    public class DataTools
    {
       

            static string _GlobalConnectionString = "";

            public static string GlobalConnectionString
            {
                get { return _GlobalConnectionString; }
                set { _GlobalConnectionString = value; }
            }
        public static string GetConnectionStr()
        {
          string cs=   ConfigurationManager.ConnectionStrings["JEDMISDBEntities"].ConnectionString;
           EntityConnectionStringBuilder conn = new EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["JEDMISDBEntities"].ConnectionString);
            string cs2 = conn.ProviderConnectionString;
            return cs2;
        }
        public static DataSet Execute_SP(string sp_name, string sp_par)
        {
            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@mnuname";
            parameter.Value=sp_par;
            string CS = GetConnectionStr();

            SqlConnection con = new SqlConnection(CS);
            SqlDataAdapter da = new SqlDataAdapter(sp_name, con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (parameter != null)
            {
                da.SelectCommand.Parameters.Add(parameter);
            }
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public static int ExecuteSQL(string SQL, string ConnectionString)
            {
                OleDbConnection C = new OleDbConnection(ConnectionString);
                try
                {
                    C.Open();
                    OleDbCommand cmd = new OleDbCommand(SQL, C);
                    int result = cmd.ExecuteNonQuery();
                    C.Close();
                    return result;
                }
                catch (OleDbException dbEx)
                {
                    DisplayDBErrors(dbEx, SQL);
                    return 0;
                }
                catch (Exception ex)
                {
                    DisplayErrors(ex, SQL);                 //MyMessage.Show((ex.Message + ("\r\n" + SQL)));
                    return 0;
                }
                finally
                {
                    if (C.State != ConnectionState.Closed) C.Close();
                }
            }
        public static bool IsSQL(string SQL)
        {
            return (((SQL.IndexOf("SELECT ", 0, StringComparison.OrdinalIgnoreCase) + 1) != 0));
           
        }

        public static DataSet GetDic(string Fld)
        {
            string SQL = "SELECT * FROM Dic WHERE FieldName";
            if ((Fld.IndexOf(";") !=0))
            {
                SQL = (SQL + (" IN (\'"+ (Fld.Replace(";", "\',\'") + "\')")));
            }
            else
            {
                SQL = (SQL + ("=\'" + (Fld + "\'")));
            }

            SQL = (SQL + " ORDER BY FieldName");
            SqlDataAdapter da = new SqlDataAdapter(SQL, GetConnectionStr());
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public static DataTable DLookUp(string strCon, string TableName, string Columns, string Criteria = "", string GroupBy = "", string Having = "", string OrderBy = "", long TopRecords = 0, bool Distinct = false)
        {
            DataTable dtDlk = new DataTable();

            string SQL;
            if (IsSQL(TableName))
            {
                SQL = TableName;
            }
            else
            {
                SQL = ("SELECT " + ((Distinct ? "DISTINCT " : "") + (((TopRecords > 0) ? ("TOP " + TopRecords) : "") + (Columns + ((TableName == "") ? "" : (" FROM " + TableName))))));
            }

            if ((Criteria != ""))
            {
                SQL = (SQL + (" WHERE " + Criteria));
            }

            if ((GroupBy != ""))
            {
                SQL = (SQL + (" GROUP BY " + GroupBy));
            }

            if ((Having != ""))
            {
                SQL = (SQL + (" HAVING " + Having));
            }

            if ((OrderBy != ""))
            {
                SQL = (SQL + (" ORDER BY " + OrderBy));
            }

            SqlDataAdapter daDlk = new SqlDataAdapter(SQL, strCon);
            daDlk.Fill(dtDlk);
            return dtDlk;
        }
        public static string DLookUp(string ConnectionString, string SQL)
            {
                OleDbConnection C = new OleDbConnection(ConnectionString);
                try
                {
                    C.Open();
                    OleDbCommand cmd = new OleDbCommand(SQL, C);
                    string result = (cmd.ExecuteScalar() as string);
                    C.Close();
                    return result;
                }
                catch (OleDbException dbEx)
                {
                    DisplayDBErrors(dbEx, SQL);
                }
                catch (Exception ex)
                {
                    DisplayErrors(ex, SQL);                //MyMessage.Show((ex.Message + ("\r\n" + SQL)));
                }
                finally
                {
                    if (C.State != ConnectionState.Closed) C.Close();
                }
                return "";
            }
       
        public static DataTable GetDataTable(string SQL)
            {
                return GetDataTable(SQL, _GlobalConnectionString);
            }

            public static DataTable GetDataTable(string SQL, string ConnectionString)
            {
                if (SQL == null || SQL.Trim() == "" || ConnectionString == null || ConnectionString.Trim() == "")
                    return null;

                DataTools.AddProviderToConnectionString(ref ConnectionString);
                IDbConnection MyConnection = null;
                DataTable dt = new DataTable();
                try
                {
                   
                        OleDbConnection cn = new OleDbConnection(ConnectionString);
                        MyConnection = cn;
                        OleDbCommand cmd = new OleDbCommand(SQL, cn);
                        cn.Open();
                        OleDbDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                        dr.Close();
                        cn.Close();
                    

                    return dt;
                }
                catch (OleDbException )
                {
                    //DisplayDBErrors(dbEx, SQL);
                }
                catch (Exception )
                {
                    //DisplayErrors(ex, SQL);
                    //MyMessage.Show((ex.Message + ("\r\n" + SQL)));
                }
                finally
                {
                    if (MyConnection != null && MyConnection.State != ConnectionState.Closed) MyConnection.Close();
                }
                return null;
            }

            private static void CopyCommand(OleDbCommand SourceCommand, OleDbCommand TargetCommand)
            {
                TargetCommand.CommandText = SourceCommand.CommandText;
                TargetCommand.CommandType = SourceCommand.CommandType;
                TargetCommand.Connection = SourceCommand.Connection;

                foreach (OleDbParameter prm in SourceCommand.Parameters)
                {
                    TargetCommand.Parameters.Add(prm);
                }
            }

            public static DataTable GetDataTableSQL( string ConnectionString,string SQL)
            {
                try
                {
                    SqlConnection con = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand(SQL, con);
                    //cmd.CommandType = CommandType.;
                    DataTable dt = new DataTable();
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    dr.Close();
                    con.Close();
                    return dt;
                }
                catch
                {
                    return null;
                }
            }

            public static void DisplayDBErrors(OleDbException dbEx, string SQL)
            {
                string strX;
                strX = ("Error from " + (SQL + "\r\n"));
                for (int i = 0; i <= dbEx.Errors.Count - 1; i++)
                {
                    strX = strX + "Index #" + i.ToString() + "\r\n" + "Error:" + dbEx.Errors[i].ToString() + "\r\n";
                }
                //strX = (strX + ("(" +Err.Number + ")")));
                //MyMessage.Show(strX, "SPECIAL EMERGENCY FORCES ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            public static void DisplayErrors(Exception dbEx, string Comments)
            {
                string strX = "";
                if (Comments != "")
                    strX = ("Error from " + (Comments + "\r\n"));
                strX = strX + "Error:" + dbEx.Message;
                //strX = (strX + ("(" +Err.Number + ")")));
                //MyMessage.Show(strX, "SPECIAL EMERGENCY FORCES ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            public static void DisplayErrors(Exception dbEx)
            {
                DisplayErrors(dbEx, "");
            }

            

            public static string GetDataSourceFromQuery(string Query)
            {
                if (Query == null || Query.Trim() == "")
                    return "";

                try
                {
                    int fromIndex = Query.ToLower().IndexOf(" from ");
                    if (fromIndex > -1)
                    {
                        string tmp = Query.Substring(fromIndex + 6);
                        //if (tmp != null && tmp != "")
                        //{
                        //    tmp = tmp.Trim();
                        //    string[] tmpList = tmp.Split(' ');
                        //    if (tmpList.Length > 0)
                        //        return tmpList[0];
                        //}
                        return tmp;
                    }
                }
                catch
                {

                }
                return "";
            }
        

            private static bool IsEqualConStr(string ConStr1, string ConStr2)
            {
                ConStr1 = ConStr1.ToLower();
                ConStr2 = ConStr2.ToLower();

                AddProviderToConnectionString(ref ConStr1);
                ConStr1 = ConStr1.ToLower();

                AddProviderToConnectionString(ref ConStr2);
                ConStr2 = ConStr2.ToLower();

                OleDbConnection cn1 = new OleDbConnection(ConStr1);
                OleDbConnection cn2 = new OleDbConnection(ConStr2);

                return (
                    cn1.Provider == cn2.Provider &&
                    cn1.DataSource == cn2.DataSource &&
                    cn1.Database == cn2.Database
                    );
            }

            public static List<string> GetInternalObjects()
            {
                List<string> internalObjects = new List<string>();

                // Tables
                internalObjects.Add("Objects");
                internalObjects.Add("sysdiagrams");
                internalObjects.Add("Controls");
                internalObjects.Add("UserRights");
                internalObjects.Add("User_Card_Rights");
                internalObjects.Add("Users");
                internalObjects.Add("CardsControls");
                internalObjects.Add("Cards");
                internalObjects.Add("CardColumnsDetails");
                internalObjects.Add("dic");
                internalObjects.Add("Properties");

                // Views
                internalObjects.Add("All");
                internalObjects.Add("ToBeTranslated");
                internalObjects.Add("RightsEnum");

                return internalObjects;
            }

            

            public static bool IsInStringList(string ItemToSearch, List<string> StringList)
            {
                string strLower = ItemToSearch.ToLower();
                foreach (string item in StringList)
                {
                    if (item.ToLower() == strLower)
                        return true;
                }
                return false;
            }

            bool SearchString(string item)
            {
                return true;
            }

            public static bool ColumnExists(string ColumnName, string TableName, string ConnectionString)
            {
                //string SQL = "select count(*) from sysColumns where [name] = '" + ColumnName + "' and [id] = object_id('" + TableName + "')";

                //OleDbConnection connection = new OleDbConnection(ConnectionString);

                //OleDbCommand command = new OleDbCommand(SQL, connection);

                //connection.Open();

                //bool Exists = Convert.ToBoolean(command.ExecuteScalar());

                //connection.Close();

                //return Exists;

                OleDbConnection connection = new OleDbConnection(ConnectionString);
                OleDbCommand cmd = new OleDbCommand("select * from " + TableName, connection);
                connection.Open();
                OleDbDataReader DataReader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
                DataTable Schema = DataReader.GetSchemaTable();
                connection.Close();

                return (Schema.Select("ColumnName = '" + ColumnName + "'").Length == 1);
            }

            public static bool TableHasData(string TableName, string ConnectionString)
            {
                string SQL = "select count(*) from " + TableName;

                OleDbConnection connection = new OleDbConnection(ConnectionString);

                OleDbCommand command = new OleDbCommand(SQL, connection);

                connection.Open();

                bool HasData = (Convert.ToInt32(command.ExecuteScalar()) > 0);

                connection.Close();

                return HasData;
            }

            public static bool IsTable(string TableName, string ConnectionString)
            {
                //string SQL = "select count(*) from sysobjects where [name] = '" + TableName + "' and xtype = 'U'";
                //OleDbConnection connection = new OleDbConnection(ConnectionString);
                //OleDbCommand command = new OleDbCommand(SQL, connection);
                //connection.Open();
                //bool _isTable = (Convert.ToInt32(command.ExecuteScalar()) > 0);
                //connection.Close();
                //return _isTable;

                /////////////////////////////////////////////////////////
                try
                {
                    OleDbConnection connection = new OleDbConnection(ConnectionString);
                    connection.Open();

                    DataTable dt = connection.GetSchema("Tables", new string[] { null, null, TableName });
                    connection.Close();

                    return ((dt.Rows.Count == 1) && (dt.Select("TABLE_TYPE='TABLE'").Length == 1));
                }
                catch
                {
                    return false;
                }
            }

            public static void AddProviderToConnectionString(ref string ConnectionString)
            {
                //if (ConnectionString.IndexOf("Provider", StringComparison.OrdinalIgnoreCase) == -1)
                string provider = GetProvider(ConnectionString);
                if (provider == "")
                    ConnectionString = "Provider=SQLOLEDB.1;" + ConnectionString;
            }

            private static string GetProvider(string ConStr)
            {
                int n = ConStr.ToLower().IndexOf("provider");
                if (n == -1) return "";

                ConStr = ConStr.Substring(n);
                n = ConStr.IndexOf("=");
                if (n == -1) return "";

                if (ConStr.Substring(0, n).ToLower().Trim() != "provider")
                    return "";

                ConStr = ConStr.Substring(n + 1);

                n = ConStr.IndexOf(";");
                string provider;

                if (n == -1)
                    provider = ConStr.Trim();
                else
                    provider = ConStr.Substring(0, n).Trim();

                return provider;
            }

            public static void RemoveNotNullable(DataTable MyDataTable)
            {
                foreach (DataColumn col in MyDataTable.Columns)
                {
                    if (col.DataType == typeof(DateTime))
                    {
                        foreach (DataRow row in MyDataTable.Rows)
                        {
                            if (row[col.ColumnName] == DBNull.Value)
                                row[col.ColumnName] = DateTime.Today;
                        }
                    }
                }
            }

            public static bool HasDictionary(string ConnectionString)
            {
                try
                {
                    ConnectionString = ConnectionString.Trim();
                    if (ConnectionString == "") return false;

                    SqlConnection cn = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand("Select ArabicCap, LatinCap from Dic", cn);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
                    cn.Close();
                    dr.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            public static string BuildConnectionString(string ServerName, string DatabaseName, string Username, string Password)
            {
                return BuildConnectionString("", ServerName, DatabaseName, Username, Password);
            }

            public static string BuildConnectionString(string Provider, string ServerName, string DatabaseName, string Username, string Password)
            {
                Provider = Provider.Trim();
                ServerName = ServerName.Trim();
                DatabaseName = DatabaseName.Trim();
                Username = Username.Trim();
                Password = Password.Trim();

                string constr = "";
                if (Provider != "")
                    constr += "Provider=" + Provider + ";";
                constr += "Data Source=" + ServerName + ";Persist Security Info=True";
                constr += (Username != "" ? ";User ID=" + Username : ";Integrated Security=True");//;User Instance=True");
                                                                                                  //constr += (strUsername != "" ? ";User ID=" + strUsername : ";Integrated Security=True;User Instance=True");
                                                                                                  //constr += ";User ID=" + Username;
                constr += ((Username != "" && Password != "") ? ";Password=" + Password : "");
                if (DatabaseName != "")
                    constr += ";Initial Catalog=" + DatabaseName;

                return constr;
            }

            public static void CleanDatabases(string connectionString)
            {
                try
                {
                    SqlConnection cn = new SqlConnection(connectionString);
                    SqlCommand cm = new SqlCommand("exec sp_oledb_database", cn);
                    DataTable dt = new DataTable();
                    cn.Open();
                    SqlDataReader dr = cm.ExecuteReader();
                    //MyMessage.Show(dr.HasRows.ToString());
                    dt.Load(dr);

                    List<string> DatabaseList = new List<string>();
                    foreach (DataRow r in dt.Rows)
                    {
                        DatabaseList.Add(r["name"].ToString());
                    }

                    //frmPreviewDatatable frm = new frmPreviewDatatable(dt);
                    //frm.Show();

                    cm.CommandText = "exec sp_databases";
                    dt = new DataTable();
                    dr = cm.ExecuteReader();
                    dt.Load(dr);

                    dr.Close();

                    foreach (DataRow r in dt.Rows)
                    {
                        DatabaseList.Remove(r["DATABASE_NAME"].ToString());
                    }

                    //MyMessage.Show("Databases: " + DatabaseList.Count.ToString());

                    //frm = new frmPreviewDatatable(dt);
                    //frm.Show();

                    //return;
                    if (DatabaseList.Count > 0)
                    {
                        int rowIndex = 1;
                        foreach (string dbName in DatabaseList)
                        {
                            //MyMessage.Show(rowIndex.ToString() + ": " + dbName);
                            cm.CommandText = "sp_detach_db '" + dbName + "'";

                            try { cm.ExecuteNonQuery(); }
                            catch { }

                            rowIndex++;
                        }
                    }

                    cn.Close();
                    //MyMessage.Show("Succeeded.");
                }
                catch (Exception )
                {
                    //MyMessage.Show(ee.ToString());
                }
            }

          

            public static string GetDatabaseName(string dbFileName)
            {
                if (!File.Exists(dbFileName)) return "";

                FileInfo fi = new FileInfo(dbFileName);
                if (fi.Name.Length > 4)
                    return fi.Name.Substring(0, fi.Name.Length - 4);

                return dbFileName;
            }

            public static string GetNewColumnName(DataTable MyDataTable, string ColumnNamePrefix)
            {
                string newColName;
                int colNum = 0;
                for (int i = 0; i < MyDataTable.Columns.Count; i++)
                {
                    newColName = ColumnNamePrefix.ToLower() + (colNum == 0 ? "" : "_" + colNum.ToString());
                    if (MyDataTable.Columns[i].ColumnName.ToLower() == newColName || MyDataTable.Columns[i].Caption.ToLower() == newColName)
                    {
                        if (colNum == 0)
                            colNum = 2;
                        else
                            colNum++;

                        i = 0;
                    }
                }

                return ColumnNamePrefix + (colNum == 0 ? "" : "_" + colNum.ToString());
            }

            public static string GetNewColumnName(DataTable MyDataTable, string ColumnNamePrefix, ref int colNum)
            {
                string newColName;
                for (int i = 0; i < MyDataTable.Columns.Count; i++)
                {
                    newColName = ColumnNamePrefix.ToLower() + colNum.ToString();
                    if (MyDataTable.Columns[i].ColumnName.ToLower() == newColName || MyDataTable.Columns[i].Caption.ToLower() == newColName)
                    {
                        colNum++;
                        i = 0;
                    }
                }

                return ColumnNamePrefix + colNum.ToString();
            }

            public static string GetNewRelationName(DataSet MyDataSet, string RelationNamePrefix, int relNum)
            {
                string newRelName;
                for (int i = 0; i < MyDataSet.Relations.Count; i++)
                {
                    newRelName = RelationNamePrefix.ToLower() + relNum.ToString();
                    if (MyDataSet.Relations[i].RelationName.ToLower() == newRelName)
                    {
                        relNum++;
                        i = 0;
                    }
                }

                return RelationNamePrefix + relNum.ToString();
            }

            public static bool IsSqlServer(string conStr)
            {
                try
                {
                    System.Data.OleDb.OleDbConnection cn = new System.Data.OleDb.OleDbConnection(conStr);
                    return cn.Provider.ToUpper().Contains("SQLOLEDB");
                }
                catch
                {
                    return false;
                }
            }

            public static void DeleteTableOrView(string name, string conStr)
            {
                string SQL;

                if (IsTable(name, conStr))
                    SQL = "drop table [" + name + "]";
                else
                    SQL = "drop view [" + name + "]";

                SQL = VerifySQL(SQL, conStr);
                ExecuteSQL(SQL, conStr);
            }

            public static bool IsOracle(string ConnectionString)
            {
                return GetProvider(ConnectionString).ToLower().Contains("ora");
            }

            public static string VerifySQL(string SQL, string ConnectionString)
            {
                if (IsOracle(ConnectionString))
                    SQL = SQL.Replace("[", "\"").Replace("]", "\"");
                return SQL;
            }

            public static string RemoveProvider(string ConnectionString)
            {
                ConnectionString = ConnectionString.Substring(ConnectionString.IndexOf(";") + 1);

                return ConnectionString;
            }

           

            private static string ResolveInnerJoin(string DDL)
            {
                //TEST DDL = "select \"cit\".\"id\", \"cit\".\" inner join\" from \"cit\" inner join \"aa\"";
                int a, b;
                string tmp;
                List<string> list = new List<string>(DDL.Split('\"'));
                string output = "";
                string segment;
                for (int i = 0; i < list.Count - 1; i += 2)
                {
                    try
                    {
                        segment = list[i];
                        if (segment.Length < 10) continue;

                        a = 0;
                        b = -5;
                        while (true)
                        {
                            a = segment.IndexOf("INNER", b + 5, StringComparison.OrdinalIgnoreCase);
                            if (a == -1) break;
                            b = segment.IndexOf("JOIN", a + 6, StringComparison.OrdinalIgnoreCase);
                            if (b == -1) continue;

                            tmp = segment.Substring(a + 6, b - (a + 6));
                            if (tmp.Trim() == "")
                            {
                                segment = segment.Remove(a, 6);
                                segment = segment.Insert(a, " LEFT OUTER ");
                                list[i] = segment;
                            }
                        }
                    }
                    catch
                    {
                    }
                }

                for (int i = 0; i < list.Count - 1; i++)
                {
                    output += list[i] + "\"";
                }
                output += list[list.Count - 1];

                return output;
            }

            
        }
    }

