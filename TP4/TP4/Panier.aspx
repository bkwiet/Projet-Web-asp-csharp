<%@ Page Title="" Language="C#" MasterPageFile="~/CorpsDuSite.Master" AutoEventWireup="true" CodeBehind="Panier.aspx.cs" Inherits="TP4.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Panier d'achats</h2>
    
    <asp:Table ID="TableDvd" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass ="tabHeader">Supprimer</asp:TableCell>
            <asp:TableCell CssClass ="tabHeader">Titre</asp:TableCell>
            <asp:TableCell CssClass ="tabHeader">Cover</asp:TableCell>            
            <asp:TableCell CssClass ="tabHeader">Prix</asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <asp:SqlDataSource ID="dataListeAchats" runat="server"
    ConnectionString="<%$ ConnectionStrings:ConnexionBD %>" 
    ProviderName="<%$ ConnectionStrings:ConnexionBD.ProviderName %>">
    </asp:SqlDataSource>
    <div id="boutonCommande">
        <a href="Commande.aspx"><img src="images/commande.png" alt="commande" /></a>
    </div>
    <asp:Label ID="msgErreur" runat="server" Text=""></asp:Label>
</asp:Content>
