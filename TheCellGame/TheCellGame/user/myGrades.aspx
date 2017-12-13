<%@ Page Title="" Language="C#" MasterPageFile="~/user/userMaster.Master" AutoEventWireup="true" CodeBehind="myGrades.aspx.cs" Inherits="TheCellGame.user.myGrades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
	<div class="row mb-4">
                        <div class="col-lg-12">
							<br><br>
                            <div class="card">
                                <div class="card-block">
	 <asp:GridView ID="playGridView" runat="server" AutoGenerateColumns="False" GridLines ="None" BorderStyle = "None" CellSpacing="25" CellPadding="10">
						
                               <Columns>
                           <asp:TemplateField HeaderText="Scenario Name">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("decisionTreeName") %>'></asp:Label> 
							
                        </ItemTemplate>
                         </asp:TemplateField>
								   <asp:TemplateField HeaderText="Marks">
                        <ItemTemplate>
							 <asp:Label ID="Label2" runat="server" Text='<%# Eval("Marks") %>'></asp:Label> 	  
                        </ItemTemplate>
                         </asp:TemplateField>

						 <asp:TemplateField HeaderText="Comments">
                        <ItemTemplate>
                           
							<asp:Label ID="Label3" runat="server" Text='<%# Eval("comment") %>'></asp:Label> 
                        </ItemTemplate>
                         </asp:TemplateField>


                         </Columns>
					
                        </asp:GridView>
									</div>
								</div>
							</div>
		</div>
</asp:Content>
