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
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initialisation du titre de la page
            this.Title = "Liste des DVD";

            // Vérification de l'autorisation d'accès a la page
            if (Session["nom"] == null || Session["type"].ToString() != "m")
                Response.Redirect("Erreur.aspx");

            // Affichage du menu correspondant a la section membre
            Master.FindControl("menuInvite").Visible = false;
            Master.FindControl("menuMembre").Visible = true;

            // Remplissage de la liste des dvd
            RemplirTableauDvd();
        }

        private void RemplirTableauDvd()
        {
            // Objet de connexion a la BD
            OleDbConnection connexionBD = new OleDbConnection
            (this.dataListeDvd.ConnectionString);
            // Objet permettant l'execution de requete sql
            OleDbCommand commandeDvd = connexionBD.CreateCommand();
            // Objet permettant le parcours d'un ReccordSet
            OleDbDataReader lecteurBDDvd = null;

            try
            {
                //Ouverture de la connexion
                connexionBD.Open();

                //Requete sql recherche du login dans la BD
                commandeDvd.CommandText = this.dataListeDvd.SelectCommand;

                // Execution de la requete
                lecteurBDDvd = commandeDvd.ExecuteReader();

                // Variables pour la creation du tableau , Ligne et Colonne
                TableRow uneLigne;
                TableCell uneCellule;

                // Parcours des enregistrements
                while (lecteurBDDvd.Read())
                {
                    int idItem = Convert.ToInt32(lecteurBDDvd["id"]);
                    uneLigne = new TableRow();

                    // Creation du champ Nom membre
                    uneCellule = new TableCell();
                    uneCellule.Text = Convert.ToString(lecteurBDDvd["UsagerLogin"]);
                    uneLigne.Cells.Add(uneCellule);

                    // Creation du champ Photo Dvd
                    uneCellule = new TableCell();
                    string nomPhoto = Convert.ToString(lecteurBDDvd["DVDPhoto"]);
                    uneCellule.Text = "<img src='images/imagesDVD/" + nomPhoto + "' alt='photo dvd'/>";
                    uneLigne.Cells.Add(uneCellule);

                    // Creation du champ Titre Dvd
                    uneCellule = new TableCell();
                    uneCellule.Text = Convert.ToString(lecteurBDDvd["DVDTitre"]);
                    uneLigne.Cells.Add(uneCellule);

                    // Creation du champ Prix Dvd
                    uneCellule = new TableCell();
                    uneCellule.Text = Convert.ToString(lecteurBDDvd["DVDPrix"]) + " $";
                    uneLigne.Cells.Add(uneCellule);

                    // Creation du champ Acheter
                    uneCellule = new TableCell();
                    if (TrouverItem(idItem))
                        uneCellule.Text = "item ajouté";
                    else
                        uneCellule.Text = "<a href='AjoutAchats.aspx?idAchats="+idItem+"'>"+
                            "<img src='images/petitpanier.png' alt='panier'/></a>";
                    uneLigne.Cells.Add(uneCellule);

                    if (Convert.ToString(lecteurBDDvd["UsagerLogin"]) == 
                        Session["identifiant"].ToString())
                    {
                        // Creation du champ Supprimer
                        uneCellule = new TableCell();
                        uneCellule.Text = "<a href='#'><img src='images/supprimerPetit.png' alt='supprimer'/></a>";
                        uneLigne.Cells.Add(uneCellule);
                    }
                   

                    // Ajout de la ligne au tableau
                    this.TableDvd.Rows.Add(uneLigne);

                }
            }
            catch (Exception ex)
            {
                this.msgErreur.Text = "Erreur de connexion ! " + ex.Message;
            }
            finally
            {
                // Fermeture du lecteur, de la commande et de la connection
                lecteurBDDvd.Close();
                commandeDvd.Dispose();
                connexionBD.Close();
            }
        }

        private bool TrouverItem( int idItem)
        {
            bool itemTrouve = false;

            if (Session["listeAchats"] != null)
            {
                var listeAchats = (List<int>)Session["listeAchats"];
                itemTrouve = listeAchats.Contains(idItem);
            }

            return itemTrouve;
        }

        protected void ButtonAjoutDvd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ajout.aspx");
        }
    }
}