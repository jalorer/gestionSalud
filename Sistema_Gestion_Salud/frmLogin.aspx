<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="Sistema_Gestion_Salud.frmLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" >
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <table class="TablaPrincipal">
                <tr class="Fila">

                    <td></td>
                    <td class="Columna"></td>
                    <td></td>

                </tr>
                <tr>
                    <td></td>
                    <td>

                        <table class="TablaSecundaria">
                            <tr>

                                <td class="ColumnaSecundaria"></td>
                                <td class="ColumnaCentralSecundaria">
                                    <asp:Panel ID="Panel1" runat="server" CssClass="Panel">
                                        <table class="TablaLogin">
                                            <tr>
                                                <td class="FilaVacia"></td>
                                            </tr>
                                            <tr>
                                                <td class="Centro" colspan="3">
                                                    <asp:Label ID="Label1" runat="server" Text="Sistema de Gestión de Salud" CssClass="LabelTitulo"></asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="FilaVacia2"></td>

                                            </tr>
                                            <tr>
                                                <td class="ColumnaLogin"></td>
                                                <td class="Izquierda">
                                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" CssClass="LabelLogin" Text="Cuenta:"></asp:Label>
                                                </td>
                                                <td class="ColumnaLogin"></td>
                                            </tr>
                                            <tr>
                                                <td class="ColumnaLogin"></td>
                                                <td class="Izquierda">
                                                    <asp:TextBox ID="UserName" runat="server" CssClass="CajaTextoLogin"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" Font-Size="13px" ErrorMessage="El nombre de usuario es obligatorio." ToolTip="El nombre de usuario es obligatorio." ValidationGroup="Login1">*</asp:RequiredFieldValidator>

                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" FilterType="Custom" ValidChars="a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z" TargetControlID="UserName" />

                                                </td>
                                                <td class="ColumnaLogin"></td>
                                            </tr>
                                            <tr>
                                                <td class="ColumnaLogin"></td>
                                                <td class="Izquierda">
                                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Text="Clave:" CssClass="LabelLogin"></asp:Label>
                                                </td>
                                                <td class="ColumnaLogin"></td>
                                            </tr>
                                            <tr>
                                                <td class="ColumnaLogin"></td>
                                                <td >
                                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="CajaTextoLogin"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" Font-Size="13px" ErrorMessage="La contraseña es obligatoria." ToolTip="La contraseña es obligatoria." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                </td>
                                                <td class="ColumnaLogin"></td>
                                            </tr>
                                            <tr>
                                                <td class="ColumnaLogin"></td>
                                                <td>

                                                    <asp:Label ID="FailureText" runat="server" CssClass="Falla"></asp:Label>

                                                </td>
                                                <td class="ColumnaLogin"></td>
                                            </tr>
                                            <tr>
                                                <td class="ColumnaLogin"></td>
                                                <td >
                                                    <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Inicio de sesión" ValidationGroup="Login1" CssClass="BotonLogin" OnClick="LoginButton_Click" />
                                                    <asp:CheckBox ID="chCompañia" runat="server" Text="Acceso SGSCM" CssClass="LabelLogin" Checked="true" />
                                                </td>
                                                <td class="ColumnaLogin"></td>

                                            </tr>
                                            <tr>
                                                <td class="FilaVacia"></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>

                                </td>
                                <td class="ColumnaSecundaria"></td>




                            </tr>

                        </table>


                    </td>
                    <td></td>
                </tr>
            </table>


        </div>
    </form>
</body>
</html>
