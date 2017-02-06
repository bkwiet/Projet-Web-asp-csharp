<%@ Page Title="" Language="C#" MasterPageFile="~/CorpsDuSite.Master" AutoEventWireup="true" CodeBehind="Ajout.aspx.cs" Inherits="TP4.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ajout de DVD</h2>
    
    <form id="formAjoutDvd" method="post" enctype="multipart/form-data" runat="server">

        <div class="elemForm">
                <asp:Label ID="lblTitreDvd" runat="server" Text="Titre du DVD: " 
                    AssociatedControlID="txtBoxTitreDvd"></asp:Label>
                <asp:TextBox ID="txtBoxTitreDvd" MaxLength="255" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1" runat="server"  
                    ErrorMessage="RequiredFieldValidator" ControlToValidate="txtBoxTitreDvd" Display="Dynamic"
                    CssClass="message_erreur">Entree un titre pour le dvd</asp:RequiredFieldValidator>
	    </div>
	
	    <div class="elemForm">
		    <asp:Label ID="lblPrixDvd" runat="server" Text="Prix du DVD: " 
                AssociatedControlID="txtBoxPrixDvd"></asp:Label>
            <asp:TextBox ID="txtBoxPrixDvd" runat="server" ></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="RequiredFieldValidator" ControlToValidate="txtBoxPrixDvd" 
                CssClass="message_erreur">Entree un prix</asp:RequiredFieldValidator>

             <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1" runat="server" 
                ErrorMessage="RegularExpressionValidator" ControlToValidate="txtBoxPrixDvd" 
                CssClass="message_erreur" Display="Dynamic" ValidationExpression="^\d+$">
                Entree un nombre entier</asp:RegularExpressionValidator>
	    </div>
	
	    <div id="sectionFichier" class="elemForm">
		    <asp:Label ID="lblFichier" runat="server" Text="Image du DVD à transférer sur le serveur Web (taille maximale = 20 Ko):" 
            AssociatedControlID="ctrlFichier"></asp:Label>
            <asp:FileUpload ID="ctrlFichier" size="50" runat="server" />
	    </div>

	    <div class="elemForm">
            <asp:Button ID="btnSoumettre" runat="server" 
                Text="Ajouter le DVD" CssClass="btn" onclick="btnSoumettre_Click" />
	    </div>
    </form>

    <p><!-- messages d'erreur ou de réussite -->
        <asp:Label ID="msgInfos" runat="server" Text=""></asp:Label>
    </p>

    <asp:SqlDataSource ID="dataDVD" runat="server"
    ConnectionString="<%$ ConnectionStrings:ConnexionBD %>" 
    ProviderName="<%$ ConnectionStrings:ConnexionBD.ProviderName %>" 
    SelectCommand="SELECT * FROM [DVD]"></asp:SqlDataSource>
</asp:Content>
