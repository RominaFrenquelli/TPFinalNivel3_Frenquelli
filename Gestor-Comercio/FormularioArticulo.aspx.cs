using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Business;

namespace Gestor_Comercio
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaBusiness marcaNegocio = new MarcaBusiness();
            CategoriaBusiness categoriaNegocio = new CategoriaBusiness();
            try
            {
                if (!IsPostBack)
                {
                    ddlmarca.DataSource = marcaNegocio.Listar();
                    ddlmarca.DataValueField = "Id";
                    ddlmarca.DataTextField = "Descripcion";
                    ddlmarca.DataBind();
                    ddlCategoria.DataSource = categoriaNegocio.Listar();
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();

                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                
            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            CargarImagen(txtImagenUrl.Text);
        }

        private void CargarImagen(string imagen)
        {
            try
            {
                if (imagen.ToUpper().Contains("HTTPS") /*|| File.Exists(imagen)*/)
                {

                    imgArticulo.ImageUrl = txtImagenUrl.Text;
                }
                else
                {

                    imagen = imgArticulo.ImageUrl;


                }
            }
            catch (Exception ex)
            {
                imagen = imgArticulo.ImageUrl;

            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloBusiness negocio = new ArticuloBusiness();

            try
            {
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.Precio = int.Parse(txtPrecio.Text);
                nuevo.ImagenUrl = txtImagenUrl.Text;

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlmarca.SelectedValue);

                negocio.Agregar(nuevo);

                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}