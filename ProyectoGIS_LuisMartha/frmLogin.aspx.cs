using ProyectoGIS_LuisMartha.Models;
using ProyectoGIS_LuisMartha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoGIS_LuisMartha.Views.Login
{
    public partial class frmLogin : System.Web.UI.Page
    {
        UsuarioRepository _objUsuarioC = new UsuarioRepository();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {

                var cod = _objUsuarioC.ObtenerId(txtCuenta.Text, txtContrasenia.Text).FirstOrDefault() ;
                //using (var db = new GeneralContext())
                //{
                //    var reg = db.Usuarios.Where(x => x.Cuenta == txtCuenta.Text &&
                //                x.Contrasenia == txtContrasenia.Text).FirstOrDefault();

                //}
                

                Session["ID"] = cod.Id;
                Session["Cuenta"] = cod.Cuenta;
                
                if (_objUsuarioC.Login(txtCuenta.Text, txtContrasenia.Text))
                {
                    Response.Redirect("infCOVIDs/Index");
                }
                else
                { 
                    Response.Redirect("../../frmLogin.aspx");
                    Session["ID"] = "";
                    lblError.Visible = true;
                }
            }
            catch (Exception)
            {
                lblError.Visible = true;
            }
           
        }
    }
}