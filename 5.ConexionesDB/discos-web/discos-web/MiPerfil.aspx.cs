﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominioD;
using negocioD;
namespace discos_web
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                string ruta = Server.MapPath("./Images/");
                Usuario usuario = (Usuario)Session["usuario"];
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");

                usuario.ImagenPerfil = "perfil-" + usuario.Id + ".jpg";
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;

                negocio.actualizar(usuario);

                Image img = (Image)Master.FindControl("imgAvatar");
                
                img.ImageUrl = "~/Images/" + usuario.ImagenPerfil;
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }
        }
    }
}