<%@ Page Title="" Language="C#" MasterPageFile="~/CorpsDuSite.Master" AutoEventWireup="true" CodeBehind="Liste.aspx.cs" Inherits="TP4.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Liste des DVD</h2>
    <form id="formListeDvd" runat="server">
        <div id="BoutonsAjout">
            <asp:Button ID="ButtonAjoutDvd" runat="server" Text="Ajouter un DVD " 
                onclick="ButtonAjoutDvd_Click" />
        </div>

        <asp:Table ID="TableDvd" runat="server">
            <asp:TableHeaderRow>
                <asp:TableCell CssClass ="tabHeader">Nom</asp:TableCell>
                <asp:TableCell CssClass ="tabHeader">Cover</asp:TableCell>
                <asp:TableCell CssClass ="tabHeader">Titre</asp:TableCell>
                <asp:TableCell CssClass ="tabHeader">Prix</asp:TableCell>
                <asp:TableCell CssClass ="tabHeader">Acheter</asp:TableCell>
                <asp:TableCell CssClass ="tabHeader">Supprimer</asp:TableCell>
            </asp:TableHeaderRow>
        </asp:Table>

        <asp:SqlDataSource ID="dataListeDvd" runat="server"
        ConnectionString="<%$ ConnectionStrings:ConnexionBD %>" 
        ProviderName="<%$ ConnectionStrings:ConnexionBD.ProviderName %>" 
        SelectCommand="SELECT * FROM [DVD] ORDER BY id DESC"></asp:SqlDataSource>
  
        <asp:Label ID="msgErreur" runat="server" Text=""></asp:Label>
    </form>
</asp:Content>
