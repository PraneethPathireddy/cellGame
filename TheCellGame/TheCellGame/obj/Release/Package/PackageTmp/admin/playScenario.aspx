<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="playScenario.aspx.cs" Inherits="TheCellGame.admin.playScenario" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
	<div class="row mb-4"> 
		      &nbsp; &nbsp; &nbsp <h5><asp:Label ID="prevOptionComment" runat="server" Text="" cssclass="text-center"></asp:Label></h5> 
		  <br><br>
                        <div class="col-lg-12">
							
                            <div class="card">
								 

                                <div class="card-block">
									
									<br><br>
                                    <asp:GridView ID="scenarioDescGridView" runat="server" AutoGenerateColumns="False" GridLines ="None" BprderStype = "None" >
						<RowStyle CssClass="gridViewRow" />
                               <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# Eval("question") %>'></asp:Label> 
							
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>

					
                        </asp:GridView>

                                </div>
                            </div>
                        </div>
                    </div>
					<br>

	
	                  <!--
					 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines ="None" BprderStype = "None" >
						<RowStyle CssClass="gridViewRow" />
                               <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           <asp:image ID="Image1" runat="server" Width="100" Height="100" ImageUrl ="ImageRetrieve.aspx" />
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
					
                        </asp:GridView>
	                   -->


	                  <label for="exampleTextarea">Comment</label>
                                            
                          <textarea  id="commentBox" mode="multiline"  runat="server" class="form-control p_input" placeholder="Enter Comment" required="required"/>
	                       <br>

					
	                
					 <asp:GridView ID="option1GridView" runat="server" AutoGenerateColumns="False" GridLines ="None" BprderStype = "None" >
						<RowStyle CssClass="gridViewRow" />
                               <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           
							<asp:Button runat = "server" id = "option1Button" text ='<%# Eval("option1") %>' type="submit" class="btn btn-success" OnClick="selectedOption_Click" title="select option" />
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
					
                        </asp:GridView>
					
					 <asp:GridView ID="option2GridView" runat="server" AutoGenerateColumns="False" GridLines ="None" BprderStype = "None" >
						<RowStyle CssClass="gridViewRow" />
                               <Columns>
                           <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                           
							<asp:Button runat = "server" id = "option2Button" text ='<%# Eval("option2") %>' type="submit" class="btn btn-success" OnClick="selectedOption_Click" title="select option" />
                        </ItemTemplate>
                         </asp:TemplateField>
                         </Columns>
					
                        </asp:GridView>
	                    
	                      <br><br>
                         
</asp:Content>
