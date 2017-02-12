<%@ Page Title="Home Page" Language="C#" 
    MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="BookingSystem.Views._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-12">
        <asp:HyperLink ID="HyperLinkCategory" runat="server" 
            NavigateUrl='<%#: "Companies.aspx?CategoryId=" + Eval("CategoryID") %>'>
            <%#: Eval("CategoryDescription") %>
        </asp:HyperLink>
        <asp:DataList id="DataListCategories" runat="server"
            DataKeyField="CategoryID"
            RepeatLayout="Table" RepeatDirection="Horizontal" 
            RepeatColumns="3" CellSpacing="15">
            <ItemTemplate>
                <asp:Image CssClass="place" runat="server" 
                        src='<%#: Eval("CategoryImage") %>'></asp:Image>
            </ItemTemplate>
        </asp:DataList>
        <asp:Literal ID="LiteralFooter" Text='<%#: Eval("CategoryName") %>' runat="server"></asp:Literal>
    </div>

    <div class="row">
        <div class="col-md-6">
            <h2>Our newest members</h2>
            <div class="row">
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./Images/question-mark.jpg"></asp:Image>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./Images/question-mark.jpg"></asp:Image>
                </div>
            </div>
            <br />
            <p>
                <a class="btn btn-default" href="#">See all places&raquo;</a>
            </p>
        </div>
        <div class="col-md-6">
            <h2>Just booked</h2>
            <div class="row">
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./Images/question-mark.jpg"></asp:Image>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./Images/question-mark.jpg"></asp:Image>
                </div>
            </div>
            <br />
            <p>
                <a class="btn btn-default" href="#">Take hour for &raquo;</a>
            </p>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="jumbotron" id="joinus">
                <h1>Join Us</h1>
                <p class="lead">If you own a company that offers hourly services and you want to be found by more people join us!</p>
                <p><a href="./RegisterCompany.aspx" class="btn btn-primary btn-lg">See how &raquo;</a></p>
            </div>
        </div>
        <div class="col-md-6">
            <div class="jumbotron" id="pickandbook">
                <h1>Pick and Book</h1>
                <p class="lead">You can book an hour for any service provided by our partners with one click only. 
                    Find your service, pick your hour and book!</p>
                <p><a href="./Register.aspx" class="btn btn-primary btn-lg">See how &raquo;</a></p>
            </div>
        </div>
    </div>

</asp:Content>
