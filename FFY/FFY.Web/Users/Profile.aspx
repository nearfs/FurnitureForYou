﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="FFY.Web.Users.Profile" %>

<asp:Content ID="ProfileContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3><%# this.Model.User.FirstName %> <%# this.Model.User.LastName %></h3>
    <asp:Label ID="TestLbl" runat="server"></asp:Label>
    <asp:HyperLink NavigateUrl="~/Account/ManagePassword" Text="Change Password" Visible="false" ID="ChangePassword" runat="server" />
    <hr />
    <asp:GridView ID="OrderList" AutoGenerateColumns="false" 
        ItemType="FFY.Models.Order" 
        DataKeyNames="Id"  
        AllowPaging="true" 
        OnPageIndexChanging="OrderListPageIndexChanging" 
        PageSize="2"
        CssClass="table table-striped table-condensed table-bordered"
        runat="server">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id"/>
            <asp:BoundField DataField="User.Email" HeaderText="Email" />
            <asp:BoundField DataField="SendOn" HeaderText="Send on" />
            <asp:BoundField DataField="OrderStatusType" HeaderText="Status" />
            <asp:HyperLinkField Text="Details" 
                DataNavigateUrlFields="Id"
                DataNavigateUrlFormatString="~user/orders/{0}"/>
        </Columns>
    </asp:GridView>
</asp:Content>
