<%@ Page Title="Companies by Category" Language="C#" 
    MasterPageFile="~/Views/Site.Master" AutoEventWireup="true" 
    CodeBehind="CategoryCompanies.aspx.cs" 
    Inherits="BookingSystem.Views.CategoryCompanies" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <h2 id="CategoryName"><%= this.CategoryName %></h2>
        <div class="search-button">
            <div class="form-search">
                <div class="input-append row">
                    <div class="col-md-8">
                    </div>
                    <div class="input-group col-xs-4">
                        <asp:TextBox runat="server" ID="TextBoxSearchParam" type="text" 
                            class="form-control " placeholder="Search by company name/description..."/>
                        <asp:LinkButton runat="server" CssClass="btn btn-primary" ID="LinkButtonSearch" OnClick="LinkButtonSearch_Click" >
                            <i class="glyphicon glyphicon-search"></i>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:ListView runat="server" ItemType="BookingSystem.Data.Models.Company" 
        ID="ListViewCategoryCompanies"
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
                    <p><a href="./Book.aspx" class="btn btn-primary btn-lg">Pick and Book &raquo;</a></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
