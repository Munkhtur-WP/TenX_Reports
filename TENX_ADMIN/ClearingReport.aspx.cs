using Microsoft.Reporting.WebForms;
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
    public partial class ClearingReport : System.Web.UI.Page
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
            string XML = "<NewDataSet><BusinessObject><StartDate>" + dteStartDate.Value + "</StartDate>"
                    + "<FinishDate>" + dteFinishDate.Value + "</FinishDate></BusinessObject></NewDataSet>";
            DataTable dt = SystemGlobals.DataBase.ExecuteQuery("sp_TradeReportData", XML).Tables[0];

            /*   DataSet dt = SystemGlobals.DataBase.ExecuteSQL("select * from OriginsAvg");*/
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("CLR/reports/Clearing_rpt.rdlc");
            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.Width = Unit.Percentage(200);
            ReportViewer1.Height = Unit.Percentage(200);
            //ReportViewer1.SizeToReportContent = true;

            ReportViewer1.LocalReport.Refresh();
        }
    }
}