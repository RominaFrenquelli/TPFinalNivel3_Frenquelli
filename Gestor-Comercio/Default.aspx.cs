using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Business;
using System.Net;

namespace Gestor_Comercio
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> articuloLista { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloBusiness negocio = new ArticuloBusiness();
            CategoriaBusiness negocioCategoria = new CategoriaBusiness();

            try
            {
                if (!IsPostBack)
                {
                    articuloLista = negocio.Listar();
                    Session["articuloLista"] = articuloLista;

                    //Session.Add("articuloLista", negocio.Listar());


                    List<Categoria> listaCategorias = negocioCategoria.Listar();

                    ddlMenu.DataSource = listaCategorias;
                    ddlMenu.DataTextField = "Descripcion";
                    ddlMenu.DataValueField = "Id";
                    ddlMenu.DataBind();

                    repRepetidor.DataSource = Session["articuloLista"];
                    repRepetidor.DataBind();
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
        }

        public string CargarImagen(string imagenUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagenUrl) && (imagenUrl.ToUpper().Contains("HTTPS") /*|| File.Exists(Server.MapPath(imagenUrl))*/))
                {
                    return imagenUrl;
                }
                else
                {
                    return "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png";
                }
            }
            catch
            {
                return "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png";
            }

        }

        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {


            List<Articulo> listadoFiltrado = (List<Articulo>)Session["articuloLista"]; ;
            string filtro = txtFiltrar.Text;
            List<Articulo> listaFiltrada;

            if (filtro.Length >= 2)
               listaFiltrada = listadoFiltrado.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            else
                listaFiltrada = listadoFiltrado;

            repRepetidor.DataSource = listaFiltrada;
            repRepetidor.DataBind();
            

        }

        protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

            int idCategoria = int.Parse(ddlMenu.SelectedItem.Value);
            List<Articulo> filtroCategoria = articuloLista;

            filtroCategoria = ((List<Articulo>)Session["articuloLista"]).FindAll(x => x.Categoria.Id == idCategoria);

            repRepetidor.DataSource = filtroCategoria;
            repRepetidor.DataBind();
            

        }

    }
}