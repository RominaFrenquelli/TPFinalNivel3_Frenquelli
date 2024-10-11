<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gestor_Comercio.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <nav class="navbar navbar-expand-lg" style="background-color: #549be1; border-color: #148a85;">
        <div class="container-fluid">

            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <a class="nav-link active" aria-current="page" href="Default.aspx">Home</a>
                    </li>
                    <li class="nav-item dropdown">
                        <asp:Label Text="Categorias" runat="server" CssClass="nav-link active dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown" aria-expanded="false" />
                        <asp:DropDownList runat="server" ID="ddlMenu" CssClass="dropdown-menu" AutoPostBack="true" OnSelectedIndexChanged="ddlMenu_SelectedIndexChanged">
                        </asp:DropDownList>
                    </li>

                    <li class="nav-item">
                        <%if (Business.Seguridad.EsAdmin(Session["usuario"]))
                            { %>
                        <a class="nav-link active" href="ListaArticulos.aspx">Lista de Articulos</a>
                        <%} %>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link active" href="Favoritos.aspx">Marcas</a>
                    </li>
                </ul>
            </div>
            <div class="d-flex">
                <span class="input-group-text">Buscar</span>
                <asp:TextBox runat="server" ID="txtFiltrar" CssClass="form-control" aria-describedby="btnBuscar" AutoPostBack="true" OnTextChanged="txtFiltrar_TextChanged" />
                <button class="btn btn-secondary" type="button" id="btnBuscar">
                    <img src="images/lupa.png" alt="Buscar" /></button>
            </div>

        </div>
    </nav>
    <div class="container">
        <hr />
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
                                            <asp:Button ID="btnFavorito" runat="server" CssClass='<%# EsFavorito(Eval("Id").ToString()) ? "btn btn-favorito favorito" : "btn btn-favorito no-favorito" %>' CommandArgument='<%# Eval("Id") %>' OnClick="btnFavorito_Click" Text="❤" AutoPostBack="true"/>                                    
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div class="card-footer">
                                <small class="text-body-secondary">Precio: $ <%#Eval("Precio") %></small>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
