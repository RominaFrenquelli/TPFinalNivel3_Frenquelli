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
        public List<Articulo> articuloLista { get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloBusiness negocio = new ArticuloBusiness();
            articuloLista = negocio.Listar();

            if (!IsPostBack)
            {
                reprepetidor.DataSource = articuloLista;
                reprepetidor.DataBind();
            }
        }

        public string CargarImagen(string imagenUrl)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagenUrl) &&
            (imagenUrl.ToUpper().Contains("HTTPS") /*|| File.Exists(Server.MapPath(imagenUrl))*/))
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


    }
}