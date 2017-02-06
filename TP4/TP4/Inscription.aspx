<%@ Page Title="" Language="C#" MasterPageFile="~/CorpsDuSite.Master" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="TP4.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Inscription</h2>

    <form id="formAjoutMembre" method="post" runat="server" >
		    <div>
                <asp:Label ID="lblPrenomUsager" runat="server" Text="Prénom : " 
                    AssociatedControlID="txtPrenomUsager"></asp:Label>
                <asp:TextBox ID="txtPrenomUsager" MaxLength="50" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtPrenomUsager" CssClass="message_erreur" 
                ErrorMessage="Vous devez entrer un prenom">*</asp:RequiredFieldValidator>
		    </div>

		    <div>
                <asp:Label ID="lblNomUsager" runat="server" Text="Nom : " 
                    AssociatedControlID="txtNomUsager"></asp:Label>
                <asp:TextBox ID="txtNomUsager" MaxLength="50" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtNomUsager" CssClass="message_erreur" 
                ErrorMessage="Vous devez entrer un nom">*</asp:RequiredFieldValidator>
		    </div>

            <div>
                 <asp:Label ID="lblUsagerLogin" runat="server" Text="Login : " 
                    AssociatedControlID="txtUsagerLogin"></asp:Label>
                <asp:TextBox ID="txtUsagerLogin" MaxLength="12" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNom" runat="server" 
                ControlToValidate="txtUsagerLogin" CssClass="message_erreur" 
                ErrorMessage="Vous devez entrer un login">*</asp:RequiredFieldValidator>
		    </div>

            <div>
                <asp:Label ID="lblMotDePasse" runat="server" Text="Mot de passe : " 
                    AssociatedControlID="txtMotPasseUsager"></asp:Label>
                <asp:TextBox ID="txtMotPasseUsager" MaxLength="12" runat="server" TextMode="Password"></asp:TextBox>
		    </div>
            <asp:CompareValidator ID="CompareValidatorMotPasse" runat="server" 
            ControlToCompare="txtMotDePasseConfir" ControlToValidate="txtMotPasseUsager" 
            CssClass="message_erreur" Display="Dynamic" 
            ErrorMessage="Les mots de passe entrés doivent être pareils">*</asp:CompareValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMotPasse" runat="server" 
            ControlToValidate="txtMotPasseUsager" CssClass="message_erreur" 
            Display="Dynamic" ErrorMessage="Le mot de passe est obligatoire">*</asp:RequiredFieldValidator>
            <div>
                <asp:Label ID="lblMotDePasseConf" runat="server" Text="Confirmer votre : " 
                    AssociatedControlID="txtMotDePasseConfir"></asp:Label>
                <asp:TextBox ID="txtMotDePasseConfir" MaxLength="12" runat="server" TextMode="Password"></asp:TextBox>
		    </div>

		    <div>
                <asp:Button ID="ButtonSoumettre" runat="server" Text="S'inscrire" 
                    onclick="ButtonSoumettre_Click" />
		    </div>
        </form>
        <p><!-- messages d'erreur ou de réussite -->
        <asp:Label ID="msgInfos" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>
