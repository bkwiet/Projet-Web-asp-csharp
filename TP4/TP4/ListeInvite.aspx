<%@ Page Title="" Language="C#" MasterPageFile="~/CorpsDuSite.Master" AutoEventWireup="true" CodeBehind="ListeInvite.aspx.cs" Inherits="TP4.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Liste des DVD</h2>

    <asp:Table ID="TableDvd" runat="server">
        <asp:TableHeaderRow>
            <asp:TableCell CssClass ="tabHeader">Nom</asp:TableCell>
            <asp:TableCell CssClass ="tabHeader">Cover</asp:TableCell>
            <asp:TableCell CssClass ="tabHeader">Titre</asp:TableCell>
            <asp:TableCell CssClass ="tabHeader">Prix</asp:TableCell>
        </asp:TableHeaderRow>
    </asp:Table>

    <asp:SqlDataSource ID="dataListeDvd" runat="server"
    ConnectionString="<%$ ConnectionStrings:ConnexionBD %>" 
    ProviderName="<%$ ConnectionStrings:ConnexionBD.ProviderName %>" 
    SelectCommand="SELECT * FROM [DVD] ORDER BY id DESC"></asp:SqlDataSource>
  
    <asp:Label ID="msgErreur" runat="server" Text=""></asp:Label>
</asp:Content>
