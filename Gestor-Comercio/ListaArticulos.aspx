<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="Gestor_Comercio.ListaArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>  
    <div class="container">
        <hr />
        <div class="card">
            <div class="card-header">
                <h4>Lista de Articulos</h4>
            </div>
            <div class="card-body">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>


                        <div class="row">
                            <div class="col-6">
                                <div class="input-group mb-3">
                                    <span class="input-group-text">Buscar</span>
                                    <asp:TextBox runat="server" ID="txtBuscar" CssClass="form-control" aria-describedby="btnBuscar" AutoPostBack="true" OnTextChanged="txtBuscar_TextChanged" />
                                    <button class="btn btn-outline-secondary" type="button" id="btnBuscar">
                                        <img src="images/lupa.png" alt="Buscar" /></button>
                                </div>
                            </div>
                            <div class="col-6">
                                <div class="mb-3">
                                    <asp:CheckBox Text="Filtro Avanzado" ID="chkFiltroAvanzado" runat="server" AutoPostBack="true" CssClass="form-check" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" />
                                </div>
                            </div>
                        </div>
                        <%  if (chkFiltroAvanzado.Checked)
                            {%>

                        <div class="row">
                            <div class="col-3">
                                <div class="input-group mb-3">
                                    <asp:Label Text="Campo" runat="server" CssClass="input-group-text" />
                                    <asp:DropDownList runat="server" ID="ddlCampo" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                                        <asp:ListItem Text="Codigo" />
                                        <asp:ListItem Text="Nombre" />
                                        <asp:ListItem Text="Precio" />
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-3">
                                <div class="input-group mb-3">
                                    <asp:Label Text="Criterio" runat="server" CssClass="input-group-text" />
                                    <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-3">
                                <div class="input-group mb-3">
                                    <span class="input-group-text">Filtro</span>
                                    <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" aria-describedby="btnBuscar" AutoPostBack="true" OnTextChanged="txtFiltroAvanzado_TextChanged" />
                                    <button class="btn btn-outline-secondary" type="button" id="btnBuscarAvanzado">Buscar</></button>
                                </div>
                            </div>
                        </div>


                        <%} %>
                        <asp:GridView ID="dgvArticulos" runat="server" DataKeyNames="id" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Marca" DataField="Marca" />
                                <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                                <asp:BoundField HeaderText="Precio" DataField="Precio" />
                                <asp:CommandField HeaderText="Accion" ShowSelectButton="True" SelectText="✍️" />
                            </Columns>
                        </asp:GridView>
                        <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>

    </div>
</asp:Content>
