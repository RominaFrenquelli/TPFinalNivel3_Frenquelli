<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Gestor_Comercio.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-white">
        <hr />
        <h3>Error</h3>
        <asp:Label Text="text" id="lblError" runat="server" />
        <div class="mb-3">
            <a href="javascript:history.back()" class="text-white">Volver a la página anterior</a>
        </div>
    </div>
</asp:Content>
