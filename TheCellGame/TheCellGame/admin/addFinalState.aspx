<%@ Page Title="" Language="C#" MasterPageFile="~/admin/newAdminMaster.Master" AutoEventWireup="true" CodeBehind="addFinalState.aspx.cs" Inherits="TheCellGame.admin.addFinalState"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
	 <div class="form-group">

                                            <label for="exampleTextarea">Final State</label>
                                            
                                           <textarea  id="finalState" mode="multiline"  runat="server" class="form-control p_input" placeholder="Enter Final State" required="required"/>
                                        </div>
										
										&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
	                                   
										<br>
	                                      <div class="col-12">
                                           <!-- <button type="submit" class="btn btn-primary">Save</button> -->
											<asp:Button runat = "server" id = "addFinalStateButton" text ="save" type="submit" class="btn btn-primary" OnClick="AddFinalState_Click" />
                                        </div>
</asp:Content>
