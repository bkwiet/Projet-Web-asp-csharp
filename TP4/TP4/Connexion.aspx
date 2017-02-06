<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Connexion.aspx.cs" Inherits="TP4.connexion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
	<title>Connexion</title>
	<link rel="stylesheet" href="css/styles.css" media="all" />
</head>
<body>
    <div id="page">

	<h1>Téléséries à voir!</h1>
	
	<div id="sectionCarrousel">
		
	</div>

	<div id="sectionFormConnexion">
	  <h3>Ouvrir une session:</h3>
	  
	  <form id="formConnexion" method="post" runat="server" >

		<div id="sectionLogin">
            <asp:Label ID="LabelNomLogin" runat="server" Text="Identifiant (login): " 
                AssociatedControlID="TextBoxNomLogin"></asp:Label>
            <asp:TextBox ID="TextBoxNomLogin" MaxLength="12" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLogin" runat="server" 
            ControlToValidate="TextBoxNomLogin" CssClass="message_erreur" 
            Display="Dynamic" ErrorMessage="Veuillez saisir votre login">*</asp:RequiredFieldValidator>
		</div>
		
		<div id="sectionMotPasse">
            <asp:Label ID="LabelMotPasse" runat="server" Text="Mot de passe: " 
                AssociatedControlID="TextBoxMotPasse"></asp:Label>

            <asp:TextBox ID="TextBoxMotPasse" TextMode="password" MaxLength="12" runat="server"></asp:TextBox>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMotPasse" runat="server" 
            ControlToValidate="TextBoxMotPasse" CssClass="message_erreur" 
            Display="Dynamic" ErrorMessage="Veuillez saisir votre mot de passe">*</asp:RequiredFieldValidator>
		</div>

        <div id="sectionErreurs">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
            CssClass="message_erreur" 
            HeaderText="Champ(s) manquant(s) pour l'ouverture de session:" />
            <asp:Label ID="msgErreur" runat="server" Text=""></asp:Label>
        </div>
      
		
		<div id="sectionCookie">
		
			<div>Voulez-vous enregistrer votre nom?</div>

           
			<asp:RadioButton GroupName="RadioCookie" ID="radioCookieOui" value="oui" runat="server" />
            <asp:Label ID="LabelRadioCookieOui" runat="server" Text="oui" 
                AssociatedControlID="radioCookieOui"></asp:Label>

            <asp:RadioButton GroupName="RadioCookie" ID="radioCookieNon" value="non" runat="server" />
            <asp:Label ID="LabelRadioCookieNon" runat="server" Text="non" 
                AssociatedControlID="radioCookieNon"></asp:Label>  
           

		</div>
      		
		<div id="sectionBoutons">
            <asp:Button ID="ButtonLogin" runat="server" Text="Connexion" 
                onclick="ButtonLogin_Click" />
		</div>
		
	  </form>
	</div>
	<div id="intro">
		Si vous n'êtes pas membre de notre coop, vous pouvez vous connecter 
		en entrant le nom <em>anonyme</em> et le mot de passe <em>pw</em>.
	</div>
	
	<div id="bande">
		<img src="images/DVD.png" alt="pubDVD" />
	</div>
  </div>
  <script type="text/javascript" src="js/carrousel.js"></script>
</body>
</html>
