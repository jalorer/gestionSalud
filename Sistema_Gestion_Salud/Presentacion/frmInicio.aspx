<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="frmInicio.aspx.cs" Inherits="Sistema_Gestion_Salud.Presentacion.frmInicio" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table  style="width: 80%;">
        <tr  style="height: 150px;">
            <td colspan="3" >
                </td>
        </tr>
        <tr>
         
            <td colspan="3" style="text-align: center">
                
                <asp:Label ID="lblTitulo" runat="server" Text="" CssClass="Label3"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width:35%;"></td>
        <%--     <td>
                <asp:Button ID="btnRiesgosCorporativos" runat="server" Text="RIESGOS CORPORATIVOS" CssClass="BotonInicio2" OnClick="btnKaizen_Click"/>
            </td>
          <td>
                <asp:Button ID="btnEventos" runat="server" Text="EVENTOS OPERACIONALES" CssClass="BotonInicio2" OnClick="btnEventos_Click"  />
            </td>--%>
            <td style="width: 25%;"></td>
        </tr>
<%--         <tr>
            <td style="width:35%;"></td>
             <td>
                <asp:Button ID="btnProyectosIdeas" runat="server" Text="PROYECTOS" CssClass="BotonInicio2" OnClick="btnProyectosIdeas_Click"  />
            </td>
            <td>
                <asp:Button ID="btnKpiProcesos" Visible="false" runat="server" Text="KPI DE PROCESOS" CssClass="BotonInicio2" OnClick="btnKpiProcesos_Click"/>
            </td>
             
            <td style="width: 25%;"></td>
        </tr>--%>
        <tr>
            <td>
                
            </td>
            <td>

            </td>
            <td>

            </td>
        </tr>
        
    </table>
</asp:Content>

