<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" 
    AutoEventWireup="true" CodeBehind="Categories.aspx.cs"
    Inherits="BookingSystem.Views.Admin.Categories" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="AdminContent" runat="server">
    <h1>Categories</h1>
    <asp:EntityDataSource ID="EntityDataSourceCategories" runat="server" 
        ConnectionString="name=BookingSystemDataEntities" 
        DefaultContainerName="BookingSystemDataEntities" 
        EnableInsert="true" EnableUpdate="true" EnableDelete="true"   
        EntitySetName="Categories" 
        OnUpdating="EntityDataSourceCategories_Updating" OnUpdated="EntityDataSourceCategories_Updated" 
        OnInserting="CategoriesDataSource_Inserting" OnInserted="CategoriesDataSource_Inserted"/>
    <asp:GridView ID="GridViewCategories" runat="server" 
        DataSourceID="EntityDataSourceCategories"
        AutoGenerateColumns="False" DataKeyNames="CategoryID"
        AllowPaging="True" AllowSorting="True"
        AlternatingRowStyle-BackColor="LightGray"
        ShowFooter="True"
        >
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectImageUrl="~/Images/Toolbar/Select.png" />
            <asp:CommandField ShowInsertButton="True" InsertImageUrl="~/Images/Toolbar/Insert.png" /> 
            <asp:ImageField HeaderText="" DataImageUrlField="CategoryImage" 
                ControlStyle-Width="72" ControlStyle-Height = "48"></asp:ImageField>
            <asp:TemplateField HeaderText="Image file name">
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
            <asp:CommandField ShowEditButton="True" EditImageUrl="~/Images/Toolbar/Edit.png" />
            <asp:CommandField ShowDeleteButton="True" DeleteImageUrl="~/Images/Toolbar/Delete.png" />
        </Columns>
    </asp:GridView>

    <h1>Services in selected category</h1>
    <asp:EntityDataSource ID="EntityDataSourceServices" runat="server" 
        ConnectionString="name=BookingSystemDataEntities" 
        DefaultContainerName="BookingSystemDataEntities" 
        EnableInsert="true" EnableUpdate="true" EnableDelete="true"
        EntitySetName="Services"
        OnInserting="ServicesDataSource_Inserting" OnInserted="ServicesDataSource_Inserted" 
        Where="it.CategoryID=@CatID">
        <WhereParameters>
            <asp:ControlParameter Name="CatID" Type="Int32"
                ControlID="GridViewCategories" />
        </WhereParameters>
    </asp:EntityDataSource>
    <asp:GridView ID="GridViewServices" runat="server" 
        DataSourceID="EntityDataSourceServices"
        AutoGenerateColumns="False" DataKeyNames="ServiceID"
        AllowPaging="True" AllowSorting="True"
        AlternatingRowStyle-BackColor ="GrayText"
        ShowFooter="True"
        >
        <Columns>
            <asp:CommandField ShowSelectButton="True" SelectImageUrl="./../../Images/Toolbar/Select.png" />
            <asp:CommandField ShowInsertButton="True" InsertImageUrl="./../../Images/Toolbar/Insert.png" /> 
            <asp:TemplateField HeaderText="Name" SortExpression="ServiceName">
                <ItemTemplate>
                    <asp:Label ID="LabelServiceName" Text='<%#: Eval("ServiceName")%>' runat="server" BorderStyle="None"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxServiceName" Text='<%#: Eval("ServiceName")%>' runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="FTextBoxServiceName" runat="server"></asp:TextBox>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" SortExpression="ServiceDescription" >
                <ItemTemplate>
                    <asp:Label ID="LabelServiceDescription" Text='<%#: Eval("ServiceDescription")%>' runat="server" BorderStyle="None"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxServiceDescription" Text='<%#: Eval("ServiceDescription")%>' runat="server" ></asp:TextBox>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="FTextBoxServiceDescription" runat="server"></asp:TextBox>
                    <asp:Button ID="ButtonInsert" runat="server" OnClick="ButtonInsertService_Click" Text="Add" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowEditButton="True" EditImageUrl="~/Images/Toolbar/Edit.png" />
            <asp:CommandField ShowDeleteButton="True" DeleteImageUrl="~/Images/Toolbar/Delete.png" />
        </Columns>
    </asp:GridView>
</asp:Content>
