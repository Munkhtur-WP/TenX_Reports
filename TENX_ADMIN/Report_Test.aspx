<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Report_Test.aspx.cs" Inherits="TENX_ADMIN.Report_Test" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <form runat="server">

	   <div class="container-full">
		<!-- Content Header (Page header) -->
		<div class="content-header">
			<div class="d-flex align-items-center">
				<div class="me-auto">
					<h4 class="page-title">Тайлан жагсаалт</h4>
					<div class="d-inline-block align-items-center">
						<nav>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="#"><i class="mdi mdi-home-outline"></i></a></li>
								<li class="breadcrumb-item" aria-current="page">Тайлан</li>
								<li class="breadcrumb-item active" aria-current="page">Цагийн үеийн топ 10 мэдээний тайлан</li>
							</ol>
						</nav>
					</div>
				</div>
				
			</div>
		</div>

		<!-- Main content -->
		<section class="content">

		  <!-- START Card With Image -->			
			<div class="card">
			  <div class="card-header">
				<h4 class="card-title">Тайлан</h4>
			  </div>
			</div>

			<div id="test12"></div>

			<div class="btn-groupwp">
  <!-- add buttons to this group -->

</div>
			<div><asp:Panel ID="Panel1" runat="server"></asp:Panel></div>

		  <div class="row">
			  <div class="col-12">
				<div class="box">
			  
			  
                   <div class="box-body">
					   <asp:Button ID="Button1" OnClick="Report_view"   runat="server" class="btn btn-primary" Text="Button" />
						   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		      <br />
					
					<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="900px" Height="700px" AsyncRendering="True"> 
						
                    </rsweb:ReportViewer>
					            </div>
							</div>
					 </div>
			   </div>
		  </div>
		  <!-- /.row -->
		  <!-- END Card with image -->

		</section>
		<!-- /.content -->
	  </div>

   
	  
	
						
					</form>

   
	  
	
						
					
	<script src="assets/js/vendors.min.js"></script>
    <script src="assets/icons/feather-icons/feather.min.js"></script>
	<script src="ckeditor/ckeditor.js"></script>
    <script src="assets/js/template.js"></script>	
</asp:Content>

