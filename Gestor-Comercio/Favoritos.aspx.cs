using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Dominio;


namespace Gestor_Comercio
{
    public partial class Favoritos : System.Web.UI.Page
    {
        List<Articulo> articuloFavLista { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.SesionActiva(Session["usuario"]))
            {
                Response.Redirect("Login.aspx");
                return;

            }

            FavoritoBusiness negocio = new FavoritoBusiness();
            try
            {
                if (!IsPostBack)
                {
                                       
                    Usuario usuario = (Usuario)Session["usuario"];

                    articuloFavLista = negocio.ListarFav(usuario.Id);

                    if (articuloFavLista != null && articuloFavLista.Count > 0)
                    {                       
                        repRepetidor.DataSource = articuloFavLista;
                        repRepetidor.DataBind();
                    }
                    else
                    {
                        lblMensaje.Visible = true;
                        lblMensaje.Text = "No tienes ningún artículo en favoritos.";
                    }
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnEliminarFavorito_Click(object sender, EventArgs e)
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
                negocio.QuitarFav(userId, int.Parse(articuloId));
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }

    //protected string CargarImagen(string imagen)
    //{
    //    try
    //    {

    //        if (!string.IsNullOrEmpty(imagen) && imagen.ToUpper().StartsWith("HTTP"))
    //        {
    //            return imagen;
    //        }

    //        else if (!string.IsNullOrEmpty(imagen))
    //        {
    //            string rutaServidor = Server.MapPath(imagen);

    //            if (File.Exists(rutaServidor))
    //            {

    //                string rutaRelativa = imagen.Replace("~", "");
    //                return rutaRelativa;
    //            }
    //        }
    //        return "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png";

    //    }
    //    catch (Exception)
    //    {
    //        return "https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png";
    //    }
    //}
}