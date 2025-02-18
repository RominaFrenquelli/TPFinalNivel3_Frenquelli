﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;
using Dominio;

namespace Gestor_Comercio
{
    public partial class ListaArticulos : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Seguridad.EsAdmin(Session["usuario"]))
                {
                    Session.Add("error", "Se requiere rol de administrador para ingresar a esta página");
                    Response.Redirect("Error.aspx", false);
                }
                
                if (!IsPostBack)
                {
                    ArticuloBusiness negocio = new ArticuloBusiness();
                    Session.Add("ListaArticulo", negocio.Listar());
                
                    dgvArticulos.DataSource = Session["ListaArticulo"];
                    dgvArticulos.DataBind();

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?Id=" + id);
        }

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkFiltroAvanzado.Checked;
            txtBuscar.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if(ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
                ddlCriterio.Items.Add("Igual a");                
            }
            else
            {
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
                ddlCriterio.Items.Add("Contiene");
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["ListaArticulo"];
            string filtro= txtBuscar.Text;
            List<Articulo> listaFiltro;

            if (filtro.Length > 2)
            {
                listaFiltro = lista.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) ||
                                            x.Codigo.ToUpper().Contains(filtro.ToUpper()) ||
                                            x.Marca.Descripcion.ToUpper().Contains(filtro.ToUpper()) ||
                                            x.Categoria.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
                listaFiltro = lista;

            dgvArticulos.DataSource = listaFiltro;
            dgvArticulos.DataBind();


        }

        protected void txtFiltroAvanzado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ArticuloBusiness negocio = new ArticuloBusiness();
                Session.Add("ListaFiltrada", negocio.Filtrar(ddlCampo.SelectedItem.ToString(),
                                                          ddlCriterio.SelectedItem.ToString(),
                                                          txtFiltroAvanzado.Text));

                dgvArticulos.DataSource = Session["ListaFiltrada"];
                dgvArticulos.DataBind();
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            ArticuloBusiness negocio = new ArticuloBusiness();
            try
            {
                txtBuscar.Text = "";
                ddlCriterio.Items.Clear();
                txtFiltroAvanzado.Text = "";

                dgvArticulos.DataSource = negocio.Listar();
                dgvArticulos.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }


        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (Session["ListaFiltrada"] != null)
                dgvArticulos.DataSource = Session["ListaFiltrada"];
            else
                dgvArticulos.DataSource = Session["ListaArticulo"];
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }
    }

    
}