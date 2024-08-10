<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gestor_Comercio.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater ID="reprepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%# CargarImagen(Eval("ImagenUrl").ToString()) %>" class="card-img-top img-ajustada" alt="Imagen del Producto">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Marca")%></p>
                            <a href="DetalleArticulo.aspx?Id=<%#Eval("Id") %>">Ver Detalle</a>
                        </div>
                        <div class="card-footer">
                            <small class="text-body-secondary">Precio: $ <%#Eval("Precio") %></small>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
