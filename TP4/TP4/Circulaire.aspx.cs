using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initialisation du titre de la page
            this.Title = "Circulaire";

            // Vérification de l'autorisation d'accès a la page
            if (Session["nom"] == null)
                Response.Redirect("Erreur.aspx");

            // Affichage du menu correspondant a la section invite
            Master.FindControl("menuMembre").Visible = false;
            Master.FindControl("menuInvite").Visible = true;
        }
    }
}