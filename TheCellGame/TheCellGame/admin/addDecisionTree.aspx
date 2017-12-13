<%@ Page Title="" Language="C#" MasterPageFile="~/admin/newAdminMaster.Master" AutoEventWireup="true" CodeBehind="addDecisionTree.aspx.cs" Inherits="TheCellGame.admin.addDecisionTree" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
	                                   <div class="form-group">
                                          <label for="exampleText">Scenario Name</label>
                                            <asp:TextBox ID="decisionTreeName" runat="server" CssClass = "form-control p_input" placeholder="Enter  Name" Columns="3" required="required"></asp:TextBox>
											
                                        </div>
                                       									  
                                        
                                        <div class="col-12">
                                           <!-- <button type="submit" class="btn btn-primary">Save</button> -->
											<asp:Button runat = "server" id = "addDecsisionTreeButton" text ="save" type="submit" class="btn btn-primary" OnClick="AddDecisionTreeButton_Click" CauseValidation="false"/>
                                        </div>
</asp:Content>
