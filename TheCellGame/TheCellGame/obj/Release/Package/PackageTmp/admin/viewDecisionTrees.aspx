<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="viewDecisionTrees.aspx.cs" Inherits="TheCellGame.admin.viewDecisionTrees" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
	 <h3 class="text-primary mb-4"></h3>
                    <div class="row mb-2">
                        <div class="col-lg-12">
                            <div class="card mb-4">
                                <div class="card-block">
									<asp:Label ID="deleteLabel" runat="server" CssClass="validation" ></asp:Label>
									<br><br>
									<asp:Button runat = "server" id = "addScenarioButton" text ="Add Scenario" type="submit" class="btn btn-primary" OnClick="AddDecsionTree_Click" CauseValidation="false" />
									<br><br>
                                   
										<asp:GridView ID="DecisionTreeGridView"  runat="server" AutoGenerateColumns="False" GridLines ="None" BorderStyle = "None" CellSpacing="5" CellPadding="5">
											<RowStyle CssClass="gridViewRow" />
                               <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("decisionTreeName") %>'></asp:Label> 
				
                        </ItemTemplate>
                         </asp:TemplateField>
						 
					     <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                         <asp:Button ID="DeleteScenarioButton" OnCommand="DecisionTreeGridView_Command" runat="server" class="btn btn-danger" CommandName="DeleteDecisionTree" CommandArgument='<%# Eval("decisionTreeId") %>' Text="Delete" CauseValidation="false" />
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
						 
                        </asp:GridView>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
</asp:Content>
