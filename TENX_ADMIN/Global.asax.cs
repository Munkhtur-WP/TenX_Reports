using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using TENX.Models;

namespace TENX_ADMIN
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                var conn = ConfigurationManager.ConnectionStrings["serviceCon"].ConnectionString;
                var csb = new SqlConnectionStringBuilder(conn);

                SystemGlobals.DataBase = new TENX.Models.CDataBase();
                SystemGlobals.DataBase.DataBaseName = csb.InitialCatalog;
                SystemGlobals.DataBase.ServerName = csb.DataSource;
                SystemGlobals.DataBase.UserName = csb.UserID;
                SystemGlobals.DataBase.Password = csb.Password;
                //SystemGlobals.ContractTypeId = 0; // end 1 oruulbal features heltsel garna
               // Session["ContractTypeId"] = 0;
                //DataTable dt = SystemGlobals.DataBase.ExecuteSQL("select * from smmConfig where ConfigID='FooterForm' and ModuleID='APP'").Tables[0];
                //SystemGlobals.FooterTitleText = dt.Rows[0]["ConfigValue"].ToString();

                //dt = SystemGlobals.DataBase.ExecuteSQL("select * from smmConfig where ConfigID='HeaderTitleForm' and ModuleID='APP'").Tables[0];
                //SystemGlobals.HeaderTitleText = dt.Rows[0]["ConfigValue"].ToString();
                //RegisterRoute(RouteTable.Routes);

            }
            catch
            {

            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

    }
}