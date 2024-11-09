<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Gestor_Comercio.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container text-white">
        <hr />
        <h1>Favoritos</h1>
        <asp:Label Text="" ID="lblMensaje" runat="server" />

        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="repRepetidor" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">
                            <img src="<%# CargarImagen(Eval("ImagenUrl").ToString()) %>" class="card-img-top img-ajustada" alt="Imagen del Producto">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><%#Eval("Marca")%></p>
                                <a href="DetalleArticulo.aspx?Id=<%#Eval("Id") %>">Ver Detalle</a>
                                <div class="d-flex justify-content-end">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btnEliminarFavorito" runat="server" CssClass="btn btn-favorito favorito" CommandArgument='<%# Eval("Id") %>' OnClick="btnEliminarFavorito_Click" AutoPostBack="true"/>                                    
                                        </ContentTemplate>
                                    </asp:UpdatePanel>                                    
                                </div>
                            </div>
                            <div class="card-footer">
                                <small>Precio: $ <%#Eval("Precio") %></small>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
