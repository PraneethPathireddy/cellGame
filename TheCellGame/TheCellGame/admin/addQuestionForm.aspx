<%@ Page Title="" Language="C#" MasterPageFile="~/admin/newAdminMaster.Master" AutoEventWireup="true" CodeBehind="addQuestionForm.aspx.cs" Inherits="TheCellGame.admin.addQuestionForm" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">

 <script>
function enableButton(id) {
       if (document.getElementById(id).style.visibility = 'hidden') {
    
            document.getElementById(id).style.visibility = 'visible'
       }
}
</script>
									   
                                        <div class="form-group">

                                            <label for="exampleTextarea">Question</label>
                                            
                                           <textarea  id="question" mode="multiline"  runat="server" class="form-control p_input" placeholder="Enter Question" required="required"/>
                                        </div>
										
										&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
										<br>

	                                 <!--    <asp:FileUpload ID="FileUpload1" runat="server" /><br>
										&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;
	                                  -->
										
										<div class="form-group">
                                            <label for="exampleTextarea">Option 1</label>
                                            <textarea id="option1" mode="multiline" runat="server" class="form-control p_input" placeholder="Enter option 1" required="required" />
                                            
                                            
                                        </div>
										<div class="form-group">
                                            <label for="exampleTextarea">Option 1 Comment</label>
                                            <textarea id="option1Comment" mode="multiline" runat="server" class="form-control p_input" placeholder="Enter Comment" required="required"/>

                                        </div>
	                                    <div class="form-group">
                                            <label for="exampleTextarea">Option 2</label>
                                            <textarea id="option2" mode="multiline" runat="server" class="form-control p_input" placeholder="Enter option2" required="required"/>

                                        </div>
	                                     <div class="form-group">
                                            <label for="exampleTextarea">Option 2 Comment</label>
                                            <textarea id="option2Comment" mode="multiline" runat="server" class="form-control p_input" placeholder="Enter Comment" required="required"/>

                                        </div>
	                                  <!-- <div class="col-12"> -->
                                           <!-- <button type="submit" class="btn btn-primary">Save</button> -->
											<!--
										   <input type="button" id = "Button1" class="btn btn-primary" OnClick="enableButton" />
                                        </div>
	
	                                   <div class="form-group">
                                            <label for="exampleTextarea">Option 3</label>
                                            <textarea id="option3"  visible=false mode="multiline" runat="server" class="form-control p_input" placeholder="Enter option 3" required="required"/>

                                        </div>
												-->
	 

	                                   <div class="col-12">
                                           <!-- <button type="submit" class="btn btn-primary">Save</button> -->
											<asp:Button runat = "server" id = "addQuestionButton" text ="save" type="submit" class="btn btn-primary" OnClick="AddQuestion_Click" />
                                        </div>
</asp:Content>
