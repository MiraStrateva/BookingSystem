<%@ Page Title="Home Page" Language="C#" 
    MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="BookingSystem.Views._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:DataList id="DataListCategories" runat="server"
            DataKeyField="CategoryID"
            RepeatLayout="Table" RepeatDirection="Horizontal" 
            RepeatColumns="3" CellSpacing="0">
            <ItemTemplate>
                <div class="categoryImage" style="background:url('<%#: Eval("CategoryImage") %>')">
                    <h2><%#: Eval("CategoryName") %></h2>
                    <p class="lead"><%#: Eval("CategoryDescription") %></p>
                </div>
            </ItemTemplate>
        </asp:DataList>
<%--        <asp:ListView id="ListViewCategories" runat="server"
            DataKeyNames="CategoryID" ItemType="BookingSystem.Data.Category">
            <LayoutTemplate>
                <div class="col-md-2">
                </div>
                <div class="col-md-1 pagerLine">
                    <asp:DataPager ID="DataPagerCustomers" runat="server" PageSize="1">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="False"  
                                ShowNextPageButton="False" 
                                ShowPreviousPageButton="True" ButtonCssClass="prevButton" />
                        </Fields>
                    </asp:DataPager>
                </div>
                <div class="col-md-6">
                    <span runat="server" id="itemPlaceholder" />
                </div>
                <div class="col-md-1 pagerLine">
                    <asp:DataPager ID="DataPager1" runat="server" PageSize="1">
                        <Fields>
                            <asp:NextPreviousPagerField ShowLastPageButton="False" 
                                ShowNextPageButton="True" ButtonCssClass="nextButton" 
                                ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </div>
                <div class="col-md-2">
                </div>
            </LayoutTemplate>
            <ItemTemplate>
                <div class="categoryImage" style="background:url('<%#: Eval("CategoryImage") %>')">
                    <h2><%#: Eval("CategoryName") %></h2>
                    <p class="lead"><%#: Eval("CategoryDescription") %></p>
                </div>
            </ItemTemplate>
        </asp:ListView>--%>
    </div>

    <div class="row">
        <div class="col-md-6">
            <h2>Our newest members</h2>
            <div class="row">
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./../Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./../Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./../Images/question-mark.jpg"></asp:Image>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./../Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./../Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./../Images/question-mark.jpg"></asp:Image>
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
                        src="./../Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./../Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./../Images/question-mark.jpg"></asp:Image>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./../Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./../Images/question-mark.jpg"></asp:Image>
                </div>
                <div class="col-md-4">
                    <asp:Image CssClass="place" runat="server" 
                        src="./../Images/question-mark.jpg"></asp:Image>
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
