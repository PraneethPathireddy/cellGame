<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="ViewScenarios.aspx.cs" Inherits="TheCellGame.admin.ViewScenarios" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
	 <h3 class="text-primary mb-4"></h3>
                    <div class="row mb-2">
                        <div class="col-lg-12">
                            <div class="card mb-4">
                                <div class="card-block">
									<asp:Button runat = "server" id = "addScenarioButton" text ="Add New Scenario" type="submit" class="btn btn-primary" OnClick="AddScenario_Click" />
									<br><br>
                                   
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
                         <asp:Button ID="EditScenarioButton" OnCommand="ScenarioGridView_Command" runat="server" class="btn  btn-warning" CommandName="EditScenario" CommandArgument='<%# Eval("scenarioId") %>' Text="Edit" CauseValidation="false" />
                        </ItemTemplate>
                         </asp:TemplateField>
						 
					     <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                         <asp:Button ID="DeleteScenarioButton" OnCommand="ScenarioGridView_Command"  runat="server" class="btn btn-danger" CommandName="DeleteScenario" CommandArgument='<%# Eval("scenarioId") %>' Text="Delete" CauseValidation="false" />
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
						 
                        </asp:GridView>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
</asp:Content>
