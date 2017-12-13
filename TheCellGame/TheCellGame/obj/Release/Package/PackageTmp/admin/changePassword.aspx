<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="TheCellGame.admin.changePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
	<div class="row mb-2">
                        <div class="col-lg-12">
                            <div class="card">
                                <div class="card-block">
	
									<div>
				                     <asp:Label ID="passwdChangeResultLabel" runat="server" CssClass="validation" ></asp:Label>
				                     </div>
                                     <div class="text-center">
                                        <div class="form-group">
                                            <label for="exampleInputPassword1"><b>Current Password</b></label>
          
											<asp:TextBox ID="oldPassword" TextMode="Password" runat="server" CssClass = "form-control p_input" placeholder="Password"></asp:TextBox>
                                        </div>
										&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
										<br>
										
										 <div class="form-group">
                                            <label for="exampleInputPassword1"><b>New Password</b></label>
                                            <asp:TextBox ID="newPassword" TextMode="Password" runat="server" CssClass = "form-control p_input" placeholder="Password"></asp:TextBox>
                                        </div>
                                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
										 <div class="form-group">
                                            <label for="exampleInputPassword1"><b>Re-enter New Password</b></label>
                                             <asp:TextBox ID="reEnteredNewPassword" TextMode="Password" runat="server" CssClass = "form-control p_input" placeholder="Password"></asp:TextBox>
                                        </div>
										
                                        <div class="col-12">

                                           
                                        	<asp:Button ID="ChangePasswdButton" runat="server" CssClass="btn btn-primary" Text="Change Password" onClick="ChangePasswd_Click"/>
                                        </div>
                                    
									 </div>
									 </div>
                            </div>
                        </div>
                    </div>
                           
</asp:Content>
