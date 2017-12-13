<%@ Page Title="" Language="C#" MasterPageFile="~/admin/newAdminMaster.Master" AutoEventWireup="true" CodeBehind="finalStates.aspx.cs" Inherits="TheCellGame.admin.finalStates" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">

	
                                    <asp:GridView ID="scenarioDescGridView" runat="server" AutoGenerateColumns="False" GridLines ="None" BorderStyle = "None" CellSpacing="25" CellPadding="10">
						
                               <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("question") %>'></asp:Label> 
							
                        </ItemTemplate>
                         </asp:TemplateField>
								   <asp:TemplateField HeaderText="">
                        <ItemTemplate>
								   <asp:Button runat = "server" id = "option1Button"  visible='<%# ((int)(Eval("option1NextQuestionId")) == 0) ? true : false %>'   Text ='<%# Eval("option1") %>' type="submit" class="btn btn-warning" OnCommand="SelectedOption_Click" title="Chose this option to add question"  CommandArgument='<%#Eval("questionId") + ",option1" %>'/>
                        </ItemTemplate>
                         </asp:TemplateField>

						 <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           
							<asp:Button runat = "server" id = "option2Button"   visible='<%# ((int)(Eval("option2NextQuestionId")) == 0) ? true : false %>' Text='<%# Eval("option2") %>' type="submit" class="btn btn-warning" OnCommand="SelectedOption_Click" title="Chose this option to add question"  CommandArgument='<%#Eval("questionId") + ",option2" %>' />
                        </ItemTemplate>
                         </asp:TemplateField>


                         </Columns>
					
                        </asp:GridView>
                               
					<br>
					
</asp:Content>
