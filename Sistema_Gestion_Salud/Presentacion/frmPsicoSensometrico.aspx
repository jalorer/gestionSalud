<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmPsicoSensometrico.aspx.cs" Inherits="Sistema_Gestion_Salud.Presentacion.frmPsicoSensometrico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
                                                    <td style="width: 99%">Exámen PsicoSensométrico
                                                    </td>
                                                </tr>
                                            </table>

                                        </div>
                                        <div class="divColorDos"></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario "></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="lblPeriodo" runat="server" Text="Período de Vencimiento" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="lblTipoVehiculo" runat="server" Text="Tipo Vehículo" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label2" runat="server" Text="Fecha Examen PsicoSensométrico" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="lblCausaContraindicacion" runat="server" Text="Causa de Contraindicación" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario "></td>
                                    <td class="columnaPrimario">
                                        <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="Combo" AutoPostBack="true" Style="text-align: center;" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:DropDownList ID="ddlTipoVehiculo" runat="server" CssClass="Combo" Style="text-align: center;" OnSelectedIndexChanged="ddlTipoVehiculo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtFechaControl" runat="server" AutoPostBack="true" CssClass="CajaTexto" AutoCompleteType="Disabled" Enabled="false" OnTextChanged="txtFechaControl_TextChanged"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender
                                            ID="txtFechaControl_CalendarExtender"
                                            runat="server"
                                            BehaviorID="txtFechaControl_CalendarExtender"
                                            FirstDayOfWeek="Monday"
                                            Format="dd-MM-yyyy"
                                            TargetControlID="txtFechaControl" />
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:DropDownList ID="ddlCausaContraindicacion" runat="server" CssClass="Combo" Style="text-align: center;"></asp:DropDownList>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario "></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="lblFechaVencimiento" runat="server" Text="Fecha Vencimiento" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label5" runat="server" Text="Días Restantes" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="lblEstado" runat="server" Text="Estatus" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="Label7" runat="server" Text="Observación" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario "></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="CajaTexto" AutoCompleteType="Disabled" Enabled="false"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender
                                            ID="txtFechaVencimiento_CalendarExtender"
                                            runat="server"
                                            BehaviorID="txtFechaVencimiento_CalendarExtender"
                                            FirstDayOfWeek="Monday"
                                            Format="dd-MM-yyyy"
                                            TargetControlID="txtFechaVencimiento" />
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtDiasRestantes" runat="server" CssClass="CajaTexto" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:DropDownList ID="ddlEstatus" runat="server" CssClass="Combo" AutoPostBack="true" Style="text-align: center;" OnSelectedIndexChanged="ddlEstatus_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtObservacionControl" runat="server" CssClass="CajaTexto"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>

                                 <tr>
                                    <td class="colTablaPanelPrimario "></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="lblPendientes" runat="server" Text="Pendientes" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                       
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                       
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                 <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario" colspan="3">
                                                    <div class="containerClass">
                                                        <asp:TextBox ID="txtPendientes"
                                                            ClientIDMode="Static"                                                           
                                                            runat="server"
                                                            MaxLength="1000"
                                                            CssClass="CajaMultiline"
                                                            Rows="2"
                                                            TextMode="MultiLine">
                                                        </asp:TextBox>
                                                       
                                                    </div>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario" colspan="3">
                                                    
                                                </td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>
                                <tr class="filaBotonera">
                                    <td class="colTablaPanelPrimario"></td>
                                    <td colspan="8" class="tdBotonera">
                                        <table>
                                            <tr>
                                                <td class="columnaPrimario">
                                                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="Boton" OnClick="btnGuardar_Click" />
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

                                <tr>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario" colspan="7">
                                        <asp:Label ID="lblMensaje" runat="server" CssClass="Label" Text="No existen datos asociados" Visible="false"></asp:Label>
                                        <asp:GridView ID="gvDatos"
                                            runat="server"
                                            AutoGenerateColumns="False"
                                            CssClass="GridView"
                                            AllowSorting="True"
                                            AllowPaging="true"
                                            PageSize="15" OnPageIndexChanging="gvDatos_PageIndexChanging" OnRowCommand="gvDatos_RowCommand">
                                            <AlternatingRowStyle CssClass="FilaAlternaResultados" />
                                            <Columns>
                                                <asp:BoundField DataField="ID" HeaderText="ID">
                                                    <HeaderStyle CssClass="ColumnaOculta" />
                                                    <ItemStyle CssClass="ColumnaOculta" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TIPO_VEHICULO" HeaderText="Tipo Vehículo" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FECHA_CONTROL" HeaderText="Fecha Examen Psico." ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CAUSA_CONTRAINDICACION" HeaderText="Causa Contraindicación" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FECHA_VENCIMIENTO" HeaderText="Fecha Vencimiento" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DIAS_RESTANTES" HeaderText="Días Restantes" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ESTATUS" HeaderText="Estatus" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="OBSERVACION_CONTROL" HeaderText="Observación" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                  <asp:BoundField DataField="PENDIENTES" HeaderText="Pendientes" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Editar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgSeleccionar" runat="server" ToolTip="Editar" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Seleccionar" ImageUrl="~/imagenes/Iconos/Seleccionar.png" />
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="Icono" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="TituloResultados" />
                                            <RowStyle CssClass="FilaResultados" />
                                            <PagerStyle CssClass="Paginacion" />
                                        </asp:GridView>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="filaTitulo" colspan="9">
                                        <div class="divColorUno">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 1%"></td>
                                                    <td style="width: 99%">Bitácora
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div class="divColorDos"></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="colTablaPanelPrimario "></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="lblComentario" runat="server" Text="Comentario" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>

                                <tr>
                                    <td class="colTablaPanelPrimario "></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtComentarioBitacora" runat="server" CssClass="CajaTexto" AutoCompleteType="Disabled"></asp:TextBox>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>

                                <tr class="filaBotonera">
                                    <td class="colTablaPanelPrimario"></td>
                                    <td colspan="8" class="tdBotonera">
                                        <table>
                                            <tr>
                                                <td class="columnaPrimario">
                                                    <asp:Button ID="btnGuardarComentarioBitacora" runat="server" Text="Guardar Comentario" CssClass="Boton" OnClick="btnGuardarComentarioBitacora_Click" />
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
                                <tr>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario" colspan="7">
                                        <asp:Label ID="lblMensajeBitacora" runat="server" CssClass="Label" Text="No existen Comentarios en la bitácora" Visible="false"></asp:Label>
                                        <asp:GridView ID="gvBitacora"
                                            runat="server"
                                            AutoGenerateColumns="False"
                                            CssClass="GridView"
                                            AllowSorting="True"
                                            AllowPaging="true"
                                            PageSize="3" OnPageIndexChanging="gvBitacora_PageIndexChanging">
                                            <AlternatingRowStyle CssClass="FilaAlternaResultados" />
                                            <Columns>
                                                <asp:BoundField DataField="ID_Bitacora" HeaderText="ID">
                                                    <HeaderStyle CssClass="ColumnaOculta" />
                                                    <ItemStyle CssClass="ColumnaOculta" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fecha_Entrada" HeaderText="Fecha" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Comentario" HeaderText="Comentario Bitácora" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ID_Usuario_Comentario" HeaderText="Cuenta Usuario Comenta" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SubTipo" HeaderText="SubTipo" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                            </Columns>
                                            <HeaderStyle CssClass="TituloResultados" />
                                            <RowStyle CssClass="FilaResultados" />
                                            <PagerStyle CssClass="Paginacion" />
                                        </asp:GridView>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>
                                
                            </table>
                            
                        </asp:Panel>
                        
                    </td>
                    
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
