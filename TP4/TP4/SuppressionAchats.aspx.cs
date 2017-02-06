using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP4
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Vérification de l'autorisation d'accès a la page
            if (Session["nom"] == null || Session["type"].ToString() != "m")
                Response.Redirect("Erreur.aspx");

            if (Request.QueryString["idAchats"] != null)
            {
                ((List<int>)Session["listeAchats"]).Remove(Convert.ToInt32(Request.QueryString["idAchats"]));

                Session["nbItem"] = Convert.ToInt32(Session["nbItem"]) - 1;

                Response.Redirect("Panier.aspx");
            }
            else
                Response.Redirect("Panier.aspx");
        }
    }
}