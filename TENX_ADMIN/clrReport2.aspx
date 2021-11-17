<%@ Page Language="C#"  MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="clrReport2.aspx.cs" Inherits="TENX_ADMIN.clrReport2" %>
 <%--Settlement Report - Биелсэн Хэлцлийн тайлан --%>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form runat="server">

	   
		<!-- Content Header (Page header) -->
		<div class="content-header">
			<div class="d-flex align-items-center">
				<div class="me-auto">
					<h4 class="page-title">Тайлан жагсаалт</h4>
					<div class="d-inline-block align-items-center">
						<nav>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="index.aspx"><i class="mdi mdi-home-outline"></i></a></li>
								<li class="breadcrumb-item" aria-current="page">Тайлан</li>
								<li class="breadcrumb-item active" aria-current="page">Биелсэн хэлцлийн мэдээ</li>
							</ol>
						</nav>
					</div>
				</div>
				
			</div>
		</div>

		<!-- Main content -->
		<section class="content">
			<div class="row">
		  <div class="col-lg-12 col-12">
                <!-- Basic Forms -->
                <div class="box">
                    <div class="box-header with-border">
                        <h4 class="box-title">Биелсэн хэлцлийн мэдээ</h4>
			  </div>
					 <div class="box-body" wrap="False">
                        <div class="row">
                            <div class="col-12">

                                <div class="form-group row">

                                    <label for="example-datetime-local-input" class="col-sm-2 col-form-label">Эхлэх Огноо</label>
                                    <div class="col-sm-3">
										
                                        <input class="form-control text-center"  type="date" min="2000-01-01"
                                                max="2100-12-31"   id="dteStartDate"  runat ="server">
										<%--<asp:TextBox ID="Box1" class="form-control" type="datetime-local" runat="server" TextMode="DateTime"></asp:TextBox>--%>
                                    </div>
									<div class="col-sm-7"></div>
									<label for="example-datetime-local-input" class="col-sm-2 col-form-label">Төгсөх Огноо</label>
                                    <div class="col-sm-3">
                                        <input class="form-control text-center"  type="date"  id="dteFinishDate" 
                                           min="2000-01-01"   max="2100-12-31" runat="server">
                                    <%--<asp:TextBox ID="Box2" class="form-control" type="datetime-local" runat="server" TextMode="DateTime"></asp:TextBox>--%>
									</div>
                                </div>
                                <div class="form-group row">
                                    <label for="example-datetime-local-input" class="col-sm-3 col-form-label"></label>
									
                                     <div class="col-sm-3">
                                    <button type="submit" onserverclick="getData_Init" runat="server"  id="btn1" class="btn btn-primary">
                                    <i class="ti-save-alt"></i> Хайх
                                </button>
                                         </div>
                                    </div>
							
								</br>
								
								
								<%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
								<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"></rsweb:ReportViewer>
								--%>
                            </div>
                            <!-- /.col -->
                        </div>

                        
                        <!-- /.row -->
                    </div>
			</div>
		

		 <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div id="rollbar" style="overflow-x: scroll; overflow-y: scroll; height: 500px;">
            <rsweb:ReportViewer ID="ReportViewer1" 
                                runat="server" 
                                AsyncRendering="false" 
                                SizeToReportContent="true" 
                                BackColor="White"
                                ZoomMode="PageWidth"
                                Width="100%" 
                                
                                PageCountMode="Actual"
                >
<%--                                 Width="100%" 
                                Height="1000px" --%>
                                
            </rsweb:ReportViewer>
                    </div>
                </ContentTemplate>
                 </asp:UpdatePanel>
        </div>
              </div>
				</div>
			</section>
	</form>

      

	<script src="assets/js/vendors.min.js"></script>
    <script src="assets/icons/feather-icons/feather.min.js"></script>
    <script src="assets/js/template.js"></script>	
</asp:Content>
