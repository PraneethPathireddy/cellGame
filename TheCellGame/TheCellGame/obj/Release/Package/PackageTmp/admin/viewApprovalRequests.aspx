<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="viewApprovalRequests.aspx.cs" Inherits="TheCellGame.admin.viewApprovalRequests" EnableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
	 <h3 class="text-primary mb-4"></h3>
                    <div class="row mb-2">
                        <div class="col-lg-12">
                            <div class="card mb-4">
                                <div class="card-block">
									
   
										<asp:GridView ID="ScenarioGridView"  runat="server" AutoGenerateColumns="False" GridLines ="None" BprderStype = "None" CellSpacing="5" CellPadding="5">
											<RowStyle CssClass="gridViewRow" />
                               <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("scenarioName") %>'></asp:Label> 
				
                        </ItemTemplate>
                         </asp:TemplateField>

					     <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                         <asp:Button ID="ViewScenarioButton" OnCommand="ScenarioGridView_Command" runat="server" class="btn  btn-warning" CommandName="ViewScenario" CommandArgument='<%# Eval("scenarioId") %>' Text="View" CauseValidation="false" />
                        </ItemTemplate>
                         </asp:TemplateField>
						 </columns>
                        </asp:GridView>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
</asp:Content>
