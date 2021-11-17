<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="reportClearing.aspx.cs" Inherits="TENX_ADMIN.reportClearing" EnableEventValidation = "false"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
								<li class="breadcrumb-item active" aria-current="page">Клирингийн Тайлан</li>
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
                        <h4 class="box-title">Клирингийн Тайлан</h4>
			  </div>
					 <div class="box-body" wrap="False">
                        <div class="row">
                            <div class="col-12">

                                <div class="form-group row">
                                    <label for="example-datetime-local-input" class="col-sm-2 col-form-label">Эхлэх Огноо</label>
                                    <div class="col-sm-3">
                                        <input class="form-control"  type="datetime-local" value="<%=sdate %>"  id="TxtStartDate" name="startdate">
										<%--<asp:TextBox ID="Box1" class="form-control" type="datetime-local" runat="server" TextMode="DateTime"></asp:TextBox>--%>
                                    </div>
									<div class="col-sm-7"></div>
									<label for="example-datetime-local-input" class="col-sm-2 col-form-label">Төгсөх Огноо</label>
                                    <div class="col-sm-3">
                                        <input class="form-control"  type="datetime-local" value="<%=tdate %>" id="TxtEndDate" name="enddate">
                                    <%--<asp:TextBox ID="Box2" class="form-control" type="datetime-local" runat="server" TextMode="DateTime"></asp:TextBox>--%>
									</div>
                                </div>
                                <div class="form-group row">
                                    <label for="example-datetime-local-input" class="col-sm-3 col-form-label"></label>
									
                                     <div class="col-sm-3">
                                    <button type="submit" onserverclick="Clear_View" runat="server"  class="btn btn-primary">
                                    <i class="ti-save-alt"></i> Хайх
                                </button>
                                         </div>
                                    </div>
								<div class="col-xl-4">
								   
									<div class="btn-group">
									  <button class="btn btn-rounded btn-primary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false"><i class="icon ti-settings"></i> Татах</button>
									  <div class="dropdown-menu dropdown-menu-end" style="">
										<a class="dropdown-item" onserverclick="Export_Excel" runat="server" href="#">Excel</a>
										<a class="dropdown-item" href="#">PDF</a>
										<a class="dropdown-item" href="#">Something else here</a>
									  </div>	
							      </div>
						        </div>
								</br>
								<style type="text/css">
									 
										
										.column{
											border-left: 1px solid grey;
											
										}
										.headb{
											border-bottom:2px solid grey;
											border-top:2px solid grey;
											text-align: center;
										}
										
										.GridPager td, th{
											border-left: none;
											padding: 1px 5px 1px 5px;
										}
										.GridPager a, .GridPager span
												 {
												display: block;
												height: 25px;
												width: 25px;
												font-weight: bold;
												text-align: center;
												text-decoration: none;
												
												
											}
											.GridPager a
											{
												background-color: #f5f5f5;
												color: #969696;
												border: 1px solid #969696;
											}
											.GridPager span
											{
												background-color: #A1DCF2;
												color: #000;
												border: 1px solid #3AC0F2;
											}
											.itemw{
												width: 50px;
											}
											td, th {
											padding: 1px 10px 1px 10px; /* puts vertical spacing between rows */
											border-left: 1px solid grey;
											}
									
								</style>
								<div style="overflow: auto ;height: 470px; width: 100%">
						<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
							<asp:UpdatePanel ID="panel1" runat="server"><ContentTemplate>
								<asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="false" BackColor="White"  
									AlternatingRowStyle-BackColor="Silver" HeaderStyle-BackColor="#FFA800"  Font-Strikeout="False" 
									ForeColor="Black"   AllowPaging="True"  ShowFooter="true"
									OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" PageIndex="0">
								<AlternatingRowStyle BackColor="Silver" Wrap="False"></AlternatingRowStyle>

									<Columns>
										<asp:TemplateField HeaderText="№" ItemStyle-Width="60px">
											
										 <ItemTemplate >
											
										   <%# Container.DataItemIndex + 1 %>
												
										</ItemTemplate>
											
										</asp:TemplateField>
										
										<asp:BoundField DataField="Modified" HeaderText="Огноо" > 										
										
										
										</asp:boundField>
										<asp:BoundField DataField="BankCode" HeaderText="Хэлцлийн дугаар" DataFormatString="{0:N2}">
											
										</asp:boundField>
										<asp:BoundField DataField="BankName" HeaderText="Тоо хэмжээ" />
										<asp:BoundField  DataField="State"    HeaderText="Нэгжийн үнэ" />
										<asp:BoundField DataField="Modified" HeaderText="Нийт үнэ"  >
											
                                        </asp:BoundField>
										<asp:BoundField DataField="BankID" HeaderText="Төлөв" />
										<asp:BoundField DataField="BankCode" HeaderText="Хувьцааны нэр" />
										<asp:BoundField DataField="BankName" HeaderText="Хувьцааны код" />
										<asp:BoundField DataField="State" HeaderText="Авах Брокерийн код" />
										<asp:BoundField DataField="Modified" HeaderText="Авах дансны дугаар" />
										<asp:BoundField DataField="BankID" HeaderText="Авах харилцагчийн нэр" />
										<asp:BoundField DataField="BankCode" HeaderText="Авах захиалгийн дугаар" />
										<asp:BoundField DataField="BankName" HeaderText="Авах харилцагчийн регистр" />
										<asp:BoundField DataField="State" HeaderText="Зарах Брокерийн код" />
										<asp:BoundField DataField="Modified" HeaderText="Зарах дансны дугаар" />
										<asp:BoundField DataField="BankID" HeaderText="Зарах харилцагчийн нэр" />
										<asp:BoundField DataField="BankCode" HeaderText="Зарах захиалгийн дугаар" />
										<asp:BoundField DataField="BankName" HeaderText="Зарах харилцагчийн регистр" />
									</Columns>

										<HeaderStyle BackColor="#FFA800" CssClass="headb"></HeaderStyle>
										<%--<PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="first" LastPageText="last" /> --%> 
									<FooterStyle BackColor="yellow" cssclass="headb" />
								    <PagerStyle BackColor="#FFA800" CssClass="GridPager" BorderStyle="Solid" BorderColor="Black" BorderWidth="1px" ForeColor="Black" HorizontalAlign="Justify" Font-Underline="False" Font-Strikeout="False" Font-Overline="False" Wrap="False" Font-Size="Medium" />
									
								</asp:GridView>
								</ContentTemplate></asp:UpdatePanel>
									</div>
								<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
								<%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
								<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"></rsweb:ReportViewer>
								--%>
                            </div>
                            <!-- /.col -->
                        </div>

                        
                        <!-- /.row -->
                    </div>
			</div>
		</div>
				</div>
			</section>
	</form>

	<script src="assets/js/vendors.min.js"></script>
    <script src="assets/icons/feather-icons/feather.min.js"></script>
    <script src="assets/js/template.js"></script>	
</asp:Content>
