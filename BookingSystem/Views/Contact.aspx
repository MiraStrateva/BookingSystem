<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Views/Site.Master" 
    AutoEventWireup="true" CodeBehind="Contact.aspx.cs" 
    Inherits="BookingSystem.Views.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Hour For Ltd.</h3>
    <address>
        Slivnica 189, 41<br />
        Varna, 9010<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:support@hour.for">support@hour.for</a><br />
    </address>
</asp:Content>
