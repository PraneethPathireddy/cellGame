<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="grades.aspx.cs" Inherits="TheCellGame.admin.grades" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">

	<h3 class="text-primary mb-4"></h3>
                    <div class="row mb-2">
                        <div class="col-lg-12">
                            <div class="card mb-4">
                                <div class="card-block">
									<div class="text-center">
				                      <asp:Label ID="gradeLabel" runat="server" CssClass="validation" ></asp:Label>
				                    </div>
										<asp:GridView ID="playGridView"  runat="server" AutoGenerateColumns="False" GridLines ="None" BorderStyle = "None" CellSpacing="5" CellPadding="5">
											<RowStyle CssClass="gridViewRow" />
                               <Columns>
                           <asp:TemplateField HeaderText="Scenario Name">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("decisionTreeName") %>'></asp:Label> 
				
                        </ItemTemplate>
                         </asp:TemplateField>

						<asp:TemplateField HeaderText="User">
                        <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" Text='<%# Eval("userName")%>'></asp:Label> 
				
                        </ItemTemplate>
                         </asp:TemplateField>

						 
					     <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                         <asp:Button ID="EvaluatePlayButton" OnCommand="PlayGridView_Command" runat="server" class="btn btn-warning" CommandName="evaluate" CommandArgument='<%# Eval("playId") %>' Text="Evaluate" CauseValidation="false" />
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
						 
                        </asp:GridView>
                                    
                                </div>
                            </div>
                        </div>
                    </div>


</asp:Content>
