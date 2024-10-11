<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Gestor_Comercio.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <hr />
        <div class="row">
            <div class="col-9">
                <div class="card" style=" background-color: #e0e0e0; border-color: #0f2e66 /*#00a59d*/;">
                    <div class="card-header"  style="background-color: #0f2e66; color: white;">
                        <h2>Login</h2>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <label class="form-label">Email</label>
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtMail"/>
                            <asp:RegularExpressionValidator ErrorMessage="Debe completar con formato email" ControlToValidate="txtMail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" cssClass="validation-error"/>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Contraseña</label>
                            <asp:TextBox runat="server" cssClass="form-control" ID="txtPass" TextMode="Password"/>
                        </div>
                        <div class="mb-3">
                            <asp:Button Text="Ingresar" runat="server" ID="btnIngresar" cssClass="btn btn-primary me-4" OnClick="btnIngresar_Click"/>
                            <a href="/">Cancelar</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
