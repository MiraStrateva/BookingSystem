<%@ Page Title="Companies by Category" Language="C#" 
    MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" 
    CodeBehind="CategoryCompanies.aspx.cs" 
    Inherits="BookingSystem.Views.CategoryCompanies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2 id="CategoryName"><%= this.CategoryName %></h2>
        <div class="search-button">
            <div class="form-search">
                <div class="input-append">
                    <asp:TextBox runat="server" ID="TextBoxSearchParam" type="text" name="q" class="col-md-3 search-query" placeholder="Search by company name / description..."></asp:TextBox>
                    <asp:LinkButton runat="server" ID="LinkButtonSearch" OnClick="LinkButtonSearch_Click" CssClass="btn  btn-primary" Text="Search"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <asp:ListView runat="server" ItemType="BookingSystem.Data.Models.Company" 
        SelectMethod="ListViewCategoryCompanies_GetData">
        <ItemTemplate>
            <hr />
            <div class="row">
                <div class="col-md-3">
                    <asp:Image CssClass="img-responsive" runat="server" ImageUrl='<%#: Eval("CompanyImage")%>'/>
                </div>
                <div class="col-md-9">
                    <h2><%#: Eval("CompanyName")%></h2>
                    <p><%#: Eval("CompanyDescription")%></p>
                    <asp:HyperLink runat="server" NavigateUrl='<%#: Eval("CompanyWebsite")%>'><%#: Eval("CompanyWebsite")%></asp:HyperLink>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
