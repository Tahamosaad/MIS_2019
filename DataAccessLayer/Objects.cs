//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using global::System;
        using global::System.Collections.Generic;
    
    public partial class Objects
    {

        public Objects()
        {
            this.UserRights = new HashSet<UserRights>();
        }
    
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
    
 
        public virtual ICollection<UserRights> UserRights { get; set; }
    }
}
