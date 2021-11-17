<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" debug="true" CodeBehind="Medee.aspx.cs" Inherits="TENX_ADMIN.Medee" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <form runat="server">
    <div class="container-full">
		<!-- Content Header (Page header) -->
		<div class="content-header">
			<div class="d-flex align-items-center">
				<div class="me-auto">
					<h4 class="page-title">Мэдээ оруулах</h4>
					<div class="d-inline-block align-items-center">
						<nav>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="#"><i class="mdi mdi-home-outline"></i></a></li>
								<li class="breadcrumb-item" aria-current="page">Мэдээ</li>
								<li class="breadcrumb-item active" aria-current="page">Мэдээ оруулах</li>
							</ol>
						</nav>
					</div>
				</div>				
			</div>
		</div>	  

		<!-- Main content -->
		<section class="content">

		 <!-- Basic Forms -->
		  <div class="box">
			<div class="box-header with-border">
			  <h4 class="box-title">Мэдээ оруулах</h4>
			  <h6 class="box-subtitle">Bootstrap Form Validation check the <a class="text-warning" href="http://reactiveraven.github.io/jqBootstrapValidation/">official website </a></h6>
			</div>
			<!-- /.box-header -->
			<div class="box-body">
			  <div class="row">
				<div class="col">
					<form novalidate="">
					  <div class="row">
						<div class="col-12">
							<div class="form-group">
								<h5>Мэдээний төрөл сонгох<span class="text-danger">*</span></h5>
								<div class="controls">
									<select name="select" id="select" runat="server" required="" class="form-select">						
										<option value="Хувьцаа">Хувьцаа</option>
										<option value="Бонд">Бонд</option>
										<option value="Койн">Койн</option>										
									</select>
								<div class="help-block"></div></div>
							</div>								
							<div class="form-group">
								<h5>Гарчиг <span class="text-danger">*</span></h5>
								<div class="controls">
									<input type="text" id="gar" runat="server" name="text" class="form-control" required="" data-validation-required-message="This field is required"> 
								<div class="help-block"></div></div>
								<div class="form-control-feedback"><small>Add <code>required</code> attribute to field for required validation.</small></div>
							</div>
							<div class="form-group">
								<h5>Оруулсан эзэн <span class="text-danger">*</span></h5>
								<div class="controls">
									<%--<asp:TextBox ID="Text1" runat="server"   ></asp:TextBox>--%>
									<input type="text" id="txtezen" runat="server" name="text" class="form-control" required="" data-validation-required-message="This field is required"> 
								<div class="help-block"></div></div>
								<div class="form-control-feedback"><small>Add <code>required</code> attribute to field for required validation.</small></div>
							</div>
							<div class="form-group">
								<h5>Товч агуулга <span class="text-danger">*</span></h5>
								<div class="controls">
									<input type="text" name="text" id="tovchaguulga" runat="server" class="form-control" required="" data-validation-required-message="This field is required"> 
								<div class="help-block"></div></div>
								<div class="form-control-feedback"><small>Add <code>required</code> attribute to field for required validation.</small></div>
							</div>
							 <h1>Агуулга</h1>
                          <%--<div id="editor1" runat="server" class="ckeditor">
                           
                          </div>--%>
							<asp:TextBox ID="editor" name="editor" runat="server" TextMode="MultiLine" Columns="60" Rows="10" class="ckeditor"></asp:TextBox>
							<div class="form-group">
								<h5>Зураг <span class="text-danger">*</span></h5>
								<div class="controls">									
									<asp:FileUpload ID="File2" runat="server"  text="Зураг оруулах" class="form-control" />
									<%--<input type="file" id="File1" name="file" class="form-control" required=""> --%>
								<div class="help-block"></div></div>
							</div>
							
						
						</div>
						
					  </div>
					<div class="text-xs-right">
							<button type="submit" onserverclick="Save_Click"   runat="server" class="btn btn-primary"><i class="ti-save-alt"></i> Хадгалах </button>
						</div>
						
						</form>

				</div>
				<!-- /.col -->
			  </div>
			  <!-- /.row -->
			</div>
			<!-- /.box-body -->
		  </div>
		  <!-- /.box -->

		</section>
		<!-- /.content -->
	  </div>
	  
	
						
					</form>
	<script src="assets/js/vendors.min.js"></script>
    <script src="assets/icons/feather-icons/feather.min.js"></script>
	<script src="ckeditor/ckeditor.js"></script>
    <script src="assets/js/template.js"></script>
	<script>
        ClassicEditor
            .create(document.querySelector('#ContentPlaceHolder1_editor'))
            .catch(error => {
                console.error(error);
            });
    </script>
</asp:Content>
