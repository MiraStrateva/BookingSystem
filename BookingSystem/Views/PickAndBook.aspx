<%@ Page Title="Categories & Companies" Language="C#" 
    MasterPageFile="~/Views/Site.Master" 
    AutoEventWireup="true" CodeBehind="PickAndBook.aspx.cs" 
    Inherits="BookingSystem.Views.PickAndBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="row">
        <div class="search-button">
            <div class="form-search">
                <div class="input-append row">
                    <div class="col-md-8">
                    </div>
                    <div class="input-group col-xs-4">
                        <asp:TextBox runat="server" ID="TextBoxSearchParam" type="text" 
                            class="form-control " placeholder="Search by company name/description..."/>
                        <asp:LinkButton runat="server" CssClass="btn btn-primary" 
                            ID="LinkButtonSearch" OnClick="LinkButtonSearch_Click" >
                            <i class="glyphicon glyphicon-search"></i>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:ListView runat="server" ItemType="BookingSystem.Data.Models.Category" 
        ID="ListViewCategories"
        SelectMethod="ListViewCategories_GetData"
        GroupItemCount="3">
        <GroupTemplate>
            <hr />
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>
        </GroupTemplate>

        <ItemTemplate>
            <div class="col-md-4">
                <a href='<%# string.Format("./CategoryCompanies.aspx?categoryId={0}", Item.CategoryId) %>'><h2><%#: Item.CategoryName %></h2></a>
                                            
                <asp:ListView runat="server" ID="RepeaterCompanies" 
                    ItemType="BookingSystem.Data.Models.Company" DataSource="<%# Item.Companies %>">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                        </ul>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <h2><%#: Item.CompanyName %></h2>
                        <p><%#: Item.CompanyDescription %></p>
                        <asp:HyperLink runat="server" NavigateUrl='<%#: Item.CompanyWebsite %>' Target="_blank">
                            <%#: Item.CompanyWebsite %></asp:HyperLink>
                        <p><a href='<%# string.Format("./Book.aspx?companyId={0}", Eval("CompanyId")) %>' 
                            class="btn btn-primary btn-lg">Pick and Book &raquo;</a></p>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        No companies in this category.
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
