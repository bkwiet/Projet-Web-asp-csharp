using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Collections.Generic;
namespace TP4
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initialisation du titre de la page
            this.Title = "Inscription";

            // Vérification de l'autorisation d'accès a la page
            if (Session["nom"] == null)
                Response.Redirect("Erreur.aspx");

            // Affichage du menu correspondant a la section invite
            Master.FindControl("menuMembre").Visible = false;
            Master.FindControl("menuInvite").Visible = true;

        }

        protected void ButtonSoumettre_Click(object sender, EventArgs e)
        {

            // On enlève les blancs inutiles dans les champs du formulaire.
            this.txtUsagerLogin.Text = this.txtUsagerLogin.Text.Trim();
            this.txtMotPasseUsager.Text = this.txtMotPasseUsager.Text.Trim();
            this.txtMotDePasseConfir.Text = this.txtMotDePasseConfir.Text.Trim();
            this.txtPrenomUsager.Text = this.txtPrenomUsager.Text.Trim();
            this.txtNomUsager.Text = this.txtNomUsager.Text.Trim();

            if (this.IsValid)
            {

                // Parametre de connexion
                string paramConnexion = ConfigurationManager.ConnectionStrings["ConnexionBD"].ConnectionString;
                // Objet connexion
                OleDbConnection connexion = new OleDbConnection(paramConnexion);
                // Objet permettant l'execution de requete sql
                OleDbCommand commandeSQL = connexion.CreateCommand();

                try
                {

                    connexion.Open();

                    //Commande SQL
                    commandeSQL.CommandText = "INSERT INTO Usagers VALUES ('" +
                            this.txtUsagerLogin.Text + "', '" +
                            this.txtMotPasseUsager.Text + "', 'm', '" +
                            this.txtPrenomUsager.Text + "', '" +
                            this.txtNomUsager.Text + "'" +
                            ")";

                    int count = commandeSQL.ExecuteNonQuery();

                    if (count >= 1)
                    {
                        this.formAjoutMembre.Visible = false;
                        this.msgInfos.Text = "Votre inscription a ete effectue avec succes. vous pouvez dès maintenant vous logguer" +
                            " en tant que membre ";
                    }
                    else
                    {
                        this.msgInfos.Text = "Votre inscription a echoue";
                    } 
                }
                catch (Exception ex)
                {
                    this.msgInfos.Text = "Erreur de connexion ! " + ex.Message;
                }
                finally
                {
                    commandeSQL.Dispose();
                    connexion.Close();
                }
            }
        }
    }
}