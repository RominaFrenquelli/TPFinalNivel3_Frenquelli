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
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            ConfirmaEliminacion = false;

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

                string id = Request.QueryString["Id"] != null ? Request.QueryString["Id"].ToString() : "";
                if(id != "" && !IsPostBack)
                {
                    ArticuloBusiness negocio = new ArticuloBusiness();  
                    Articulo seleccionado = (negocio.Listar(id))[0];

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    txtPrecio.Text = seleccionado.Precio.ToString();
                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();
                    ddlmarca.SelectedValue = seleccionado.Marca.Id.ToString();
                    CargarImagen(seleccionado.ImagenUrl);

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
                Session.Add("error", ex);

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
                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.ImagenUrl = txtImagenUrl.Text;

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlmarca.SelectedValue);

                if (Request.QueryString["Id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["Id"].ToString());
                    negocio.Modificar(nuevo);
                }
                else
                    negocio.Agregar(nuevo);

                Response.Redirect("ListaArticulos.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (chkConfirmaEliminar.Checked)
                {
                    ArticuloBusiness negocio = new ArticuloBusiness();               
                    negocio.EliminarFisico(int.Parse(txtId.Text));
                    Response.Redirect("ListaArticulos.aspx");
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }
    }
}