<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="TheCellGame.registration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	  <!-- Required meta tags -->
  <title>Cell Game</title>
  <link rel="stylesheet" href="node_modules/font-awesome/css/font-awesome.min.css" />
  <link rel="stylesheet" href="node_modules/perfect-scrollbar/dist/css/perfect-scrollbar.min.css" />
  <link rel="stylesheet" href="css/style.css" />
  <link rel="shortcut icon" href="images/favicon.png" />
	<!--include jQuery -->  
<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"  type="text/javascript"></script>   
<!--include jQuery Validation Plugin-->  
<script src="http://ajax.aspnetcdn.com/ajax/jquery.validate/1.12.0/jquery.validate.min.js"  type="text/javascript"></script>  
  
</head>
<body>
	 <div class="container-scroller">
    <div class="container-fluid">
      <div class="row">
        <div class="content-wrapper full-page-wrapper d-flex align-items-center">
          <div class="card col-lg-4 offset-lg-4">
            <div class="card-block">
              <h3 class="card-title text-primary text-left mb-5 mt-4">Register</h3>
                <form id="LoginForm" runat="server">
				<div class="form-group">
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
					 <asp:TextBox ID="regFirstName" runat="server"  CssClass = "form-control p_input" placeholder="First Name" required="required" > </asp:TextBox>
                  </div>
                </div>
				<div class="form-group">
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
					 <asp:TextBox ID="regLastName" runat="server"  CssClass = "form-control p_input" placeholder="Last Name" required="required" > </asp:TextBox>
                  </div>
                </div>
                <div class="form-group">
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-user"></i></span>
					 <asp:TextBox ID="regUsername" runat="server"  CssClass = "form-control p_input" placeholder="Username" required="required" > </asp:TextBox>
                  </div>
                </div>
                <div class="form-group">
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                    <asp:TextBox ID="regPassword" runat="server" TextMode="Password" CssClass = "form-control p_input" placeholder="Password" required="required"></asp:TextBox>
                  </div>
                </div>
				<div class="form-group">
                  <div class="input-group">
                    <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                    <asp:TextBox ID="regReEnterPassword" runat="server" TextMode="Password" CssClass = "form-control p_input" placeholder="Re-enter Password" required="required"></asp:TextBox>
                  </div>
                </div>
				<div class="text-center">
				 <asp:Label ID="regResultLabel" runat="server" CssClass="validation" ></asp:Label>
				</div>
                <div class="text-center">
             
                	<asp:Button runat = "server" id = "myLoginButton" text ="submit" type="submit" class="btn btn-primary" OnClick="RegButton_Click" />
                </div>
                </form>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

  <script src="node_modules/jquery/dist/jquery.min.js" language ="javascript" type ="text/javascript"></script>
  <script src="node_modules/bootstrap/dist/js/bootstrap.min.js" language ="javascript" type ="text/javascript"></script>
  <script src="node_modules/perfect-scrollbar/dist/js/perfect-scrollbar.jquery.min.js" language ="javascript" type ="text/javascript"></script>
  <script src="js/misc.js" language ="javascript" type ="text/javascript"></script> 
  

</body>
</html>
