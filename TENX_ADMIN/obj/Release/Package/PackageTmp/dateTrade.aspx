<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="dateTrade.aspx.cs" Inherits="TENX_ADMIN.dateTrade" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-header">
        <div class="d-flex align-items-center">
            <div class="me-auto">
                <h4 class="page-title">Арилжааны өдөр шилжүүлэх</h4>
                <div class="d-inline-block align-items-center">
                    <nav>
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="#"><i class="mdi mdi-home-outline"></i></a></li>
                            <li class="breadcrumb-item" aria-current="page">Оператор</li>
                            <li class="breadcrumb-item active" aria-current="page">Өдөр шилжүүлэх</li>
                        </ol>
                    </nav>
                </div>
            </div>

        </div>
    </div>
    <section class="content">
        <div class="row">
            <div class="col-lg-12 col-12">
                <!-- Basic Forms -->
                <div class="box">
                    <div class="box-header with-border">
                        <h4 class="box-title">Өдөр шилжүүлэх</h4>
                    </div>
                    <!-- /.box-header -->
                    <div class="box-body">
                        <div class="row">
                            <div class="col-12">

                                <div class="form-group row">
                                    <label for="example-datetime-local-input" class="col-sm-2 col-form-label">Огноо</label>
                                    <div class="col-sm-10">
                                        <input class="form-control" type="datetime-local" value="2011-08-19T13:45:00" id="example-datetime-local-input">
                                    </div>

                                </div>
                                <div class="form-group row">
                                    <label for="example-datetime-local-input" class="col-sm-2 col-form-label"></label>
                                     <div class="col-sm-10">
                                    <button type="submit" class="btn btn-primary">
                                    <i class="ti-save-alt"></i>Шилжүүлэх
                                </button>
                                         </div>
                                    </div>

                                

                            </div>
                            <!-- /.col -->
                        </div>

                        <div class="table-responsive">
					<table class="table table-bordered table-striped">
					  <thead>
						<tr>
						  <th>Төлөв</th>
						  <th class="text-center">
							Ажилбар
						  </th>
						  <th class="text-center">
							Тайлбар
						  </th>						 
						</tr>
					  </thead>
					  <tbody>
                          <%
                              foreach (System.Data.DataRow rw in DateList().Rows)
                              { 
                                  %>
                                      <tr>
						                <td><input type="checkbox" id="basic_checkbox_2" class="filled-in" checked=""><label for=%"rw["WorkName"].ToString()"%></label></td>
						                <td><%=rw["WorkName"].ToString() %></td>
						                <td><%=rw["StatusText"].ToString() %></td>						  
						            </tr>
                              <%
                              }
                              %>
						
						
					  </tbody>
					</table>
				</div>
                        <!-- /.row -->
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
        </div>
    </section>
    <script src="assets/js/vendors.min.js"></script>
    <script src="assets/icons/feather-icons/feather.min.js"></script>

    <script src="assets/js/template.js"></script>

</asp:Content>
