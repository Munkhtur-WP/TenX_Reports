using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TENX.Models;
using System.IO;
using System.Drawing;

namespace TENX_ADMIN
{
    public partial class reportClearing : System.Web.UI.Page
    {
        protected string tdate { get; set; }
        protected string sdate;
        protected string si;
        protected string sa;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Test();
            //}
            tdate = DateTime.Now.ToString("yyyy-MM-dd");
            tdate += "T";

            tdate += DateTime.Now.ToString("HH:mm");

            sdate = DateTime.Now.AddDays(-1).ToString(@"yyyy-MM-dd");
            sdate += "T";

            sdate += DateTime.Now.ToString("HH:mm");

            

        }
        private void Test()

        {
            //string mainconn = ConfigurationManager.ConnectionStrings["Tenx19ConnectionString"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //SqlCommand sqlcomm = new SqlCommand("getclearingreport", sqlconn);
            //sqlcomm.CommandType = CommandType.StoredProcedure;
            //sqlconn.Open();
            //sqlcomm.Parameters.AddWithValue("@start", TxtStartDate.Text);
            //sqlcomm.Parameters.AddWithValue("@start", TxtEndDate.Text);
            
            
            
            DataSet dt = SystemGlobals.DataBase.ExecuteSQL("select * from Banks where Modified between '" + si + "' and '" + sa + "'");// where Modified between '" + TxtStartDate.Value + "'and'" + TxtEndDate.Value + "'

            DataTable da = new DataTable("table1");

            da = dt.Tables[0];
                        
            GridView1.DataSource = da;
            GridView1.DataBind();
           
            //Нийт тоо, үнэ ...

            //int total = da.AsEnumerable().Sum(row => row.Field<Int32>("BankID"));
            //GridView1.FooterRow.Cells[1].Text = "Нийт";
            //GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[2].Text = total.ToString("N2");
            //GridView1.FooterRow.Cells[6].Text = total.ToString("N2");

            //string mainconn = ConfigurationManager.ConnectionStrings["Tenx19ConnectionString"].ConnectionString;
            //SqlConnection sqlconn = new SqlConnection(mainconn);
            //SqlCommand sqlcomm = new SqlCommand("getclearingreport", sqlconn);
            //sqlcomm.CommandType = CommandType.StoredProcedure;
            //sqlconn.Open();
            //DateTime startd = TxtStartDate.Value;
            //string endd = TxtEndDate.Value;
            //sqlcomm.Parameters.Add(new SqlParameter("@start", SqlDbType.DateTime) { Value = TxtStartDate.Value.ToString("yyyy-MM-dd") });

            //sqlcomm.Parameters.AddWithValue("@end", endd);
            //SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //sqlcomm.ExecuteNonQuery();
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

            //int total = dt.AsEnumerable().Sum(row => row.Field<Int32>("BankID"));
            //GridView1.FooterRow.Cells[1].Text = "Нийт";
            //GridView1.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
            //GridView1.FooterRow.Cells[2].Text = total.ToString("N2");
            //GridView1.FooterRow.Cells[6].Text = total.ToString("N2");

            //sqlconn.Close();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Test();
        }
        protected void Clear_View(object sender, EventArgs e)
        {
            //GetData();
            si = Request.Form["startdate"];

            sa = Request.Form["enddate"];
            si = si.Replace("T", " ");
            sa = sa.Replace("T", " ");
            Label1.Text = si;

            Test();
            
        }
        
        protected void Export_Excel(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.Buffer = true;
            //Response.ContentType = "application/ms-excel";
            //Response.AddHeader("content-disposition", "attachment; filename=Clearing-" + DateTime.Now.ToShortDateString() + ".xls");
            //Response.Charset = "";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //GridView1.RenderControl(htw);
            //Response.Output.Write(sw.ToString());
            //Response.End();

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Clearing-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
            Response.Charset = "";
            Response.ContentType = "application/ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                GridView1.AllowPaging = false;
                this.Test();

                GridView1.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in GridView1.HeaderRow.Cells)
                {
                    cell.BackColor = GridView1.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in GridView1.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = GridView1.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                GridView1.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }

            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=ExportData1.xls");
            //Response.Charset = "";
            //Response.ContentType = "application/ms-excel";
            //StringWriter StringWriter = new System.IO.StringWriter();
            //HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(StringWriter);

            ////batigol
            //GridView1.AllowPaging = false;
            //DataSet dt = SystemGlobals.DataBase.ExecuteSQL("select * from BrokersCustomer");

            //DataTable da = new DataTable("table1");

            //da = dt.Tables[0];
            //GridView1.DataSource = da;
            //GridView1.DataBind();
            ////

            //GridView1.RenderControl(HtmlTextWriter);
            //Response.Write(StringWriter.ToString());
            //Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            
               

            
        }
    }
}