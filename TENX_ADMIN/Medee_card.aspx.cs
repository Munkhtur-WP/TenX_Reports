using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using TENX.Models;

namespace TENX_ADMIN
{
    public partial class Medee_card : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        public DataTable getNewsList()
        {
            return SystemGlobals.DataBase.ExecuteSQL("select * from News").Tables[0];
        }
        

        }
}