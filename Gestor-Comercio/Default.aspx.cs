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
            MarcaBusiness negocioMarca = new MarcaBusiness();

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
                    ddlMenu.Items.Insert(0, new ListItem("-Seleccione una opción-", "-1"));

                    List<Marca> listaMarcas = negocioMarca.Listar();

                    ddlMarcas.DataSource = listaMarcas;
                    ddlMarcas.DataTextField = "Descripcion";
                    ddlMarcas.DataValueField= "Id";
                    ddlMarcas.DataBind();
                    ddlMarcas.Items.Insert(0, new ListItem("-Seleccione una opción-", "-1"));

                    repRepetidor.ItemDataBound += new RepeaterItemEventHandler(repRepetidor_ItemDataBound);
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

        //protected bool EsFavorito(string id)
        //{
        //    int userId = 0;

        //    if (Seguridad.SesionActiva(Session["usuario"]))
        //    {
        //        Usuario usuario = (Usuario)Session["usuario"];
        //        userId = usuario.Id;
        //    }

        //    FavoritoBusiness negocio = new FavoritoBusiness();
        //    return negocio.EsFavorito(id, userId);
        //}

        protected void repRepetidor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Obtener el ID del artículo
                string articuloId = DataBinder.Eval(e.Item.DataItem, "Id").ToString();

                // Obtener el ID del usuario si hay una sesión activa
                int userId = 0;
                if (Seguridad.SesionActiva(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    userId = usuario.Id;
                }

                // Verificar si es favorito
                FavoritoBusiness negocio = new FavoritoBusiness();
                bool esFavorito = negocio.EsFavorito(articuloId, userId);

                // Buscar el botón en el Repeater
                Button btnFavorito = (Button)e.Item.FindControl("btnFavorito");
                
                if (esFavorito)
                {
                    btnFavorito.CssClass = "btn btn-favorito favorito"; // Clase para artículo en favoritos
                }
                else
                {
                    btnFavorito.CssClass = "btn btn-favorito"; // Clase para artículo no favorito
                }
            }
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

            if(idCategoria != -1)
            {
                filtroCategoria = ((List<Articulo>)Session["articuloLista"]).FindAll(x => x.Categoria.Id == idCategoria);
            }
            else
            {
                filtroCategoria = (List<Articulo>)Session["articuloLista"];
            }
            

            repRepetidor.DataSource = filtroCategoria;
            repRepetidor.DataBind();
            

        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            FavoritoBusiness negocio = new FavoritoBusiness();
            string script = "";
            try
            {
                string articuloId = ((Button)sender).CommandArgument;
                int userId = 0;

                if (Seguridad.SesionActiva(Session["usuario"]))
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    userId = usuario.Id;
                }
                else
                {
                    Response.Redirect("Login.aspx", false);                    
                }

                bool esFavorito = negocio.EsFavorito(articuloId, userId);

                if (esFavorito)
                {
                    negocio.QuitarFav(userId, int.Parse(articuloId));
                    script = "document.getElementById('" + ((Button)sender).ClientID + "').classList.remove('favorito');";
                }
                else
                {
                    negocio.AgregarFav(userId, int.Parse(articuloId));
                    script = "document.getElementById('" + ((Button)sender).ClientID + "').classList.add('favorito');";
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "changeColor", script, true);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }            
        }

        protected void ddlMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMarcas = int.Parse(ddlMarcas.SelectedItem.Value);
            List<Articulo> filtroMarcas = articuloLista;

            if (idMarcas != -1)
            {
                filtroMarcas = ((List<Articulo>)Session["articuloLista"]).FindAll(x => x.Marca.Id == idMarcas);
            }
            else
            {
                filtroMarcas = (List<Articulo>)Session["articuloLista"];
            }


            repRepetidor.DataSource = filtroMarcas;
            repRepetidor.DataBind();

        }
    }
}