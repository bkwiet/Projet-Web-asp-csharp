using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

namespace TP4
{
    public partial class connexion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.Page.IsPostBack)
                if (this.Response.Cookies["identifiantTele"] != null)
                    this.TextBoxNomLogin.Text = this.Request.Cookies["identifiantTele"].Value;

            //this.radioCookieOui.Checked = true;
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Recuperation de l'identifiant et du mot de passe saisis
                string login = this.TextBoxNomLogin.Text.Trim();
                string motPass = this.TextBoxMotPasse.Text.Trim();

                // Validation du login
                bool validationLogin = VerificationLogin(login, motPass);

                if (validationLogin)
                {
                    //Redirection vers la page membre si l'authentification reussi
                    if(Session["type"].ToString() == "m")
                        Response.Redirect("AccueilMembre.aspx");
                    else
                        Response.Redirect("AccueilInvite.aspx");
                }
                else
                {
                    this.msgErreur.Text ="* Identifiant ou Mot de passe incorrecte";
                }               
            }
        }

        private void CreerCookie(string nomCookie ,string value , int expiration)
        {
            // Création d'un objet "Cookie".
            HttpCookie cookieIdentifiant = new HttpCookie(nomCookie, value);

            // Attribution d'une date d'expiration.
            DateTime dateExp = DateTime.Now;
            dateExp = dateExp.AddMonths(expiration);
            cookieIdentifiant.Expires = dateExp;

            // Ajout du cookie à l'en-tête HTTP.
            Response.AppendCookie(cookieIdentifiant);
        }


        private bool VerificationLogin(string login, string motPasse)
        {
            //Validite du login
            bool validationLogin = false;
            // Parametre de connexion
            string paramConnexion = ConfigurationManager.ConnectionStrings["ConnexionBD"].ConnectionString;
            // Objet de connexion a la BD
            OleDbConnection connexionBD = new OleDbConnection(paramConnexion);
            // Objet permettant l'execution de requete sql
            OleDbCommand commandeLogin = connexionBD.CreateCommand();
            // Objet permettant le parcours d'un ReccordSet
            OleDbDataReader lecteurBDLogin = null;

            try
            {
                //Ouverture de la connexion
                connexionBD.Open();

                //Requete sql recherche du login dans la BD
                commandeLogin.CommandText = "SELECT * FROM Usagers WHERE UsagerLogin = ? AND " + 
                " UsagerMotPasse = ? ";
                OleDbParameter pLogin = new OleDbParameter();
                OleDbParameter pMotpass = new OleDbParameter();
                commandeLogin.Parameters.Add(pLogin);
                commandeLogin.Parameters.Add(pMotpass);
                pLogin.Value = login;
                pMotpass.Value = motPasse;
                
                // Execution de la requete
                lecteurBDLogin = commandeLogin.ExecuteReader();

                if (lecteurBDLogin.Read())
                {
                    // Changement de l'etat de la validation
                    validationLogin = true;
                    // Creation des variables de session
                    Session["identifiant"] = login; 
                    Session["nom"] = Convert.ToString(lecteurBDLogin["UsagerNom"]);
                    Session["prenom"] = Convert.ToString(lecteurBDLogin["UsagerPrenom"]);
                    Session["type"] = Convert.ToString(lecteurBDLogin["UsagerType"]);
                    if (Session["type"].ToString() == "m")
                    {
                        List<int> listeAchats = new List<int>();
                        Session["listeAchats"] = listeAchats;
                        Session["nbItem"] = 0;
                    }

                    if (this.radioCookieOui.Checked)
                        CreerCookie("identifiantTele", login, 2);
                    else
                    {
                        if (this.Response.Cookies["identifiantTele"] != null)
                            CreerCookie("identifiantTele", login, (-1));
                    }
                }
                    
            }
            catch (Exception ex)
            {
                this.msgErreur.Text = "Erreur de connexion ! " + ex.Message;
            }
            finally
            {
                // Fermeture du lecteur, de la commande et de la connection
                lecteurBDLogin.Close();
                commandeLogin.Dispose();
                connexionBD.Close();
            }

            return validationLogin;

        }
        
    }
}