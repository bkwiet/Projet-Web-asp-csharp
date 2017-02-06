<%@ Page Title="" Language="C#" MasterPageFile="~/CorpsDuSite.Master" AutoEventWireup="true" CodeBehind="AccueilMembre.aspx.cs" Inherits="TP4.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Accueil membre</h2>
     <p>Bonjour et bienvenue sur notre site web. Ici vous allez trouver toutes vos
     téléseries préfereés. En partant vous vous trouvez dans la page d'accueil, dans
     le ménu supérieur vous trouverez certains liens qui vous seront utiles à trouver
     la téléserie que vous désirez, voici une description qui vous sera utile pour
     ammeliorer la qualité et rapidité de vos recherches.</p>

     <p><a class="textDescritionMenu" href="Liste.aspx">Liste des DVD</a>: Ici vous allez trouver la liste
      des téléseries avec, une image cover, le titre, la saison et le prix. Cette
      information vous permettra d'ajouter la téléserie désirée à votre panier.</p>

     <p><a class="textDescritionMenu" href="Rabais.aspx">Rabais</a>: Cette lien est en contruction présentement.</p>

     <p><a class="textDescritionMenu" href="AccueilInvite.aspx">Section invités</a>: Cette lien vous permettra d'accèder
      à la section d'invités</p>

</asp:Content>
