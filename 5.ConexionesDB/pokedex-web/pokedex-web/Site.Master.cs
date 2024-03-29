﻿using dominioP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocioP;

namespace pokedex_web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Cada vez que carga le pone por defecto la imagen de perfil vacia, hasta que se loguee
            imgAvatar.ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRlECQSBGh032SFnX3lkF4CbEx9PvZxbFFcFscHj5qp9DjnVnYaohiMOKuLKrdJiF-8sVM&usqp=CAU";
            /// Si la pagina no es login o registro y no hay un usuario logueado redirecciono a la pagina de login
            if (!(Page is Login || Page is Registro || Page is Default || Page is Error))
            {
                /// Si la sesion no esta activa redirecciono a la pagina de login
                if (!Seguridad.sesionActiva(Session["trainee"]))
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    /// Si la sesion esta activa, capturo el usuario logueado y lo muestro en el label
                    Trainee user = (Trainee)Session["trainee"];
                    lblUser.Text = user.Email;
                    /// Si no es nulo o vacio el campo imagenPerfil, le agrego la imagen al avatar
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            /// Cierro la session y redirecciono a la pagina de login
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}