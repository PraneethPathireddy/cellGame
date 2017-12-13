<%@ Page Title="" Language="C#" MasterPageFile="~/admin/newAdminMaster.Master" AutoEventWireup="true" CodeBehind="evaluate.aspx.cs" Inherits="TheCellGame.admin.evaluate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
	 <asp:GridView ID="playGridView" runat="server" AutoGenerateColumns="False" GridLines ="None" CellSpacing="8" CellPadding="10">
						
                               <Columns>
                           <asp:TemplateField HeaderText="question">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("question") %>'></asp:Label> 
							
                        </ItemTemplate>
                         </asp:TemplateField>
								   <asp:TemplateField HeaderText="option selected">
                        <ItemTemplate>
							 <asp:Label ID="Label2" runat="server" Text='<%# Eval("optionSelected") %>'></asp:Label> 	  
                        </ItemTemplate>
                         </asp:TemplateField>

						 <asp:TemplateField HeaderText="comment">
                        <ItemTemplate>
                           
							<asp:Label ID="Label3" runat="server" Text='<%# Eval("comment") %>'></asp:Label> 
                        </ItemTemplate>
                         </asp:TemplateField>


                         </Columns>
					
                        </asp:GridView>
	                    <br><br>
	                        <div class="form-group">
                                          <label for="exampleText">Enter Marks</label>
                                            <asp:TextBox ID="marks" runat="server" CssClass = "form-control p_input" placeholder="Enter Marks" Columns="3" required="required"></asp:TextBox>
											
                                        </div>
	                      <div class="form-group">

                                            <label for="exampleTextarea">Comment(Optional)</label>
                                            
                                           <textarea  id="comment" mode="multiline"  runat="server" class="form-control p_input" placeholder="Enter Comment"/>
                                        </div>
	                       
	                         <div class="col-12">
                                        
											<asp:Button runat = "server" id = "addMarks" text ="submit" type="submit" class="btn btn-primary" OnClick="AddMarksButton_Click" CauseValidation="false"/>
                                        </div>
</asp:Content>
