<%@ Page Title="Company account" Language="C#"
    MasterPageFile="~/Views/Site.Master"
    AutoEventWireup="true" CodeBehind="RegisterCompany.aspx.cs"
    Inherits="BookingSystem.Views.RegisterCompany" %>

<asp:Content ID="RegisterCompany" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <asp:ListView ID="ListViewCompany" runat="server"
            ItemType="BookingSystem.Data.Models.Company"
            DataKeyNames="CompanyId"
            SelectMethod="ListViewCompany_GetData" 
            OnItemUpdating ="ListViewCompany_ItemUpdating"
            UpdateMethod="ListViewCompany_UpdateItem">

            <EditItemTemplate>
                <div class="row">
                    <div class="col-md-9">
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="DropDownListCategory"
                                CssClass="col-md-4 control-label">Select category</asp:Label>
                            <div class="col-md-8">
                                <asp:DropDownList ID="DropDownListCategory" runat="server"
                                    ItemType="BookingSystem.Data.Models.Category"
                                    DataValueField="CategoryId"
                                    DataTextField="CategoryName"
                                    SelectMethod="DropDownListCategory_GetData"
                                    CssClass="form-control">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownListCategory"
                                    CssClass="text-danger" Display="Dynamic"
                                    ErrorMessage="The category field is required." />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxCompanyName"
                                CssClass="col-md-4 control-label">Company name</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" Text='<%# BindItem.CompanyName %>'
                                    ID="TextBoxCompanyName" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCompanyName"
                                    CssClass="text-danger" Display="Dynamic"
                                    ErrorMessage="The company name field is required." />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxCompanyDescription"
                                CssClass="col-md-4 control-label">Company description</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" Text='<%# BindItem.CompanyDescription %>'
                                    ID="TextBoxCompanyDescription" CssClass="form-control" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxEmail"
                                CssClass="col-md-4 control-label">Email</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" Text="<%# BindItem.Email %>"
                                    ID="TextBoxEmail" CssClass="form-control" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmail"
                                    CssClass="text-danger" Display="Dynamic"
                                    ErrorMessage="The email field is required." />
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBoxEmail"
                                    CssClass="text-danger" Display="Dynamic"
                                    ErrorMessage="This email does not validate."
                                    ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxCity"
                                CssClass="col-md-4 control-label">City</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" Text="<%# BindItem.City %>"
                                    ID="TextBoxCity" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCity"
                                    CssClass="text-danger" Display="Dynamic"
                                    ErrorMessage="The city field is required." />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxAddress"
                                CssClass="col-md-4 control-label">Address</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" Text="<%# BindItem.Address %>"
                                    ID="TextBoxAddress" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddress"
                                    CssClass="text-danger" Display="Dynamic"
                                    ErrorMessage="The address field is required." />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxContactName"
                                CssClass="col-md-4 control-label">Contact Name</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" Text="<%# BindItem.ContactName %>"
                                    ID="TextBoxContactName" CssClass="form-control" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxPhoneNumber"
                                CssClass="col-md-4 control-label">Phone Number</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" Text="<%# BindItem.PhoneNumber %>"
                                    ID="TextBoxPhoneNumber" CssClass="form-control" />
                            </div>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="TextBoxWebsite"
                                CssClass="col-md-4 control-label">Website</asp:Label>
                            <div class="col-md-8">
                                <asp:TextBox runat="server" Text="<%# BindItem.CompanyWebsite %>"
                                    ID="TextBoxWebsite" CssClass="form-control" TextMode="Url" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-4"></div>
                            <div class="col-md-8">
                                <asp:ImageButton ImageUrl="~/Images/Toolbar/Save.png" ID="UpdateButton" runat="server"
                                    CommandName="Update" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 form-group">
                        <asp:Label runat="server" AssociatedControlID="FileUploadImage"
                            CssClass="control-label">Company image</asp:Label>
                        <asp:Image runat="server" CssClass="img-responsive"
                            ImageUrl="<%# Item.CompanyImage %>" />
                        <div>
                            <asp:FileUpload ID="FileUploadImage" runat="server" />
                        </div>
                    </div>
                </div>
            </EditItemTemplate>

            <ItemTemplate>
                <div class="row">
                    <div class="col-md-9">
                        <div class="form-group">
                            <asp:Label runat="server"
                                CssClass="col-md-4 control-label">Select category</asp:Label>
                            <asp:Label runat="server" CssClass ="col-md-8 label-value"
                                    Text='<%#: (Item.Category != null) ? Item.Category.CategoryName : "" %>'></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server"
                                CssClass="col-md-4 control-label">Company name</asp:Label>
                            <asp:Label runat="server" CssClass ="col-md-8 label-value"
                                 Text='<%#: Item.CompanyName %>'></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server"
                                CssClass="col-md-4 control-label">Company description</asp:Label>
                            <asp:Label runat="server" CssClass ="col-md-8 label-value"
                                Text='<%#: Item.CompanyDescription %>'></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server"
                                CssClass="col-md-4 control-label">Email</asp:Label>
                            <asp:Label runat="server" CssClass ="col-md-8 label-value" 
                                Text='<%#: Item.Email %>'></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server"
                                CssClass="col-md-4 control-label">City</asp:Label>
                            <asp:Label runat="server" CssClass ="col-md-8 label-value" 
                                Text='<%#: Item.City %>'></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server"
                                CssClass="col-md-4 control-label">Address</asp:Label>
                            <asp:Label runat="server" CssClass ="col-md-8 label-value" 
                                Text='<%#: Item.Address %>'></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server"
                                CssClass="col-md-4 control-label">Contact Name</asp:Label>
                            <asp:Label runat="server" CssClass ="col-md-8 label-value" 
                                Text='<%#: Item.ContactName %>'></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server"
                                CssClass="col-md-4 control-label">Phone Number</asp:Label>
                            <asp:Label runat="server" CssClass ="col-md-8 label-value" 
                                Text='<%# Item.PhoneNumber %>'></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server"
                                CssClass="col-md-4 control-label">Website</asp:Label>
                            <asp:Label runat="server" CssClass ="col-md-8 label-value" 
                                Text='<%#: Item.CompanyWebsite %>'></asp:Label>
                        </div>

                        <div class="form-group">
                            <div class="col-md-4"></div>
                            <div class="col-md-8">
                                <asp:ImageButton ImageUrl="~/Images/Toolbar/Edit.png" ID="EditButton" runat="server"
                                    CommandName="Edit" />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 form-group">
                        <asp:Label runat="server"
                            CssClass="control-label">Company image</asp:Label>
                        <div>
                            <asp:Image runat="server" CssClass="img-responsive"
                                ImageUrl="<%#: Item.CompanyImage %>" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
