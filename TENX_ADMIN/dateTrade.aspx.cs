using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TENX.Models;

namespace TENX_ADMIN
{
    public partial class dateTrade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public DataTable DateList()
        {
            return SystemGlobals.DataBase.ExecuteSQL("select * from TENX_TRADING.dbo.FinishStep").Tables[0];
        }
    }
}