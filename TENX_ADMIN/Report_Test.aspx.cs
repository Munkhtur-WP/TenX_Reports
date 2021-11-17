using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TENX.Models;

namespace TENX_ADMIN
{
    public partial class Report_Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            
            

         
        }
        protected void Report_view(object sender, EventArgs e)
        {
            //WebReport1.ReportFile = this.Server.MapPath("~/Filtering with Date Ranges.frx");
            GetData();
        }
        private void GetData()
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Tenx19ConnectionString2"].ConnectionString);
            //SqlDataAdapter da = new SqlDataAdapter("select * from News", con);

            //DataTable dt = new DataTable("table1");
            //da.Fill(dt);
            //ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");
            //ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(datasource);
            //ReportViewer1.LocalReport.Refresh();

            DataSet dt = SystemGlobals.DataBase.ExecuteSQL("select * from News");            

            DataTable da = new DataTable("table1");

            da = dt.Tables[0];
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");
            ReportDataSource datasource = new ReportDataSource("DataSet1", da);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            //ReportViewer1.LocalReport.Refresh();
        }
    }
}