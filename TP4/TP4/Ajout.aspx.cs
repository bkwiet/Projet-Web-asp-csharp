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
using System.IO;

namespace TP4
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // initialisation du titre de la page
            this.Title = "Ajout de DVD";

            // Vérification de l'autorisation d'accès a la page
            if (Session["nom"] == null || Session["type"].ToString() != "m")
                Response.Redirect("Erreur.aspx");

            // Affichage du menu correspondant a la section membre
            Master.FindControl("menuInvite").Visible = false;
            Master.FindControl("menuMembre").Visible = true;
        }

        protected void btnSoumettre_Click(object sender, EventArgs e)
        {
            // On efface les mesages si il yen a eu.
            this.msgInfos.Text = "";
            

            // Verification de l'image transmise         

            this.txtBoxTitreDvd.Text = this.txtBoxTitreDvd.Text.Trim();
            this.txtBoxPrixDvd.Text = this.txtBoxPrixDvd.Text.Trim();
            string nomImage;

            if(Page.IsValid)
            {
                 // On récupère le fichier.
                HttpPostedFile fichier = this.ctrlFichier.PostedFile;
                
                // verification de l'existence du fichier
                if (fichier == null || fichier.ContentLength == 0)
                {
                    nomImage = "nondisponible.jpg";
                }
                else
                {
                    // Récupération du nom du fichier
                    nomImage = Path.GetFileName(fichier.FileName);

                    // Création du chemin d'accès absolu au dossier de destination des images de DVD
                    string cheminTransfert = Server.MapPath("images/imagesDVD/");

                    // Verification de la taille du fichier
                    if (fichier.ContentLength > (20 * 1024))
                    {
                        nomImage = "nondisponible.jpg";
                    }
                    else if(!(File.Exists(cheminTransfert + nomImage)))
                        fichier.SaveAs(cheminTransfert + nomImage);
                }

                // Creation connexion a la bd
                OleDbConnection connexionBD = new OleDbConnection(this.dataDVD.ConnectionString);
                try
                {
                    // Ouverture de la BD
                    connexionBD.Open();

                    // Ajout de l'enregistremnet a la BD
                    InsererDVD(connexionBD, nomImage);
                }
                catch (Exception ex)
                {
                    this.msgInfos.Text = "Erreur de connexion ! " + ex.Message;
                }
                finally
                {
                    connexionBD.Close();
                }
                
            }
            

        }

        private void InsererDVD(OleDbConnection connexionBD, string nomImage)
        {
            // Requete sql d'ajout
            string requeteAjoutDvd = "INSERT INTO DVD "
                                    +"(UsagerLogin, DVDTitre,DVDPrix,DVDPhoto)"
                                    + "VALUES (@loginUsager, @titreDVD, @prixDVD, @photoDVD)";

            OleDbCommand ajoutDvd = new OleDbCommand(requeteAjoutDvd, connexionBD);

            ajoutDvd.Parameters.Add("@loginUsager", OleDbType.VarChar, 12).Value = Session["identifiant"].ToString();
            ajoutDvd.Parameters.Add("@titreDVD", OleDbType.VarChar, 255).Value = this.txtBoxTitreDvd.Text;
            ajoutDvd.Parameters.Add("@prixDVD", OleDbType.Integer).Value = Convert.ToInt32(this.txtBoxPrixDvd.Text);
            if(nomImage != "")
                ajoutDvd.Parameters.Add("@photoDVD", OleDbType.VarChar, 50).Value = nomImage;

            try
            {
                int count = ajoutDvd.ExecuteNonQuery();

                if (count >= 1)
                {
                    this.txtBoxPrixDvd.Text = "";
                    this.txtBoxTitreDvd.Text = "";
                    this.msgInfos.Text = "\n<p>Le DVD a été ajouté avec succès.</p>";
                    this.formAjoutDvd.Visible = false;
                }
                else
                {
                    this.msgInfos.Text = "\n<p>L'ajout du DVD a échoué.</p>";
                }
            }
            catch (OleDbException ex)
            {
                this.msgInfos.Text = ex.Message;
            }


        }
    }
}