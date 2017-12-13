<%@ Page Title="" Language="C#" MasterPageFile="~/admin/newAdminMaster.Master" AutoEventWireup="true" CodeBehind="LinkQuestions.aspx.cs" Inherits="TheCellGame.admin.LinkQuestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
		<asp:GridView ID="questionGridView"  runat="server" AutoGenerateColumns="False" GridLines ="None" BorderStyle = "None" CellSpacing="2" CellPadding="2">
											<RowStyle CssClass="gridViewRow" />
                           <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
						   <asp:Label ID="Label2" runat="server" Text='<%# Eval("questionId") %>'></asp:Label> 
                          
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
			             <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("question") %>'></asp:Label>        

                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
					 
                        </asp:GridView>
	                  
	         <asp:GridView ID="option1GridView"  runat="server" AutoGenerateColumns="False" GridLines ="None" BorderStyle = "None" CellSpacing="2" CellPadding="2">
											<RowStyle CssClass="gridViewRow" />
                           <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
						   <asp:Label ID="Label2" runat="server" Text='<%# Eval("option1") %>'></asp:Label> 
                          
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
				 </asp:GridView>
				    
				 <asp:GridView ID="option2GridView"  runat="server" AutoGenerateColumns="False" GridLines ="None" BorderStyle = "None" CellSpacing="2" CellPadding="2">
											<RowStyle CssClass="gridViewRow" />
                           <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
						   <asp:Label ID="Label3" runat="server" Text='<%# Eval("option2") %>'></asp:Label> 
                          
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
					 
                        </asp:GridView>
	                <br><br>
	     
</asp:Content>
