<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioArticulo.aspx.cs" Inherits="Gestor_Comercio.FormularioArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <hr />
        <div class="card">
            <div class="card-header">
                <h4>Formulario de Articulo</h4>
            </div>
            <div class="card-body">

                <div class="row">
                    <div class="col-6">
                        <div class="mb-3">
                            <label for="txtId" class="form-label">Id</label>
                            <asp:TextBox ID="txtId" runat="server" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <label for="txtCodigo" class="form-label">Codigo</label>
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <label for="ddlMarca" class="form-label">Marca</label>
                            <asp:DropDownList runat="server" ID="ddlmarca" CssClass="form-select"></asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <label for="ddlCategoria" class="form-label">Categoria</label>
                            <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="form-select"></asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <asp:Button Text="Aceptar" runat="server" ID="btnAceptar" CssClass="btb btb-primary" OnClick="btnAceptar_Click" />
                            <a href="ListaArticulos.aspx">Cancelar</a>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="mb-3">
                            <label for="txtDescripcion" class="form-label">Descripcion</label>
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
                        </div>
                        <div class="mb-3">
                            <label for="txtPrecio" class="form-label">Precio</label>
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="mb-3">
                                    <label for="txtImagenUrl" class="form-label">UrlImagen</label>
                                    <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                                </div>
                                <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" runat="server" ID="imgArticulo" Width="80%" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
