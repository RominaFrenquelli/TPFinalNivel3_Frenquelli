<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Gestor_Comercio.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <hr />
        <h2>Mi perfil</h2>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"/>                  
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
                    <asp:RequiredFieldValidator CssClass="validation-error" ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control"/>
                </div>
                
            </div>
            <div class="col-md-4">
                <div class="mb-3">
                    <label class="form-label">Imagen de Perfil</label>
                    <input type="file" id="txtImagen" runat="server" class="form-control" onchange="previewImage(this)" />
                </div>
                <asp:Image ID="imgMiPerfil" ImageUrl="https://lh3.googleusercontent.com/proxy/GkA0vWBQJkDD03y_YXVNafhnw1A636nFZ-Etx52QXwPw97ss1FOTigMP6GdH5jReWgUdAV2WYvwtdxuRSw85Qzv7eRRbyzoRQfRk5HPUocJPWfb1HOhqInIcqlcIhsJKrHpm7g" runat="server" CssClass="img-ajustada2" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button Text="Guardar" CssClass="btn btn-primary me-4" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" />
                <a href="/">volver</a>
            </div>
        </div>
    </div>
</asp:Content>
