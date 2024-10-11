using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Business;
using System.Net;
using System.IO;

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
                    ddlMenu.Items.Insert(0, new ListItem("-Seleccione una opción-", ""));


                    repRepetidor.DataSource = Session["articuloLista"];
                    repRepetidor.DataBind();
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected bool EsFavorito(string id)
        {
            return true;
        }

        protected string CargarImagen(string imagen)
        {
            try
            {

                if (!string.IsNullOrEmpty(imagen) && imagen.ToUpper().StartsWith("HTTP"))
                {
                    return imagen; 
                }
                
                else if (!string.IsNullOrEmpty(imagen))
                {
                    string rutaServidor = Server.MapPath(imagen);

                    if (File.Exists(rutaServidor))
                    {
                        
                        string rutaRelativa = imagen.Replace("~", "");
                        return rutaRelativa; 
                    }
                }
                    return "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png"; 

            }
            catch (Exception)
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

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            FavoritoBusiness negocio = new FavoritoBusiness();
            
            try
            {
                string articuloId = ((Button)sender).CommandArgument;
                int userId = 0;

                if (Seguridad.SesionActiva(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    userId = usuario.Id;
                }

                bool esFavorito = negocio.EsFavorito(articuloId, userId);

                if (esFavorito)
                {
                    // Si ya está en favoritos, quitar de favoritos
                    negocio.QuitarFav(userId, int.Parse(articuloId));
                }
                else
                {
                    // Si no está en favoritos, agregar a favoritos
                    negocio.AgregarFav(userId, int.Parse(articuloId));
                }
                
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

            
        }

        

        
    }
}