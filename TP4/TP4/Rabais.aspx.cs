using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initialisation du titre de la page
            this.Title = "Rabais DVD";

            // Vérification de l'autorisation d'accès a la page
            if (Session["nom"] == null || Session["type"].ToString() != "m")
                Response.Redirect("Erreur.aspx");

            // Affichage du menu correspondant a la section membre
            Master.FindControl("menuInvite").Visible = false;
            Master.FindControl("menuMembre").Visible = true;
        }
    }
}