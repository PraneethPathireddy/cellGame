<%@ Page Title="" Language="C#" MasterPageFile="~/user/userMaster.Master" AutoEventWireup="true" CodeBehind="playScenarioResult.aspx.cs" Inherits="TheCellGame.user.playScenarioResult"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">
	
				<div class="row mb-4">
                        <div class="col-lg-12">
                            
                           <h5><asp:Label ID="resultLabel" runat="server" ></asp:Label></h5> 
									
						   <br><br>
                           
							 <div class="card">
                                <div class="card-block">
                                  
                           <asp:Label ID="FinalState" runat="server" ></asp:Label>
							
                                
                            </div>
								

                        </div>
							<br><br>
							<asp:Button runat = "server" id = "playMoreButton" text ="Play More" type="submit" class="btn btn-primary" OnClick="PlayMore_Click" />
                    
					</div>
						</div>
					
</asp:Content>
