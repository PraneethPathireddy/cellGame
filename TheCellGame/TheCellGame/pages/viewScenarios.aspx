<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewScenarios.aspx.cs" Inherits="TheCellGame.pages.viewScenarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	 <!-- Required meta tags -->
      <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
      <title>Home</title>
      <link rel="stylesheet" href="../node_modules/font-awesome/css/font-awesome.min.css" />
      <link rel="stylesheet" href="../node_modules/perfect-scrollbar/dist/css/perfect-scrollbar.min.css" />
      <link rel="stylesheet" href="../css/style.css"/>
      <link rel="shortcut icon" href="../images/favicon.png"/>
</head>
<body>
    
	<form id="form1" runat="server">
    
	<div class=" container-scroller">
        <!--Navbar-->
        <nav class="navbar bg-primary-gradient col-lg-12 col-12 p-0 fixed-top navbar-inverse d-flex flex-row">
            <div class="bg-white text-center navbar-brand-wrapper">
                <a class="navbar-brand brand-logo-mini" href="#"><img src="images/cell_logo.jpg" alt=""/></a>
            </div>
            <div class="navbar-menu-wrapper d-flex align-items-center">
                <button class="navbar-toggler navbar-toggler hidden-md-down align-self-center mr-3" type="button" data-toggle="minimize">
                  <span class="navbar-toggler-icon"></span>
                </button>
                <ul class="navbar-nav ml-lg-auto d-flex align-items-center flex-row">
                </ul>
                <button class="navbar-toggler navbar-toggler-right hidden-lg-up align-self-center" type="button" data-toggle="offcanvas">
                  <span class="navbar-toggler-icon"></span>
                </button>
            </div>
        </nav>
        <!--End navbar-->
        <div class="container-fluid">
            <div class="row row-offcanvas row-offcanvas-right">
                <nav class="bg-white sidebar sidebar-fixed sidebar-offcanvas" id="sidebar">
                    <ul class="nav">
					    <br><br><br><br>
                        <li class="nav-item active">
                            <a class="nav-link" href="adminHome.aspx">
                                <!-- <i class="fa fa-dashboard"></i> -->
                                <img src="../images/icons/1.png" alt=""/>
                                <span class="menu-title">Home</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="play.aspx">
                                <img src="../images/icons/2.png" alt=""/>
                                <span class="menu-title">Play</span>
                            </a>
                        </li>
						 <li class="nav-item">
                            <a class="nav-link" href="viewScenarios.aspx">
                                <img src="../images/icons/2.png" alt=""/>
                                <span class="menu-title">Scenarios</span>
                            </a>
                        </li>
						 <li class="nav-item">
                            <a class="nav-link" href="changePassword.aspx">
                                <!-- <i class="fa fa-bold"></i> -->
                                <img src="../images/icons/10.png" alt=""/>
                                <span class="menu-title">Change Passowrd</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="../login.aspx">
                                <!-- <i class="fa fa-table"></i> -->
                                <img src="../images/icons/5.png" alt=""/>
                                <span class="menu-title">Logout</span>
                            </a>
                        </li>                        
                    </ul>
                </nav>
                <!-- SIDEBAR ENDS -->
                
                <div class="content-wrapper">
                   
				   <h3 class="text-primary mb-4">Welcome to the CellGame project</h3>
                    <div class="row mb-2">
                        <div class="col-lg-12">
                            <div class="card mb-4">
                                <div class="card-block">
									<asp:Button runat = "server" id = "addScenarioButton" text ="Add New Scenario" type="submit" class="btn btn-primary" OnClick="AddScenario_Click" />
									<br><br>
                                   
										<asp:GridView ID="scenarioGridView" runat="server" AutoGenerateColumns="False" GridLines ="None" BprderStype = "None" CellSpacing="5" CellPadding="5">
											<RowStyle CssClass="gridViewRow" />
                               <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("scenarioName") %>'></asp:Label> 
				
                        </ItemTemplate>
                         </asp:TemplateField>

					     <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                         <asp:Button ID="EditScenarioButton" runat="server" class="btn  btn-warning" CommandName="EditScenario" CommandArgument='<%# Eval("scenarioId") %>' Text="Edit" />
                        </ItemTemplate>
                         </asp:TemplateField>
						 
					     <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                         <asp:Button ID="DeleteScenarioButton" runat="server" class="btn btn-danger" CommandName="DeleteScenario" CommandArgument='<%# Eval("scenarioId") %>' Text="Delete" />
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
						 
                        </asp:GridView>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                   
                </div>
                <footer class="footer">
                    <div class="container-fluid clearfix">
                      <span class="float-right">
                          <a href="#">Cell Game</a> &copy; 2017
                      </span>
                    </div>
                </footer>
            </div>
        </div>

      </div>

      <script src="../node_modules/jquery/dist/jquery.min.js"></script>
      <script src="../node_modules/tether/dist/js/tether.min.js"></script>
      <script src="../node_modules/bootstrap/dist/js/bootstrap.min.js"></script>
      <script src="../node_modules/chart.js/dist/Chart.min.js"></script>
      <script src="../node_modules/perfect-scrollbar/dist/js/perfect-scrollbar.jquery.min.js"></script>
      <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB5NXz9eVnyJOA81wimI8WYE08kW_JMe8g&callback=initMap" async = "async" defer ="defer"></script>
      <script src="../js/off-canvas.js"></script>
      <script src="../js/hoverable-collapse.js"></script>
      <script src="../js/misc.js"></script>
      <script src="../js/chart.js"></script>
      <script src="j../s/maps.js"></script>


		<asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
		<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:TestConnectionString %>" SelectCommand="SELECT * FROM [Scenarios]"></asp:SqlDataSource>
	</form>


</body>
</html>