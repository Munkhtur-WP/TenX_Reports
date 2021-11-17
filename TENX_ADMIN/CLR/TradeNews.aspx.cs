using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TENX.Models;

namespace TENX_ADMIN.CLR
{
    public partial class TradeNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void getData_Init(object sender, EventArgs e)
        {
            getData();
        }

        public void getData()
        {
            string XML = "<NewDataSet><BusinessObject><StartDate>" + startDate.Value + "</StartDate></BusinessObject></NewDataSet>";

            DataSet dt = SystemGlobals.DataBase.ExecuteQuery("sp_TradeReportData", XML);

            Console.WriteLine(dt);

            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("reports/TradeNews_rpt.rdlc");
            ReportDataSource datasource = new ReportDataSource("TradeNewsData", dt.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.SizeToReportContent = true;

            ReportViewer1.LocalReport.Refresh();
        }

    }
}