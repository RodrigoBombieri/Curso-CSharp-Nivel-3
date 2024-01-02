﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace ejemploDeGrilla
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// Preguntamos si la lista de autos esta vacia y si esta vacia la cargamos
            if (Session["listaAutos"] == null)
            {
                /// Devuelve una lista de autos
                AutoNegocio negocio = new AutoNegocio();
                /// Guardamos la lista en sesion para que no se pierda y SE PUEDA SEGUIR USANDO
                /// en otros formularios, sino la lista se pierde cuando se cierra el formulario
                Session.Add("listaAutos", negocio.listar());            
            }

            /// Con el datasource se le asigna la lista de autos al datagridview
            /// Cargamos la grilla desde la lista que tenemos en sesion
            dgvAutos.DataSource = Session["listaAutos"];
            /// Con el databind se le asigna el datasource al datagridview y arma la grilla
            dgvAutos.DataBind();
        }

        protected void dgvAutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            /// cuando se presiona el elemento "Seleccionar" de la grilla se ejecuta este evento
            
            /// Capturamos el id del elemento seleccionado
            var id = dgvAutos.SelectedDataKey.Value.ToString();
            /// Redireccionamos a la pagina de AutoForm.aspx con el id del elemento seleccionado
            /// para poder usar ese id en el formulario de AutoForm.aspx
            Response.Redirect("AutoForm.aspx?id=" + id);
        }
    }
}