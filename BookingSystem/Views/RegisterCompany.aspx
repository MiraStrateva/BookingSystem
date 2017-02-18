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

        <div class="form-group">
            <asp:ImageButton runat="server" ID="ImageButtonLogo"/>
            <asp:FileUpload ID="FileUploadLogo" runat="server" />  
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxCompanyName" CssClass="col-md-2 control-label">Company name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBoxCompanyName" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCompanyName"
                    CssClass="text-danger" ErrorMessage="The company name field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxCompanyDescription" CssClass="col-md-2 control-label">Company description</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBoxCompanyDescription" CssClass="form-control" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxEmail" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxEmail"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="TextBoxEmail"
                    CssClass="text-danger" ErrorMessage="This email does not validate." 
                    ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxCity" CssClass="col-md-2 control-label">City</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBoxCity" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCity"
                    CssClass="text-danger" ErrorMessage="The city field is required." />
            </div>

        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxAddress" CssClass="col-md-2 control-label">Address</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBoxAddress" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxAddress"
                    CssClass="text-danger" ErrorMessage="The address field is required." />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="TextBoxWebsite" CssClass="col-md-2 control-label">Address</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="TextBoxWebsite" CssClass="form-control" TextMode="Url" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateCompany_Click" Text="Create Company Request" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
