using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TENX.Models;
using System.Data.SqlClient;

namespace TENX_Admin
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserPkID"] = "1";
        }

        public DataTable MenuTable()
        {
            return SystemGlobals.DataBase.ExecuteSQL("select * from smmWebMenuInfo where len(MenuInfoCode)=2 and isnull(UrlAddress,'')='' and CreatedModuleID='BRC' order by SortedOrder").Tables[0];

        }
        public DataTable SubMenuTable(string MenuInfoCode)
        {
            return SystemGlobals.DataBase.ExecuteSQL("select * from smmWebMenuInfo where len(MenuInfoCode)=4 and isnull(UrlAddress,'')='' and CreatedModuleID='BRC' and MenuInfoCode like '" + MenuInfoCode+"%' order by SortedOrder").Tables[0];

        }

        public DataTable SubMenuTableList(string MenuInfoCode)
        {
            return SystemGlobals.DataBase.ExecuteSQL("select * from smmWebMenuInfo where len(MenuInfoCode)=4 and isnull(UrlAddress,'')<>'' and CreatedModuleID='BRC' and MenuInfoCode like '" + MenuInfoCode + "%' order by SortedOrder").Tables[0];
        }

        public DataTable SubMenuTableLastList(string MenuInfoCode)
        {
            return SystemGlobals.DataBase.ExecuteSQL("select * from smmWebMenuInfo where len(MenuInfoCode)=6 and isnull(UrlAddress,'')<>'' and CreatedModuleID='BRC' and MenuInfoCode like '" + MenuInfoCode + "%' order by SortedOrder").Tables[0];
        }
    }

}