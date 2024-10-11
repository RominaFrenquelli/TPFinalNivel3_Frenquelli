<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Gestor_Comercio.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="container">
        <hr />
        <div class="card">
            <div class="card-header">
                <asp:Label Text="" ID="lblCategoria" runat="server" CssClass="h2 form-label"/>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-6">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png" runat="server" ID="imgArticulo" CssClass="img-ajustada2" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-6 d-flex flex-column">
                        <div class="mb-3">
                            <asp:Label ID="lblNombre" runat="server" Text="" CssClass="h2 form-label"></asp:Label>
                        </div>
                        <div class="mb-3">
                            <label for="lblCodigo" class="form-label">Codigo: </label>
                            <asp:Label ID="lblCodigo" runat="server" Text="Codigo: " CssClass="form-label"></asp:Label>
                        </div>
                        <div class="mb-3">
                            <label for="lblMarca" class="form-label">Marca: </label>
                            <asp:Label ID="lblMarca" runat="server" Text="Marca: " CssClass="form-label"></asp:Label>
                        </div>
                        <div class="mb-3">
                            <label for="lblPrecio" class="h3 text-start form-label">$ </label>
                            <asp:Label ID="lblPrecio" runat="server" Text="" CssClass="h3 text-start form-label"></asp:Label>
                        </div>
                        <div class="mt-auto">
                            <asp:Button Text="Comprar" runat="server" ID="btnComprar" CssClass="btn btn-primary me-2" />
                        </div>
                    </div>
                 </div>
                  <div class="row">
                      <div class="col-6">
                          <div class="mb-3">
                              <label for="lblDescripcion" class="form-label">Descripcion: </label>
                              <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion: " CssClass="form-label"></asp:Label>
                          </div>
                      </div>
                  </div>
              </div>
        </div>
    </div>
</asp:Content>
