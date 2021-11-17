<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StatisticReport.aspx.cs" Inherits="TENX_ADMIN.CLR.StaticReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Статистик мэдээ</h1>

    <form runat="server" oninit="getData_Init">

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
