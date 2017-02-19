<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" 
    AutoEventWireup="true" CodeBehind="Categories.aspx.cs"
    Inherits="BookingSystem.Views.Admin.Categories" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <h1>Categories</h1>
    <asp:GridView ID="GridViewCategories" runat="server" 
        AutoGenerateColumns="False" 
        ItemType="BookingSystem.Data.Models.Category" DataKeyNames="CategoryId"
        ShowFooter="True" SelectMethod="GridViewCategories_GetData" 
        OnRowDeleting ="GridViewCategories_RowDeleting" 
        DeleteMethod="GridViewCategories_DeleteItem" 
        OnRowUpdating ="GridViewCategories_RowUpdating"
        UpdateMethod="GridViewCategories_UpdateItem">
        <Columns>
            <asp:ImageField HeaderText="" DataImageUrlField="CategoryImage" 
                ControlStyle-Width="72" ControlStyle-Height = "48"></asp:ImageField>
            <asp:TemplateField HeaderText="Image file name">
                <ItemTemplate>
                    <asp:Label ID="LabelCategoryImage" runat="server" Text=<%#: Item.CategoryImage%>/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="FileUploadControl" runat="server" />  
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:FileUpload ID="FFileUploadControl" runat="server" />  
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <asp:Label ID="LabelCategoryName" Text=<%#: Item.CategoryName %> runat="server" BorderStyle="None"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxCategoryName" 
                        Text=<%#: BindItem.CategoryName %> runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxCategoryName" 
                        ErrorMessage="Field Category Name cannot be empty" 
                        ValidationGroup="EditData"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="FTextBoxCategoryName" 
                        Text=<%#: BindItem.CategoryName %> runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="FTextBoxCategoryName" 
                        ErrorMessage="Field Category Name cannot be empty" 
                        ValidationGroup="InsertData"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <asp:Label ID="LabelCategoryDescription" 
                        Text='<%#: Item.CategoryDescription %>' runat="server" BorderStyle="None"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxCategoryDescription" 
                        Text='<%#: BindItem.CategoryDescription %>' runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="FTextBoxCategoryDescription" 
                        Text='<%#: BindItem.CategoryDescription %>' runat="server"></asp:TextBox>
                    <asp:Button ID="ButtonInsert" runat="server" ValidationGroup="InsertData"
                        OnClick="ButtonInsertCategory_Click" Text="Add" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" ButtonType="Image"
                EditImageUrl="~/Images/Toolbar/Edit.png" 
                UpdateImageUrl="~/Images/Toolbar/Save.png" 
                CancelImageUrl="~/Images/Toolbar/Clear.png" ValidationGroup="EditData" />
            <asp:CommandField ShowDeleteButton="True" ButtonType="Image"
                DeleteImageUrl="~/Images/Toolbar/Delete.png" />
        </Columns>
    </asp:GridView>
</asp:Content>
