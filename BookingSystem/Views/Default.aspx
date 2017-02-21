<%@ Page Title="Home Page" Language="C#" 
    MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" 
    CodeBehind="Default.aspx.cs" Inherits="BookingSystem.Views._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <asp:DataList id="DataListCategories" runat="server"
            DataKeyField="CategoryID"
            RepeatLayout="Table" RepeatDirection="Horizontal" 
            RepeatColumns="3" CellPadding ="15">
            <ItemTemplate>
                <div class="categoryImage" 
                    style="background:url('<%# Eval("CategoryImage") %>') center 100%">
                    <h2><%#: Eval("CategoryName") %></h2>
                    <p class="lead"><%#: Eval("CategoryDescription") %></p>
                    <asp:Button runat="server" CommandName="select" Text="View companies" 
                        PostBackUrl='<%# string.Format("~/Views/CategoryCompanies.aspx?categoryId={0}", Eval("CategoryId")) %>'></asp:Button>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>

    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <AnonymousTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="jumbotron" id="joinus">
                        <h1>Join Us</h1>
                        <p class="lead">If you own a company that offers hourly services and you want to be found by more people join us!</p>
                        <p><a href="/Views/RegisterCompany.aspx" class="btn btn-primary btn-lg">Register your company &raquo;</a></p>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="jumbotron" id="pickandbook">
                        <h1>Pick and Book</h1>
                        <p class="lead">You can book an hour for any service provided by our partners with one click only. 
                            Find your service, pick your hour and book!</p>
                        <p><a href="/Views/PickAndBook.aspx" class="btn btn-primary btn-lg">Pick & Book &raquo;</a></p>
                    </div>
                </div>
            </div>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <div class="col-md-12 jumbotron" id="contactus">
                <h1>Here for you</h1>
                <p class="lead">Please do not hesitate to contact our Live Help or send an e-mail to support@hour.for if you need any help at all.</p>
                <p><a href="/Views/Contact.aspx" class="btn btn-primary btn-lg">Contact us &raquo;</a></p>
            </div>
        </LoggedInTemplate>
    </asp:LoginView>

</asp:Content>
