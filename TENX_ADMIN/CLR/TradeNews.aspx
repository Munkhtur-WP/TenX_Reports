<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TradeNews.aspx.cs" Inherits="TENX_ADMIN.CLR.TradeNews" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Арилжааны мэдээ</h1>

    <form runat="server" oninit="getData_Init">


        <h3>Арилжааны Тайлан </h3>
        <hr />
        <div class="m-3">
            <table>
                <tbody>
                    <tr>
                        <td>
                            <div class="m-2">
                                <label>Огноогоор шүүлт хийх</label>
                            </div>
                        </td>
                        <td>
                            <input type="date" id="startDate" min="2000-01-01"
                                max="2100-12-31" class="form-control text-center" runat="server">
                        </td>

                        <td>
                            <asp:Button Text="show report button" runat="server" OnClick="getData_Init" class="btn btn-primary btn-sm" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>


        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="True" Width="100%" Height="100%" BackColor="White">
        </rsweb:ReportViewer>

    </form>

    <script src="../assets/js/vendors.min.js"></script>
    <script src="../assets/icons/feather-icons/feather.min.js"></script>
    <script src="../ckeditor/ckeditor.js"></script>
    <script src="../assets/js/template.js"></script>

</asp:Content>
