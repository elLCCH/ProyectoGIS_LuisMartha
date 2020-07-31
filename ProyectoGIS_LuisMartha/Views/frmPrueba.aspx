<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPrueba.aspx.cs" MasterPageFile="~/Views/Shared/General.Master" Inherits="ProyectoGIS_LuisMartha.Views.frmPrueba" %>
<asp:Content ID="cont1" ContentPlaceHolderID="partMain" runat="server"> 
    <!DOCTYPE html>

<html>
<head >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          
        <button>sadasd</button>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Titulo" HeaderText="Titulo" SortExpression="Titulo" />
                <asp:BoundField DataField="Contenido" HeaderText="Contenido" SortExpression="Contenido" />
                <asp:BoundField DataField="Autor" HeaderText="Autor" SortExpression="Autor" />
                <asp:BoundField DataField="Publicacion" HeaderText="Publicacion" SortExpression="Publicacion" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbGISConnectionString %>" SelectCommand="SELECT * FROM [Usuarios]"></asp:SqlDataSource>
        <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
        <asp:CheckBox ID="CheckBox1" runat="server" />
        <a href="#">content</a>
        <input id="Button1" type="button" value="button" class="btn btn-warning"/>
        <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" Cssclass="btn btn-warning"/>
    </form>
</body>
</html>
        </asp:Content>
