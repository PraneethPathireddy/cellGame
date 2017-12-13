<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="play.aspx.cs" Inherits="TheCellGame.admin.play" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
	<asp:GridView ID="scenarioDisplayGridView" runat="server" AutoGenerateColumns="False" GridLines ="None" BprderStype = "None" CellSpacing="5" CellPadding ="5">
						<RowStyle CssClass="gridViewRow" />
                               <Columns>
                           <asp:TemplateField HeaderText="Scenarios">
                        <ItemTemplate>
                           
							<asp:Button runat = "server" id = "scenariButton" text ='<%# Eval("decisionTreeName") %> ' type="submit" class="btn btn-outline-success" OnClick="playButton_Click" title="Click to Play" />
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
					
                        </asp:GridView>
</asp:Content>
