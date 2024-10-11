using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Dominio;

namespace Gestor_Comercio
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloBusiness negocio = new ArticuloBusiness();
            try
            {
                string id = Request.QueryString["Id"].ToString();
                Articulo seleccionado = (negocio.Listar(id)[0]);

                lblCategoria.Text = seleccionado.Categoria.ToString();
                lblNombre.Text = seleccionado.Nombre.ToString();
                lblCodigo.Text = seleccionado.Codigo.ToString();
                lblMarca.Text = seleccionado.Marca.ToString();
                lblPrecio.Text = seleccionado.Precio.ToString();
                imgArticulo.ImageUrl = seleccionado.ImagenUrl;
                lblDescripcion.Text = seleccionado.Descripcion.ToString();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }
    }
}