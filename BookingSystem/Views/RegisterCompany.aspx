<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Views/Site.Master" 
    AutoEventWireup="true" CodeBehind="RegisterCompany.aspx.cs" 
    Inherits="BookingSystem.Views.RegisterCompany" %>

<asp:Content ID="RegisterCompany" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Create a new company account</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />

        <asp:ListView ID="ListViewCompany" runat="server" 
            ItemType="BookingSystem.Data.Models.Company" 
            DataKeyNames="CompanyId" 
            SelectMethod="ListViewCompany_GetData" 
            UpdateMethod="ListViewCompany_UpdateItem">

            <EditItemTemplate>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="FileUploadImage" 
                        CssClass="col-md-2 control-label">Company image</asp:Label>
                    <asp:Image runat="server" CssClass="col-md-2 img-responsive" 
                        ImageUrl="<%# Item.CompanyImage %>" />
                    <div class="col-md-8">
                        <asp:FileUpload ID="FileUploadImage" runat="server" />  
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="DropDownListCategory" 
                        CssClass="col-md-2 control-label">Select category</asp:Label>
                    <div class="col-md-10">
                        <asp:DropDownList ID="DropDownListCategory" runat="server"
                            ItemType="BookingSystem.Data.Models.Category" 
                            SelectMethod="DropDownListCategory_GetData"
                            DataValueField="CategoryID"
                            DataTextField="CategoryName"
                            SelectedValue="<%# BindItem.CategoryId %>"
                            AppendDataBoundItems="true">
                            <asp:ListItem Text="(no category)" Value="" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="DropDownListCategory"
                            CssClass="text-danger" ErrorMessage="The category field is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxCompanyName" 
                        CssClass="col-md-2 control-label">Company name</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" Text='<%# BindItem.CompanyName %>' 
                            ID="TextBoxCompanyName" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCompanyName"
                            CssClass="text-danger" ErrorMessage="The company name field is required." />
                        <asp:RangeValidator runat="server" ControlToValidate="TextBoxCompanyName" 
                            MinimumValue="1" MaximumValue="50"
                            CssClass="text-danger" ErrorMessage="The company name shoul be less than 50 characters long." />
                    </div>
                </div>
                
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxCompanyDescription" 
                        CssClass="col-md-2 control-label">Company description</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" Text='<%# BindItem.CompanyDescription %>' 
                            ID="TextBoxCompanyDescription" CssClass="form-control" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxEmail" CssClass="col-md-2 control-label">Email</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" Text="<%# BindItem.Email %>" 
                            ID="Email" CssClass="form-control" TextMode="Email" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmail"
                            CssClass="text-danger" ErrorMessage="The email field is required." />
                        <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBoxEmail"
                            CssClass="text-danger" ErrorMessage="This email does not validate." 
                            ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                        <asp:RangeValidator runat="server" ControlToValidate="TextBoxEmail" 
                            MinimumValue="1" MaximumValue="50"
                            CssClass="text-danger" ErrorMessage="The email shoul be less than 50 characters long." />
                    </div>
                </div>

                 <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxCity" 
                        CssClass="col-md-2 control-label">City</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" Text="<%# BindItem.City %>" 
                            ID="TextBoxCity" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCity"
                            CssClass="text-danger" ErrorMessage="The city field is required." />
                        <asp:RangeValidator runat="server" ControlToValidate="TextBoxCity" 
                            MinimumValue="1" MaximumValue="50"
                            CssClass="text-danger" ErrorMessage="The city shoul be less than 50 characters long." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxAddress" 
                        CssClass="col-md-2 control-label">Address</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" Text="<%# BindItem.Address %>" 
                            ID="TextBoxAddress" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddress"
                            CssClass="text-danger" ErrorMessage="The address field is required." />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxContactName" 
                        CssClass="col-md-2 control-label">Contact Name</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" Text="<%# BindItem.ContactName %>" 
                            ID="TextBoxContactName" CssClass="form-control" TextMode="Url" />
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxWebsite" 
                        CssClass="col-md-2 control-label">Website</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" Text="<%# BindItem.CompanyWebsite %>" 
                            ID="TextBoxWebsite" CssClass="form-control" TextMode="Url" />
                    </div>
                </div>     
 
                <div class="form-group">
                    <asp:ImageButton ImageUrl="~/Images/Toolbar/Save.png" ID="UpdateButton" runat="server"
                        CommandName="Update" Text="Update" />
                    <asp:ImageButton ImageUrl="~/Images/Toolbar/Undo.png" ID="CancelButton" runat="server" 
                        CommandName="Cancel" Text="Cancel" />   
                </div>                     
            </EditItemTemplate>

            <ItemTemplate>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="FileUploadImage" 
                        CssClass="col-md-2 control-label">Company image</asp:Label>
                    <asp:Image runat="server" CssClass="col-md-2 img-responsive" 
                        ImageUrl="<%# Item.CompanyImage %>" />
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="DropDownListCategory" 
                        CssClass="col-md-2 control-label">Select category</asp:Label>
                    <div class="col-md-10">
                        <asp:Literal runat="server" Text='<%# Item.Category.CategoryName %>'></asp:Literal>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxCompanyName" 
                        CssClass="col-md-2 control-label">Company name</asp:Label>
                    <div class="col-md-10">
                        <asp:Literal runat="server" Text='<%# Item.CompanyName %>'></asp:Literal>
                    </div>
                </div>
                
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxCompanyDescription" 
                        CssClass="col-md-2 control-label">Company description</asp:Label>
                    <div class="col-md-10">
                        <asp:Literal runat="server" Text='<%# Item.CompanyDescription %>'></asp:Literal>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxEmail" CssClass="col-md-2 control-label">Email</asp:Label>
                    <div class="col-md-10">
                        <asp:Literal runat="server" Text='<%# Item.Email %>'></asp:Literal>
                    </div>
                </div>

                 <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxCity" 
                        CssClass="col-md-2 control-label">City</asp:Label>
                    <div class="col-md-10">
                        <asp:Literal runat="server" Text='<%# Item.City %>'></asp:Literal>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxAddress" 
                        CssClass="col-md-2 control-label">Address</asp:Label>
                    <div class="col-md-10">
                        <asp:Literal runat="server" Text='<%# Item.Address %>'></asp:Literal>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxContactName" 
                        CssClass="col-md-2 control-label">Contact Name</asp:Label>
                    <div class="col-md-10">
                        <asp:Literal runat="server" Text='<%# Item.ContactName %>'></asp:Literal>
                    </div>
                </div>

                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="TextBoxWebsite" 
                        CssClass="col-md-2 control-label">Website</asp:Label>
                    <div class="col-md-10">
                        <asp:Literal runat="server" Text='<%# Item.CompanyWebsite %>'></asp:Literal>
                    </div>
                </div>     
 
                <div class="form-group">
                    <asp:ImageButton ImageUrl="~/Images/Toolbar/Edit.png" ID="EditButton" runat="server"
                        CommandName="Edit" Text="Edit" />
                </div> 
            </ItemTemplate>

        </asp:ListView>
    </div>
</asp:Content>
