using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using TENX.Models;

namespace TENX_ADMIN
{
    public partial class Medee : System.Web.UI.Page
    {
        private string script;

        public object File1 { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {



        }

       
        protected void Save_Click(object sender, EventArgs e)
        {
            string garchig = gar.Value;
            string oruulsan = txtezen.Value;
            string tovch = tovchaguulga.Value;
            string type = select.Value;
            
            string path; /*= Server.MapPath("~/Uploads/");*/
            if (File2.HasFile)
            {

                File2.SaveAs(Server.MapPath("~/uploadImages/" + File2.FileName));
                path = File2.FileName;
                SystemGlobals.DataBase.ExecuteSQL("insert into News (TypePkID,Subject,UserPkID,ShortContent,ContentText,FilePath) values(N'" + type + "',N'" + garchig + "',N'" + oruulsan + "',N'" + tovch + "' ,N'" + editor.Text + "' ,N'" + path + "')");
            }

           
            
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Succesfully Inserted!');", true);
            //Response.Redirect(Request.Url.AbsoluteUri);

            string msgstring = "Мэдээ хадгалагдлаа!";
            string content = "window.onload=function(){ alert('";
            content += msgstring;
            content += "');";
            content += "window.location='";
            content += Request.Url.AbsoluteUri;
            content += "';}";

            ClientScript.RegisterStartupScript(this.GetType(), "SuccesMessage", content, true);

        }


        protected void Delete_Click(object sender, EventArgs e)
        {

        }

        protected void Update_Click(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ckcontent_TextChanged(object sender, EventArgs e)
        {

        }

    }
}