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
    }
}