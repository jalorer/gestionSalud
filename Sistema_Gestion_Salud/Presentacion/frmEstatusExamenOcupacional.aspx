<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmEstatusExamenOcupacional.aspx.cs" Inherits="Sistema_Gestion_Salud.Presentacion.frmEstatusExamenOcupacional" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ajax__fileupload_selectFileContainer .ajax__fileupload_selectFileButton {
            color: white !important;
            font-family: Calibri;
            font-size: 9pt;
            border: 1px solid #318aac;
            transition: all 1s ease;
            width: 150px !important;
            top: 0px;
            left: 1px;
            background: #808080;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        $('.ajax__fileupload_uploadbutton').hide();
        $(document).ready(function () {
            AjaxFileUpload_change_text();
        });
        function AjaxFileUpload_change_text() {
            //Here you can write whatever you want = "..."
            Sys.Extended.UI.Resources.AjaxFileUpload_SelectFile = "Elegir archivo";
            Sys.Extended.UI.Resources.AjaxFileUpload_DropFiles = "Arrastre archivo Aquí";
            Sys.Extended.UI.Resources.AjaxFileUpload_Pending = "Pendiente";
            Sys.Extended.UI.Resources.AjaxFileUpload_Remove = "Eliminar";
            Sys.Extended.UI.Resources.AjaxFileUpload_Upload = "Cargar";
            Sys.Extended.UI.Resources.AjaxFileUpload_Uploaded = "Archivo Cargado";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadedPercentage = "Cargado {0} %";
            Sys.Extended.UI.Resources.AjaxFileUpload_Uploading = "Cargando";
            Sys.Extended.UI.Resources.AjaxFileUpload_FileInQueue = "{0} Archivo(s) en cola.";
            Sys.Extended.UI.Resources.AjaxFileUpload_AllFilesUploaded = "";
            Sys.Extended.UI.Resources.AjaxFileUpload_FileList = "Lista de archivos cargados:";
            Sys.Extended.UI.Resources.AjaxFileUpload_SelectFileToUpload = "";
            Sys.Extended.UI.Resources.AjaxFileUpload_Cancelling = "Cancelado...";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadError = "Se produjo un error durante la carga del archivo.";
            Sys.Extended.UI.Resources.AjaxFileUpload_CancellingUpload = "Cancelando la carga...";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadingInputFile = "Cargando archivo: {0}.";
            Sys.Extended.UI.Resources.AjaxFileUpload_Cancel = "Cancelar";
            Sys.Extended.UI.Resources.AjaxFileUpload_Canceled = "Cancelado";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadCanceled = "Carga de archivos cancelada";
            Sys.Extended.UI.Resources.AjaxFileUpload_DefaultError = "Error en carga de archivo";
            Sys.Extended.UI.Resources.AjaxFileUpload_UploadingHtml5File = "Cargando archivo: {0} de tamaño {1} bytes.";
            Sys.Extended.UI.Resources.AjaxFileUpload_error = "Error";
            Sys.Extended.UI.Resources.AjaxFileUpload_WrongFileType = "No es posible cargar archivo {0}. Archivo del tipo {1} no está permitido";
        }

        function CargarNombre() {
            document.getElementById( '<%= btnCarga.ClientID %>').click();
        }

        function getCountDownOP() {
            //Get the Textbox control
            var textField = document.getElementById("<%#txtOtrasPatologias.ClientID %>");
            //Do the math of chars left and pass the value to the label
            document.getElementById('<%#lblContadorOP.ClientID %>').innerHTML = textField.maxLength - textField.value.length + " caracteres restantes";
            return false;
        }

        function getCountDownAQ() {
            //Get the Textbox control
            var textField = document.getElementById("<%#txtAntecedentesQuirurgicos.ClientID %>");
            //Do the math of chars left and pass the value to the label
            document.getElementById('<%#lblContadorAQ.ClientID %>').innerHTML = textField.maxLength - textField.value.length + " caracteres restantes";
            return false;
        }

    </script>
    <style type="text/css">
        .auto-style2 {
            width: 100%;
            margin-bottom: 0px;
            background-color: white;
        }
    </style>
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
                                                    <td style="width: 99%">Examen Ocupacional
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
                                        <asp:Label ID="lblPeriodo" runat="server" Text="Período" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="lblFechaCita" runat="server" Text="Fecha Cita" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:Label ID="lblAsistenciaCita" runat="server" Text="Asistencia" CssClass="Label"></asp:Label>
                                    </td>
                                    <td class="colTablaPanelPrimario"></td>
                                    <td class="columnaPrimario"></td>
                                    <td class="colTablaPanelPrimario"></td>
                                </tr>

                                <tr>
                                    <td class="colTablaPanelPrimario "></td>
                                    <td class="columnaPrimario">
                                        <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="Combo" AutoPostBack="true" OnSelectedIndexChanged="ddlPeriodo_SelectedIndexChanged"></asp:DropDownList>
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:TextBox ID="txtFechaCita" runat="server" CssClass="CajaTexto" AutoPostBack="True" AutoCompleteType="Disabled"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender
                                            ID="txtFechaCita_CalendarExtender"
                                            runat="server"
                                            BehaviorID="txtFechaCita_CalendarExtender"
                                            FirstDayOfWeek="Monday"
                                            Format="dd-MM-yyyy"
                                            TargetControlID="txtFechaCita" />
                                    </td>
                                    <td class="colTablaPanelPrimario borde"></td>
                                    <td class="columnaPrimario">
                                        <asp:DropDownList ID="ddlAsistenciaCita" runat="server" CssClass="Combo" AutoPostBack="true"></asp:DropDownList>
                                    </td>
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
                                                    <asp:Button ID="btnGuardarActualizar" runat="server" Text="Guardar" CssClass="Boton" OnClick="btnGuardarActualizar_Click" />
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
                                        <asp:Label ID="lblMensaje" runat="server" CssClass="Label" Text="No existen Citas Asociadas" Visible="false"></asp:Label>
                                        <asp:GridView ID="gvDatos"
                                            runat="server"
                                            AutoGenerateColumns="False"
                                            CssClass="GridView"
                                            AllowSorting="True"
                                            AllowPaging="true"
                                            PageSize="5" OnPageIndexChanging="gvDatos_PageIndexChanging" OnRowCommand="gvDatos_RowCommand" OnRowDataBound="gvDatos_RowDataBound">
                                            <AlternatingRowStyle CssClass="FilaAlternaResultados" />
                                            <Columns>
                                                <asp:BoundField DataField="ID_Cita" HeaderText="ID">
                                                    <HeaderStyle CssClass="ColumnaOculta" />
                                                    <ItemStyle CssClass="ColumnaOculta" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Fecha_Cita" HeaderText="Fecha Cita" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="DESC_ASIST" HeaderText="Descripción Cita" ItemStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Eliminar">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgEliminar" runat="server" ToolTip="Eliminar Riesgo" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Eliminar" ImageUrl="~/imagenes/Iconos/Eliminar.png" />
                                                    </ItemTemplate>
                                                    <ItemStyle CssClass="Icono" />
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Ex.Ocup">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgSeleccionar" runat="server" ToolTip="Seleccionar/Crear Riesgo" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Seleccionar" ImageUrl="~/imagenes/Iconos/Seleccionar.png" />
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
                                    <td class="colTablaPanelPrimario"></td>
                                    <caption>
                                        <div id="divExOcup" runat="server">
                                            <tr id="ExamenOcupacionalId" runat="server">
                                                <td class="filaTitulo" colspan="9">
                                                    <div class="divColorUno">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="width: 1%"></td>
                                                                <td style="width: 99%">Datos Exámen Ocupacional </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="divColorDos">
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="lblFechaDesplegar" runat="server" CssClass="Label" Font-Size="Large" Text=""></asp:Label>
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
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="lblBateria" runat="server" CssClass="Label" Text="Bateria"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="lblEstatus" runat="server" CssClass="Label" Text="Estatus"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="Label1" runat="server" CssClass="Label" Text="Contraindicación"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <%--<asp:Label ID="Label2" runat="server" CssClass="Label" Text="Patología Crónica"></asp:Label>--%>
                                                </td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>

                                            <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario">
                                                    <asp:DropDownList ID="ddlBateria" runat="server" AutoPostBack="true" CssClass="Combo">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:DropDownList ID="ddlEstatusExOcup" runat="server" AutoPostBack="true" CssClass="Combo" OnSelectedIndexChanged="ddlEstatusExOcup_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:DropDownList ID="ddlContraIndicacion" runat="server" AutoPostBack="true" CssClass="Combo">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>

                                            <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="lblParametroAlterado" runat="server" CssClass="Label" Text="Parámetros Alterados"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="lblFechaControl" runat="server" CssClass="Label" Text="Fecha Vigencia Capacitación Minsal"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>
                                            <tr>
                                                <td class="colTablaPanelPrimario"></td>
                                                <td class="columnaPrimario" colspan="3" style="vertical-align: top">
                                                    <asp:CheckBoxList ID="chkParamAlterado" runat="server" RepeatDirection="Horizontal" CssClass="Label">
                                                    </asp:CheckBoxList>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:TextBox ID="txtFechaControl" runat="server" AutoCompleteType="Disabled" CssClass="CajaTexto"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="c2" runat="server" BehaviorID="txtFechaControl_CalendarExtender" FirstDayOfWeek="Monday" Format="dd-MM-yyyy" TargetControlID="txtFechaControl" />
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>

                                            <tr class="filaBotonera">
                                                <td class="colTablaPanelPrimario"></td>
                                                <td class="tdBotonera" colspan="8">
                                                    <table>
                                                        <tr>
                                                            <td class="columnaPrimario">
                                                                <asp:Button ID="btnGuardarExOcup" runat="server" CssClass="Boton" OnClick="btnGuardarExOcup_Click" Text="Guardar Ex Ocupacional" />
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
                                        </div>
                                        <div runat="server" id="divTituloDatosPatologias">
                                            <tr>
                                                <td class="filaTitulo" colspan="9">
                                                    <div class="divColorUno">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="width: 1%"></td>
                                                                <td style="width: 99%">Datos Patologías Crónicas y Antecedentes Quirúrgicos
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="divColorDos"></div>
                                                </td>
                                            </tr>
                                        </div>
                                        <%--Se mueve botón de patología crónica--%>
                                        <div runat="server" id="divbtnPcronicas">
                                            <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="Label16" runat="server" CssClass="Label" Text="Patología Crónica"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>

                                            <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario">
                                                    <asp:DropDownList ID="ddlPatologiaCronica" runat="server" AutoPostBack="true" CssClass="Combo" OnSelectedIndexChanged="ddlPatologiaCronica_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>
                                        </div>
                                        <div id="divPatologiasCronicas" runat="server">
                                            <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="Label6" runat="server" CssClass="Label" Text="Diabetes Mielitus"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="Label7" runat="server" CssClass="Label" Text="HTA"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="Label8" runat="server" CssClass="Label" Text="Dislipidemia"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="Label9" runat="server" CssClass="Label" Text="Cardiopatía"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>
                                            <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario">
                                                    <asp:DropDownList ID="ddlDiabetes" runat="server" CssClass="Combo" AutoPostBack="true"></asp:DropDownList>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:DropDownList ID="ddlHta" runat="server" AutoPostBack="true" CssClass="Combo">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:DropDownList ID="ddlDislipidemia" runat="server" AutoPostBack="true" CssClass="Combo">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:DropDownList ID="ddlCardiopatia" runat="server" CssClass="Combo" AutoPostBack="true"></asp:DropDownList>
                                                </td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>

                                            <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="Label2" runat="server" CssClass="Label" Text="Resistencia Insulina"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>

                                            <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario">
                                                    <asp:DropDownList ID="ddlResistenciaInsulina" runat="server" CssClass="Combo" AutoPostBack="true"></asp:DropDownList>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>





                                            <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="Label10" runat="server" Text="Otras Patologías" CssClass="Label"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="Label12" runat="server" Text="Antecedentes Quirúrgicos" CssClass="Label"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>
                                            <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario" colspan="3">
                                                    <div class="containerClass">
                                                        <asp:TextBox ID="txtOtrasPatologias"
                                                            ClientIDMode="Static"
                                                            onkeyup="getCountDownOP();"
                                                            runat="server"
                                                            MaxLength="1000"
                                                            CssClass="CajaMultiline"
                                                            Rows="2"
                                                            TextMode="MultiLine">
                                                        </asp:TextBox>
                                                        <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender11" runat="server" BehaviorID="txtOtrasPatologias_HoverMenuExtender" PopupControlID="PanelContador" PopupPosition="Top" TargetControlID="txtOtrasPatologias">
                                                        </ajaxToolkit:HoverMenuExtender>
                                                        <asp:Panel ID="PanelContador" runat="server" CssClass="ToolTip" Style="display: none">
                                                            <table>
                                                                <tr>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblContadorOP" ClientIDMode="Static" runat="server" CssClass="Label" Text="1000 caracteres disponibles"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </div>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario" colspan="3">
                                                    <div class="containerClass">
                                                        <asp:TextBox ID="txtAntecedentesQuirurgicos"
                                                            ClientIDMode="Static"
                                                            onkeyup="getCountDownAQ();"
                                                            runat="server"
                                                            MaxLength="1000"
                                                            CssClass="CajaMultiline"
                                                            Rows="2"
                                                            TextMode="MultiLine">
                                                        </asp:TextBox>
                                                        <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server" BehaviorID="txtAntecedentesQuirurgicos_HoverMenuExtender" PopupControlID="Panel2" PopupPosition="Top" TargetControlID="txtAntecedentesQuirurgicos">
                                                        </ajaxToolkit:HoverMenuExtender>
                                                        <asp:Panel ID="Panel2" runat="server" CssClass="ToolTip" Style="display: none">
                                                            <table>
                                                                <tr>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblContadorAQ" ClientIDMode="Static" runat="server" CssClass="Label" Text="1000 caracteres disponibles"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </div>
                                                </td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>

                                            <tr class="filaBotonera">
                                                <td class="colTablaPanelPrimario"></td>
                                                <td colspan="8" class="tdBotonera">
                                                    <table>
                                                        <tr>
                                                            <td class="columnaPrimario">
                                                                <asp:Button ID="btnGuardarPatologiasCronicas" runat="server" Text="Guardar Pat. Crónicas" CssClass="Boton" OnClick="btnGuardarPatologiasCronicas_Click" />
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

                                        </div>
                                        <!-- CONTROLES -->

                                        <div runat="server" id="divControles">
                                            <tr>
                                                <td class="filaTitulo" colspan="9">
                                                    <div class="divColorUno">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="width: 1%"></td>
                                                                <td style="width: 99%">Controles
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
                                                    <asp:Label ID="lblFControl" runat="server" Text="Fecha Control" CssClass="Label"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario">
                                                    <asp:Label ID="lblAControl" runat="server" Text="Asistencia Control" CssClass="Label"></asp:Label>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>
                                            <tr>
                                                <td class="colTablaPanelPrimario "></td>
                                                <td class="columnaPrimario" style="vertical-align: top">
                                                    <asp:TextBox ID="txtFControl" runat="server" CssClass="CajaTexto" AutoPostBack="True" AutoCompleteType="Disabled"></asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender
                                                        ID="CalendarExtender1"
                                                        runat="server"
                                                        BehaviorID="txtFControl_CalendarExtender"
                                                        FirstDayOfWeek="Monday"
                                                        Format="dd-MM-yyyy"
                                                        TargetControlID="txtFControl" />
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario" style="vertical-align: top">
                                                    <asp:DropDownList ID="ddlAControl" runat="server" CssClass="Combo" AutoPostBack="true"></asp:DropDownList>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario" colspan="3">
                                                    <%-- <asp:TextBox ID="txtComentarioControl"
                                                        ClientIDMode="Static"
                                                        onkeyup="getCountDownC();"
                                                        runat="server"
                                                        MaxLength="1000"
                                                        CssClass="CajaMultiline"
                                                        Rows="2"
                                                        TextMode="MultiLine">
                                                    </asp:TextBox>
                                                    <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender2" runat="server" BehaviorID="txtComentarioControl_HoverMenuExtender" PopupControlID="Panel233" PopupPosition="Top" TargetControlID="txtComentarioControl">
                                                    </ajaxToolkit:HoverMenuExtender>
                                                    <asp:Panel ID="Panel233" runat="server" CssClass="ToolTip" Style="display: none">
                                                        <table>
                                                            <tr>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblC" ClientIDMode="Static" runat="server" CssClass="Label" Text="1000 caracteres disponibles"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>--%>
                                                    <%--</asp:Panel>--%>
                                                </td>
                                                <td class="colTablaPanelPrimario"></td>
                                                <td class="columnaPrimario"></td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>

                                            <%--boton guardar--%>

                                            <tr class="filaBotonera">
                                                <td class="colTablaPanelPrimario"></td>
                                                <td colspan="8" class="tdBotonera">
                                                    <table>
                                                        <tr>
                                                            <td class="columnaPrimario">
                                                                <asp:Button ID="btnGuardarControl" runat="server" Text="Guardar Control" CssClass="Boton" OnClick="btnGuardarControl_Click" />
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
                                                    <asp:Label ID="lblMensajeControles" runat="server" CssClass="Label" Text="No existen Controles Asociados" Visible="false"></asp:Label>
                                                    <asp:GridView ID="gvControles"
                                                        runat="server"
                                                        AutoGenerateColumns="False"
                                                        CssClass="GridView"
                                                        AllowSorting="True"
                                                        AllowPaging="true"
                                                        PageSize="2" OnPageIndexChanging="gvControles_PageIndexChanging">
                                                        <AlternatingRowStyle CssClass="FilaAlternaResultados" />
                                                        <Columns>
                                                            <asp:BoundField DataField="ID_Control" HeaderText="ID">
                                                                <HeaderStyle CssClass="ColumnaOculta" />
                                                                <ItemStyle CssClass="ColumnaOculta" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Fecha_Control" HeaderText="Fecha Control" ItemStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="DESC_ASIST" HeaderText="Descripción Cita" ItemStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Numero_Control" HeaderText="N° Control" ItemStyle-HorizontalAlign="Center">
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:BoundField>

                                                        </Columns>
                                                        <HeaderStyle CssClass="TituloResultados" />
                                                        <RowStyle CssClass="FilaResultados" />
                                                        <PagerStyle CssClass="Paginacion" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>

                                        </div>

                                        <%--BITACORA--%>
                                        <div runat="server" id="divBitacora">
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


                                            <%--gridBitacora--%>

                                            <tr>
                                                <td class="colTablaPanelPrimario"></td>
                                                <td class="columnaPrimario" colspan="7">
                                                    <asp:Label ID="lblMensajeBitacora" runat="server" CssClass="Label" Text="No existen Comentarios en la bitácora" Visible="false"></asp:Label>
                                                    <asp:GridView ID="gvBitacora"
                                                        runat="server"
                                                        AutoGenerateColumns="False"
                                                        CssClass="auto-style2"
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
                                            </tr>










                                        </div>
                                        <%--FIN BITACORA--%>


                                        <div runat="server" id="divAnexos">
                                            <tr>
                                                <td class="filaTitulo" colspan="9">
                                                    <div class="divColorUno">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td style="width: 1%"></td>
                                                                <td style="width: 99%">Anexos
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="divColorDos"></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="colTablaPanelPrimario"></td>
                                                <td class="columnaPrimario" colspan="3" style="vertical-align: top">
                                                    <asp:Button ID="btnCarga" runat="server" Text="Button" Style="display: none" OnClick="btnCarga_Click" />
                                                    <div class="containerClass">
                                                        <ajaxToolkit:AjaxFileUpload
                                                            ID="fileDocumento"
                                                            AutoStartUpload="true"
                                                            MaximumNumberOfFiles="1"
                                                            AllowedFileTypes="pdf,pptx,doc,docx"
                                                            runat="server"
                                                            MaxFileSize="10000"
                                                            OnUploadComplete="fileDocumento_UploadComplete"
                                                            ValidateRequestMode="Enabled"
                                                            OnClientUploadComplete="CargarNombre" />
                                                    </div>
                                                </td>
                                                <td class="colTablaPanelPrimario borde"></td>
                                                <td class="columnaPrimario" colspan="3" style="vertical-align: top">
                                                    <asp:Label ID="lblMensajeDocumentos" runat="server" CssClass="Label" Text="No existen Documentos Asociados" Visible="false"></asp:Label>
                                                    <asp:GridView ID="gvAnexos"
                                                        runat="server"
                                                        AutoGenerateColumns="False"
                                                        CssClass="GridView"
                                                        AllowSorting="True"
                                                        AllowPaging="true"
                                                        PageSize="5" OnRowCommand="gvAnexos_RowCommand" OnPageIndexChanging="gvAnexos_PageIndexChanging">
                                                        <AlternatingRowStyle CssClass="FilaAlternaResultados" />
                                                        <Columns>
                                                            <asp:BoundField DataField="ID_USUARIO" HeaderText="ID">
                                                                <HeaderStyle CssClass="ColumnaOculta" />
                                                                <ItemStyle CssClass="ColumnaOculta" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="ID_DOCUMENTO" HeaderText="ID">
                                                                <HeaderStyle CssClass="ColumnaOculta" />
                                                                <ItemStyle CssClass="ColumnaOculta" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="URL_DOCUMENTO" HeaderText="URL_DOCUMENTO" ItemStyle-HorizontalAlign="Center">
                                                                <HeaderStyle CssClass="ColumnaOculta" />
                                                                <ItemStyle CssClass="ColumnaOculta" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="NOMBRE_DOCUMENTO" HeaderText="Anexo" ItemStyle-HorizontalAlign="Center" />
                                                            <%--<asp:BoundField DataField="FECHA_DOCUMENTO" HeaderText="Fecha" ItemStyle-HorizontalAlign="Center" />--%>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imEditar" runat="server" ToolTip="Descargar Documento Asociado" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Descargar" ImageUrl="~/imagenes/Iconos/descarga.png" />
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="Icono" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="imgEliminar" runat="server" ToolTip="Eliminar Documento Asociado" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CommandName="Eliminar" ImageUrl="~/imagenes/Iconos/Eliminar.png" />
                                                                </ItemTemplate>
                                                                <ItemStyle CssClass="Icono" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="TituloResultados" />
                                                        <RowStyle CssClass="FilaResultados" />
                                                        <PagerStyle CssClass="Paginacion" />
                                                    </asp:GridView>
                                                </td>
                                                <td class="colTablaPanelPrimario"></td>
                                            </tr>
                                        </div>
                                    </caption>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--BOTON ELIMINAR ARCHIVO--%>

    <asp:Button ID="btnAgregarExOcup" runat="server" AutoPostBack="true" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupAgregarExpOcup" runat="server" TargetControlID="btnAgregarExOcup" CancelControlID="btnSalirArchivo" PopupControlID="pnlModalbtnAgregarExOcup" BackgroundCssClass="Background"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlModalbtnAgregarExOcup" runat="server" CssClass="PanelMensaje" Style="display: ">
        <table class="TablaMensaje">
            <tr>
                <td class="FilaVaciaMensaje" colspan="4"></td>
            </tr>
            <tr>
                <td class="Centro" colspan="4">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/imagenes/Alerta.PNG" Height="113px" Width="113px" /></td>
            </tr>
            <tr>
                <td class="Centro" colspan="4">
                    <asp:Label ID="Label4" runat="server" Text="Sistema Gestión Salud" CssClass="LabelTituloMensaje"></asp:Label></td>
            </tr>
            <tr>
                <td class="FilaVaciaMensaje2"></td>
            </tr>

            <tr>
                <td class="ColumnaMensaje"></td>
                <td class="Centro" colspan="3">
                    <asp:Label ID="Label5" runat="server" Text="¿No existen los examenes ocupacionales, desea agregarlos?" CssClass="LabelMensaje"></asp:Label></td>
                <td class="ColumnaMensaje"></td>
            </tr>
            <tr>
                <td class="FilaVaciaMensaje" colspan="4"></td>
            </tr>
            <tr>
                <td class="ColumnaMensaje"></td>
                <td class="Derecha">
                    <asp:Button ID="btnCrearExamenesOcupacionales" runat="server" CssClass="BotonMensaje" Text="Confirmar" OnClick="btnCrearExamenesOcupacionales_Click" />

                </td>
                <td class="Centro">
                    <asp:Button ID="btnSalirArchivo" runat="server" CssClass="BotonMensaje" Text="Salir" />
                </td>
                <td class="ColumnaMensaje"></td>
            </tr>
            <tr>
                <td class="FilaVaciaMensaje2" colspan="4"></td>
            </tr>
        </table>
    </asp:Panel>

    <%--BOTON ELIMINAR ARCHIVO--%>

    <asp:Button ID="btnEliminarArchivo" runat="server" AutoPostBack="true" Style="display: none" />

    <ajaxToolkit:ModalPopupExtender ID="ModalPopupEliminarArchivo" runat="server" TargetControlID="btnEliminarArchivo" CancelControlID="btnSalirArchivoEliminar" PopupControlID="pnlModalCerrarArchivoReunion" BackgroundCssClass="Background"></ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlModalCerrarArchivoReunion" runat="server" CssClass="PanelMensaje" Style="display: ">
        <table class="TablaMensaje">
            <tr>
                <td class="FilaVaciaMensaje" colspan="4"></td>
            </tr>
            <tr>
                <td class="Centro" colspan="4">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/Alerta.PNG" Height="113px" Width="113px" /></td>
            </tr>
            <tr>
                <td class="Centro" colspan="4">
                    <asp:Label ID="Label3" runat="server" Text="Sistema Gestión Salud" CssClass="LabelTituloMensaje"></asp:Label></td>
            </tr>
            <tr>
                <td class="FilaVaciaMensaje2"></td>
            </tr>

            <tr>
                <td class="ColumnaMensaje"></td>
                <td class="Centro" colspan="3">
                    <asp:Label ID="Label11" runat="server" Text="¿Desea eliminar el archivo seleccionado?" CssClass="LabelMensaje"></asp:Label></td>
                <td class="ColumnaMensaje"></td>
            </tr>
            <tr>
                <td class="FilaVaciaMensaje" colspan="4"></td>
            </tr>
            <tr>
                <td class="ColumnaMensaje"></td>
                <td class="Derecha">
                    <asp:Button ID="btnConfirmarEliminacionArchivo" runat="server" CssClass="BotonMensaje" Text="Confirmar" OnClick="btnConfirmarEliminacionArchivo_Click" />

                </td>
                <td class="Centro">
                    <asp:Button ID="btnSalirArchivoEliminar" runat="server" CssClass="BotonMensaje" Text="Salir" />
                </td>
                <%--  <td class="Izquierda">
                    <asp:Button ID="btnNo_btnCerrar" runat="server" CssClass="BotonMensaje" Text="Cancelar" />
                </td>--%>
                <td class="ColumnaMensaje"></td>
            </tr>
            <tr>
                <td class="FilaVaciaMensaje2" colspan="4"></td>
            </tr>
        </table>
    </asp:Panel>

</asp:Content>
