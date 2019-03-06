using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace MIS_2019.Models
{
    public class MenuModels
    {
        

        public int ObjectID { get; set; }
        public string ObjectName { get; set; }
        public string ObjectTitle { get; set; }
        public bool Separator { get; set; }
        public string ObjectType { get; set; }
        public string MenuTitle { get; set; }
        public string MainMnuName { get; set; }
        public string MnuName { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public bool CanPrint { get; set; }
        public bool CanBrows { get; set; }
        public bool ByBranch { get; set; }
        public bool Visible { get; set; }
        public bool MenuHidden { get; set; }
        public short MenuIndex { get; set; }
        public string HlpChmFile { get; set; }
        public string HlpHtmlFile { get; set; }
        public string HlpBkMark { get; set; }
        public string CriteriaFields { get; set; }
        public string CriteriaFieldsTables { get; set; }
        public string CriteriaFieldsBoundColumn { get; set; }
        public string CriteriaFieldsSources { get; set; }
        public string CriteriaFieldsTypes { get; set; }
        public string CriteriaFieldsCaptions { get; set; }
        public string CriteriaFieldsAlignments { get; set; }
        public string CriteriaFieldsWidths { get; set; }
        public string CriteriaFieldsOperators { get; set; }
        public string CriteriaFieldsUnique { get; set; }
        public string CFSourcesByBranch { get; set; }
        public string SortFieldsList { get; set; }
        public string Source { get; set; }
        public bool ConnectToSQL { get; set; }
        public bool OnlyCreateView { get; set; }
        public bool UseAndOnly { get; set; }
        public bool SendMinMaxDate { get; set; }
        public string FilterOn { get; set; }
        public string FilterOnFormula { get; set; }
        public string HotPrintForms { get; set; }
        public string SQLStatment { get; set; }
        public string JetStatment { get; set; }
        public string SqlNext { get; set; }
        public string JetNext { get; set; }
        public string ObjLanguage { get; set; }
        public byte[] Icon { get; set; }
    }
}