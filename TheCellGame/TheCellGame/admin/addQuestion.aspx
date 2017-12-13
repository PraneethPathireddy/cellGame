<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="addQuestion.aspx.cs" Inherits="TheCellGame.admin.addQuestion"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
		                               
							<asp:Button runat = "server" id = "addFirstQuestion" text ="Add Question" type="submit" class="btn btn-success" OnClick="AddQuestionButton_Click" title="" />
                            <br><br>
                                    <asp:GridView ID="scenarioDescGridView" runat="server" AutoGenerateColumns="False" GridLines ="None" BorderStyle = "None" CellSpacing="25" CellPadding="10">
						
                               <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("question") %>'></asp:Label> 
							
                        </ItemTemplate>
                         </asp:TemplateField>
								   <asp:TemplateField HeaderText="">
                        <ItemTemplate>
								   <asp:Button runat = "server" id = "option1Button"   Enabled='<%# ((int)(Eval("option1NextQuestionId")) == 0) ? true : false %>'   Text ='<%# Eval("option1") %>' type="submit" class="btn btn-warning" OnCommand="SelectedOption_Click" title="Chose this option to add question"  CommandArgument='<%#Eval("questionId") + ",option1" %>'/>
                        </ItemTemplate>
                         </asp:TemplateField>

						 <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           
							<asp:Button runat = "server" id = "option2Button"   Enabled='<%# ((int)(Eval("option2NextQuestionId")) == 0) ? true : false %>' Text='<%# Eval("option2") %>' type="submit" class="btn btn-warning" OnCommand="SelectedOption_Click" title="Chose this option to add question"  CommandArgument='<%#Eval("questionId") + ",option2" %>' />
                        </ItemTemplate>
                         </asp:TemplateField>


                         </Columns>
					
                        </asp:GridView>
                              
					<br>
	                  <asp:Button runat = "server" id = "AddFinalStates" text ="Add Final States" type="submit" class="btn btn-success" OnClick="AddFinalStates_Click" title="" />
					
		                                 
</asp:Content>
