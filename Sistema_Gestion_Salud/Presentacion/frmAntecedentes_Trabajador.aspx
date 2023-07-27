<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmAntecedentes_Trabajador.aspx.cs" Inherits="Sistema_Gestion_Salud.Presentacion.frmAntecedentes_Trabajador" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table class="tablaPrincipal">
                <tr>
                    <td class="colTablaPrincipal"></td>
                    <td class="colCentroTablaPrincipal">
                        <asp:Panel ID="Panel1" runat="server" CssClass="PanelPrimario">
                            <table class="tablaPanelPrimario">
                                <tr>
                                    <td class="filaTitulo" colspan="9">
                                        <div class="divColorUno">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 1%"></td>
                                                    <td style="width: 99%">Ficha Médica Digital
                                                    </td>
                                                </tr>
                                            </table>

                                        </div>
                                        <div class="divColorDos"></div>
                                    </td>
                                </tr>
                                <%--LABEL--%>
                                <tr>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="lblRut" Font-Size="Large" runat="server" Text="RUT :" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"><td class="colTablaPanelPrimario"></td>
                                </tr>
                                <%--LABEL--%>
                                <tr>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario "></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="lblNombre" Font-Size="Large" runat="server" Text="NOMBRE :" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario" colspan="7"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario" colspan="7"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label4" runat="server" Text="Nombre" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label5" runat="server" Text="Estatus Exámen Ocupacional" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtExOcupacional" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                            <asp:ImageButton ID="imgExamenOcupacional" class="cssButton" runat="server" ToolTip="Estatus Exámen Ocupacional"  ImageUrl="~/imagenes/Iconos/editar.png" OnClick="imgExamenOcupacional_Click" />
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label1" runat="server" Text="Apellido Paterno" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label6" runat="server" Text="Estatus PsicoSensométrico" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtPsicosensometrico" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                        <asp:ImageButton ID="imExamenPsicosensometrico" class="cssButton" runat="server" ToolTip="Estatus Exámen PsicoSensométrico"  ImageUrl="~/imagenes/Iconos/editar.png" OnClick="imExamenPsicosensometrico_Click" />
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                 <tr>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label7" runat="server" Text="Apellido Materno" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label8" runat="server" Text="Riesgo Fatiga y Somnolencia" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtFatigaSomnolencia" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                 <tr>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label9" runat="server" Text="Gerencia" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtGerencia" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label10" runat="server" Text="Estatus Sílice" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtSilice" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label11" runat="server" Text="Superintendencia" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtSuperintendencia" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label12" runat="server" Text="Estatus Ruido" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtRuido" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label13" runat="server" Text="Cargo" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtCargo" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label14" runat="server" Text="Estatus TMER" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtTmer" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                 <tr>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label15" runat="server" Text="Team" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtTeam" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label16" runat="server" Text="Estatus Metales" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtMetales" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label17" runat="server" Text="Mail" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtMail" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label18" runat="server" Text="Patologías Crónicas" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtPatologiasCronicas" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label19" runat="server" Text="Fono" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtFono" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                         <asp:Label ID="lblVigenciaMinsal" runat="server" Text="Vigencia Minsal" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"> <asp:TextBox ID="txtVigenciaMinsal" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox></td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                 <tr>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label20" runat="server" Text="Fecha Ingreso" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtFechaIngreso" runat="server" CssClass="CajaTextoPrincipal" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                <%--BOTONES--%>
                                <tr class="filaBotonera">
                                    <td class="colTablaPanelPrimario"></td>
                                    <td colspan="8" class="tdBotonera">
                                        <table>
                                            <tr>
                                                <td class="columnaPrimario">
                                                     <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="Boton" OnClick="btnVolver_Click" />
                                                    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender12" runat="server" BehaviorID="btnVolver_HoverMenuExtender" PopupControlID="Panel11" PopupPosition="Top" TargetControlID="btnVolver">
                                                    </ajaxToolkit:HoverMenuExtender>
                                                    <asp:Panel ID="Panel11" runat="server" CssClass="ToolTip">
                                                        <table>
                                                            <tr>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Permite volver a la pantalla anterior
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                                <td class="colTablaPanelPrimario"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                               


                                           
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>