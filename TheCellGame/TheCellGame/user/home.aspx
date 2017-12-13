<%@ Page Title="" Language="C#" MasterPageFile="~/user/userMaster.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="TheCellGame.user.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="UserContentPlaceHolder" runat="server">


	 <style>
            .bg-img {
                background-image: url('biology2.jpg');
			 top: 0px;
			 left: 0px;
		 }
        </style>

	 <h3 class="text-primary mb-4" style="text-align: center">Welcome to the CellGame</h3>

	<div class="overlay"></div>
    <main>
       

        <div class="container hero hero-left  bg-img ">
            <section id="cpy-hero">
                <div class="content">
                    <!--<h1>Cell Game</h1>-->
					<br>
						<br>
							
                    <p style="text-align: center; font-family: Vollkorn; font-size: medium;">In this game you are a cell that will be faced with many decisions regarding your fate. Your goal is to make intelligent choices that will benefit your host body. These decisions can include when or how to progress through the cell cycle or, if necessary, when to undergo apoptosis.</p>
                </div>
                <div class="cta-subtext-assurance">
                    <div class="cta-subtext">
                        <!--<a href="login.aspx" class="primary-cta"><span>Play game</span></a>-->
                        <div>
                            <div>
                            </div>
                        </div>
            </section>
			<div>
			<asp:Image ID="Image1" runat="server" Height="221px" Width="446px"  ImageUrl="~/biology2_old.jpg" ImageAlign="Middle" />
				</div>

                    <div class="row mb-2">
                        <div class="col-lg-12">
                            <div class="card mb-4">
                                <div class="card-block">
                                    <h3 class="card-title mb-5" style="text-align: center">About CellGame</h3>
                                 
                                    <h6 style="font-family: Vollkorn; font-size: medium; white-space: pre-line; ">
										In this CellGame project, life cycle of a cell and its various stages are explained the form of a decision game.  Life of a cell is passed through various checkpoints and decisions are made internally by cell which will take it to another stage. Here, students play the decision game by taking various decisions on behalf of cell in its life cycle thereby effecting outcome of the cell. It helps users especially students to learn the cell biology concepts. It is both informative and fun.
									</h6>
										
                                    
                                </div>
                            </div>
                        </div>
                    </div>
	 </div>
	 <br />
	 <br />
	 
	 <br />
	 <br />
</asp:Content>
