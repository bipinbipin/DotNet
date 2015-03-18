<%@ Page Title="" Theme="Main" Language="C#" MasterPageFile="~/MasterPages/Site2Column.Master" AutoEventWireup="true" CodeBehind="Email.aspx.cs" Inherits="AstonTech.AstonEngineer.Web.EmployeeSection.Email" %>
<%@ Register TagPrefix="CustomAstonEngineer" TagName="EmployeeNavigation" Src="~/UserControls/EmployeeNavigationControl.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <CustomAstonEngineer:EmployeeNavigation runat="server" ID="CustomEmployeeNavigation" />
    hello world from the email page
</asp:Content>
