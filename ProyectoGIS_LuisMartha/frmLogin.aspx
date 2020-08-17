<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="ProyectoGIS_LuisMartha.Views.Login.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="/assets/css/index.css"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" class="datosLogin">
                <div><p class="titulo_iniciar_sesion">INICIAR SESION</p></div>
                <div style="padding:20px; height:121px; width:auto">
                <img class="imgUsuario" src="img/man-user.png" alt=""/>
                <asp:TextBox ID="txtCuenta" runat="server" CssClass="textEmail" placeholder="Escribe tu Cuenta"  AutoCompleteType="Disabled"></asp:TextBox>
                <img class="imgPassword" src="img/lock.png" alt=""/>                           
                <asp:TextBox ID="txtContrasenia" runat="server" CssClass="textPassword" placeholder="Introduzca su contraseña" TextMode="Password"></asp:TextBox>
                </div>
                <div class="checkbox" style="margin-left: 15px; left: 0px; float:left;">
                    <label style="color:#3174C1">
                    <asp:CheckBox ID="cbValidar" runat="server" Text="Validar los datos"></asp:CheckBox>
                    <br />
                    </label>
                    <asp:Label ID="lblError" runat="server" Text="Cuenta o Contraseña Incorrectos" ForeColor="Red" Visible="False"></asp:Label>
                </div>
                <asp:Button ID="btnIniciar" runat="server" Text="Iniciar Sesion" CssClass="boton" Font-Size="100%" OnClick="btnIniciar_Click"></asp:Button>
            </form>
</body>
</html>
