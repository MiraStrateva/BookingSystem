<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" 
    AutoEventWireup="true" CodeBehind="Categories.aspx.cs"
    Inherits="BookingSystem.Views.Admin.Categories" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <h1>Categories</h1>
    <asp:EntityDataSource ID="EntityDataSourceCategories" runat="server" 
        ConnectionString="name=DefaultConnection" 
        DefaultContainerName="DefaultConnection" 
        EnableInsert="true" EnableUpdate="true" EnableDelete="true"   
        EntitySetName="Categories" 
        OnUpdating="EntityDataSourceCategories_Updating" OnUpdated="EntityDataSourceCategories_Updated" 
        OnInserting="CategoriesDataSource_Inserting" OnInserted="CategoriesDataSource_Inserted"/>
    <asp:GridView ID="GridViewCategories" runat="server" 
        DataSourceID="EntityDataSourceCategories"
        AutoGenerateColumns="False" DataKeyNames="CategoryID"
        AllowPaging="True" AllowSorting="True"
        ShowFooter="True"
        >
        <Columns>
            <asp:ImageField HeaderText="" DataImageUrlField="CategoryImage" 
                ControlStyle-Width="72" ControlStyle-Height = "48"></asp:ImageField>
            <asp:TemplateField HeaderText="Image file name" SortExpression="CategoryImage">
                <ItemTemplate>
                    <asp:Label ID="LabelCategoryImage" runat="server" Text='<%#: Eval("CategoryImage") %>'/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="FileUploadControl" runat="server" />  
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:FileUpload ID="FFileUploadControl" runat="server" />  
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name" SortExpression="CategoryName">
                <ItemTemplate>
                    <asp:Label ID="LabelCategoryName" Text='<%#: Eval("CategoryName")%>' runat="server" BorderStyle="None"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxCategoryName" Text='<%#: Eval("CategoryName")%>' runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="FTextBoxCategoryName" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" SortExpression="CategoryDescription" >
                <ItemTemplate>
                    <asp:Label ID="LabelCategoryDescription" Text='<%#: Eval("CategoryDescription")%>' runat="server" BorderStyle="None"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxCategoryDescription" Text='<%#: Eval("CategoryDescription")%>' runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="FTextBoxCategoryDescription" runat="server"></asp:TextBox>
                    <asp:Button ID="ButtonInsert" runat="server" OnClick="ButtonInsertCategory_Click" Text="Add" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" ButtonType="Image"
                EditImageUrl="~/Images/Toolbar/Edit.png" 
                UpdateImageUrl="~/Images/Toolbar/Save.png" 
                CancelImageUrl="~/Images/Toolbar/Clear.png" />
            <asp:CommandField ShowDeleteButton="True" ButtonType="Image"
                DeleteImageUrl="~/Images/Toolbar/Delete.png" />
        </Columns>
    </asp:GridView>
</asp:Content>
