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
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initialisation du titre de la page
            this.Title = "Panier d'achats";

            // Vérification de l'autorisation d'accès a la page
            if (Session["nom"] == null || Session["type"].ToString() != "m")
                Response.Redirect("Erreur.aspx");

            // Affichage du menu correspondant a la section membre
            Master.FindControl("menuInvite").Visible = false;
            Master.FindControl("menuMembre").Visible = true;
            
            // Reamplir tableau d'achats
            if(Convert.ToInt32(Session["nbItem"]) !=0)
                RemplirTableauAchats();
        }

        protected string ListeAchats()
        {
            string lalisteAchats = "";

            foreach (int id in ((List<int>)Session["listeAchats"]))
            {
                lalisteAchats += id + ","; 
            }

            lalisteAchats = lalisteAchats.Remove(lalisteAchats.Length-1);

            return lalisteAchats;
        }

        protected void RemplirTableauAchats()
        {
            // Objet de connexion a la BD
            OleDbConnection connexionBD = new OleDbConnection
            (this.dataListeAchats.ConnectionString);
            // Objet permettant l'execution de requete sql
            OleDbCommand commandeAchats = connexionBD.CreateCommand();
            // Objet permettant le parcours d'un ReccordSet
            OleDbDataReader lecteurBDAchats = null;

            try
            {
                //Ouverture de la connexion
                connexionBD.Open();

                //Requete sql recherche du login dans la BD
                commandeAchats.CommandText = "SELECT * FROM DVD WHERE id in (" +
                   ListeAchats() + ") ORDER BY id DESC ";

                // Execution de la requete
                lecteurBDAchats = commandeAchats.ExecuteReader();

                // Variables pour la creation du tableau , Ligne et Colonne
                TableRow uneLigne;
                TableCell uneCellule;
                int totalAchats = 0;

                // Parcours des enregistrements
                while (lecteurBDAchats.Read())
                {
                    int idItem = Convert.ToInt32(lecteurBDAchats["id"]);
                    uneLigne = new TableRow();

                    // Creation du champ Supprimer
                    uneCellule = new TableCell();
                    uneCellule.Text = "<a href='SuppressionAchats.aspx?idAchats=" + idItem + "'>" +
                        "<img src='images/supprimerPetit.png' alt='supprimer'/></a>";
                    uneLigne.Cells.Add(uneCellule);

                    // Creation du champ Titre Dvd
                    uneCellule = new TableCell();
                    uneCellule.Text = Convert.ToString(lecteurBDAchats["DVDTitre"]);
                    uneLigne.Cells.Add(uneCellule);

                    // Creation du champ Photo Dvd
                    uneCellule = new TableCell();
                    string nomPhoto = Convert.ToString(lecteurBDAchats["DVDPhoto"]);
                    uneCellule.Text = "<img src='images/imagesDVD/" + nomPhoto + "' alt='photo dvd'/>";
                    uneLigne.Cells.Add(uneCellule);

                    // Creation du champ Prix Dvd
                    uneCellule = new TableCell();
                    uneCellule.Text = Convert.ToString(lecteurBDAchats["DVDPrix"]) + " $";
                    uneLigne.Cells.Add(uneCellule);

                    totalAchats += Convert.ToInt32(lecteurBDAchats["DVDPrix"]);

                    // Ajout de la ligne au tableau
                    this.TableDvd.Rows.Add(uneLigne);

                }
                
                // Ligne total achats
                uneLigne = new TableRow();
                uneCellule = new TableCell();
                uneLigne.Cells.Add(uneCellule);
                uneCellule = new TableCell();
                uneLigne.Cells.Add(uneCellule);
                uneCellule = new TableCell();
                uneCellule.CssClass = "montant";
                uneCellule.Text = "Montant total de votre commande :";
                uneLigne.Cells.Add(uneCellule);
                uneCellule = new TableCell();
                uneCellule.CssClass = "montant";
                uneCellule.Text = totalAchats + " $";
                uneLigne.Cells.Add(uneCellule);
                // Ajout de la ligne au tableau
                this.TableDvd.Rows.Add(uneLigne);

                
            }
            catch (Exception ex)
            {
                this.msgErreur.Text = "Erreur de connexion ! " + ex.Message;
            }
            finally
            {
                // Fermeture du lecteur, de la commande et de la connection
                lecteurBDAchats.Close();
                commandeAchats.Dispose();
                connexionBD.Close();
            }
        }
    }
}