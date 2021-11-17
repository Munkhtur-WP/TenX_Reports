<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" debug="true" CodeBehind="Medee_card.aspx.cs" Inherits="TENX_ADMIN.Medee_card" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <form runat="server">

	   <div class="container-full">
		<!-- Content Header (Page header) -->
		<div class="content-header">
			<div class="d-flex align-items-center">
				<div class="me-auto">
					<h4 class="page-title">Мэдээний жагсаалт</h4>
					<div class="d-inline-block align-items-center">
						<nav>
							<ol class="breadcrumb">
								<li class="breadcrumb-item"><a href="#"><i class="mdi mdi-home-outline"></i></a></li>
								<li class="breadcrumb-item" aria-current="page">Мэдээ</li>
								<li class="breadcrumb-item active" aria-current="page">Цагийн үеийн топ 10 мэдээ</li>
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
				<h4 class="card-title">Мэдээний жагсаалт</h4>
			  </div>
			</div>

			<div id="test12"></div>

			<div class="btn-groupwp">
  <!-- add buttons to this group -->

</div>
			<div><asp:Panel ID="Panel1" runat="server"></asp:Panel></div>

		  <div class="row">
			  <% foreach (System.Data.DataRow rw in getNewsList().Rows)
                  {
					  %>
			  <div class="col-md-12 col-lg-4">
				<div class="card">
					<div class="card-header d-flex justify-content-between">
						<span><i class="fa fa-user me-2"></i> <a href="#"><%=rw["UserPkID"].ToString() %></a></span>
						<span class="text-muted"><% string postdate = (rw["CreatedDate"].ToString()); string strDate = postdate.ToString(); DateTime currentDate = DateTime.Now;  %><% DateTime loadedDate = DateTime.Parse(postdate);; %><%TimeSpan timegap = currentDate - loadedDate;%><% string message=""; message = string.Concat((timegap.Hours));%><%if (timegap.Days > 365)
    {
        message = string.Concat((((timegap.Days) / 30) / 12), " жилийн өмнө нийтлэгдсэн");
    }
    else if (timegap.Days > 31)
    {
        message = string.Concat(((timegap.Days) / 30), " сарын өмнө нийтлэгдсэн");
    }
    else if (timegap.Days > 1)
    {
        message = string.Concat("Posted ", timegap.Days, " өдрийн өмнө нийтлэгдсэн");
    }
    else if (timegap.Days == 1)
    {
        message = "өчигдөр нийтлэгдсэн";
    }
    else if (timegap.Hours >= 2)
    {
        message = string.Concat(timegap.Hours, " цагын өмнө нийтлэгдсэн");
    }
    else if (timegap.Hours >= 1)
    {
        message = " цагын амнө нийтлэгдсэн";
    }
   
    else if (timegap.Minutes >= 1)
    {
        message = string.Concat( timegap.Minutes, " минутын өмнө нийтлэгдсэн");
    }
    
    else
    {
        message = " саяхан нийтлэгдсэн";
    } %><% =  message %></span>
					</div>
				  <img class="card-img-top bter-0 btsr-0" src="<%="uploadImages//"+rw["FilePath"].ToString() %>" alt="Card image cap">
				  <div class="card-body">
					<h4 class="card-title"><%=rw["Subject"].ToString() %></h4>
					<p class="card-text"><%=rw["ShortContent"].ToString() %></p>
				  </div>
				  
				</div>
			</div>
			  <%
				  }%>
			  
			  
			  

			  
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
