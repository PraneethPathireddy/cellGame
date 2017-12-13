<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminMaster.Master" AutoEventWireup="true" CodeBehind="editScenario.aspx.cs" Inherits="TheCellGame.admin.editScenario" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
	<h3 class="text-primary mb-4"></h3>
                    <div class="row mb-2">
                        <div class="col-lg-12">
                            <div class="card">
                                <div class="card-block">
                                    <h5 class="card-title mb-4">Edit Scenario</h5>
                                    
                                        <div class="form-group">
                                            <label for="exampleText">Scenario Name</label>
                                            <asp:TextBox ID="scenarioName" runat="server" CssClass = "form-control p_input" placeholder="Enter Scenario Name"></asp:TextBox>
											
                                        </div>
                                       
									   &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
										<br>
									   
                                        <div class="form-group">

                                            <label for="exampleTextarea">Scenario description</label>
                                            
                                           <textarea  id="scenarioDescription" mode="multiline"  runat="server" class="form-control p_input" placeholder="Enter Scenario Description"/>
                                        </div>
										
										&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
										<br>
										
										
										<div class="form-group">
                                            <label for="exampleTextarea">Option 1</label>
                                            <textarea id="option1" mode="multiline" runat="server" class="form-control p_input" placeholder="Enter option 1"/>
                                            
                                            
                                        </div>
										<div class="form-group">
                                            <label for="exampleTextarea">Option 2</label>
                                            <textarea id="option2" mode="multiline" runat="server" class="form-control p_input" placeholder="Enter option 2"/>

                                        </div>
										
										
                                       
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										
                                            
                                        <div class="form-group">
                                       <asp:RadioButtonList ID="optionsRadioList" runat="server" CssClass="form-check-input">
                                          <asp:ListItem Value="1">option1</asp:ListItem>
                                          <asp:ListItem Value="2">option2</asp:ListItem>
                                       </asp:RadioButtonList>
										</div>
                                        
                                        <div class="col-12">
                                           <!-- <button type="submit" class="btn btn-primary">Save</button> -->
											<asp:Button runat = "server" id = "addScenarioButton" text ="save" type="submit" class="btn btn-primary" OnClick="EditScenaroButton_Click" CauseValidation="false"  />
                                        </div>
										
                                   
                                </div>
                            </div>
                        </div>
                    </div>
			

</asp:Content>
