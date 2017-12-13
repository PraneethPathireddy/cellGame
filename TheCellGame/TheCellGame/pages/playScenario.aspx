<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="playScenario.aspx.cs" Inherits="TheCellGame.pages.playScenario"  EnableEventValidation ="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
      <title>Play</title>
      <link rel="stylesheet" href="../node_modules/font-awesome/css/font-awesome.min.css" />
      <link rel="stylesheet" href="../node_modules/perfect-scrollbar/dist/css/perfect-scrollbar.min.css" />
      <link rel="stylesheet" href="../css/style.css"/>
      <link rel="shortcut icon" href="../images/favicon.png"/>
</head>
<body>
    
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
                            <a class="nav-link" href="home.aspx">
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
                            <a class="nav-link" href="scenarios.aspx">
                                <img src="../images/icons/2.png" alt=""/>
                                <span class="menu-title">Add Scenario</span>
                            </a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="myGrades.aspx">
                                <!-- <i class="fa fa-wpforms"></i> -->
                                <img src="../images/icons/3.png" alt=""/>
                                <span class="menu-title">My Grades</span>
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
                   <form runat="server">
					<div class="row mb-4">
                        <div class="col-lg-12">
                            <div class="card">
                                <div class="card-block">
                                    <asp:GridView ID="scenarioDescGridView" runat="server" AutoGenerateColumns="False" GridLines ="None" BprderStype = "None" >
						<RowStyle CssClass="gridViewRow" />
                               <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("scenarioDescription") %>'></asp:Label> 
							
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
					
                        </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
					<br>
					
					 <asp:GridView ID="option1GridView" runat="server" AutoGenerateColumns="False" GridLines ="None" BprderStype = "None" >
						<RowStyle CssClass="gridViewRow" />
                               <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           
							<asp:Button runat = "server" id = "option1Button" text ='<%# Eval("option1") %>' type="submit" class="btn btn-success" OnClick="selectedOption_Click" />
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
					
                        </asp:GridView>
					<br>
					 <asp:GridView ID="option2GridView" runat="server" AutoGenerateColumns="False" GridLines ="None" BprderStype = "None" >
						<RowStyle CssClass="gridViewRow" />
                               <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           
							<asp:Button runat = "server" id = "option2Button" text ='<%# Eval("option2") %>' type="submit" class="btn btn-success" OnClick="selectedOption_Click" />
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
					
                        </asp:GridView>
						</form>
				  
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


</body>
</html>