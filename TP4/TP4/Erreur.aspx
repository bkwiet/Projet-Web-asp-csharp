<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Erreur.aspx.cs" Inherits="TP4.WebForm6" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
	<title>Erreur</title>
	<link rel="stylesheet" href="css/styles.css" media="all" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="page">
        <h2>Erreur</h2>

        <div id="imgCent">
            <img src="images/erreur.png" alt="erreur" />
        </div>
               
        <p>Vous n'êtes pas autorisé à accéder à cette page.</p>
        <p>Veuillez vous identifier sur la page de connexion si vous possédez un accès membre, ou vous identifier
        en tant qu'invités, si vous voulez accéder aux pages réservées aux membres vous pouvez vous inscrire dans la section
        réservée aux invités.
        </p>
        <p><a href="Connexion.aspx">Retour à la page de connexion</a></p>
    </div>
    </form>
</body>
</html>
