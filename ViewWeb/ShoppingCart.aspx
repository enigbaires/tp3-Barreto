﻿<%@ Page Title=" - Shopping Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="ViewWeb.ShoppingCart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table">
        <thead class="thead-dark">
            <tr>
                <th scope="col">Name</th>
                <th scope="col">Image</th>
                <th scope="col">Qty</th>
                <th scope="col">Unit</th>
                <th scope="col">Sub</th>
            </tr>
        </thead>
        <tbody>

            <%%>
            <%foreach (var item in shoppingCartList)
                {%>
            <tr>
                <th scope="row"><% = item.nombre%> </th>
                <td>
                    <img src="<% = item.imagen %>" style="max-width: 100px" alt="..."></td>
                <td>

                    <div class="input-group">
                        <input type="text" class="form-control" placeholder="<% = item.cantidad %>">
                        <div class="input-group-append" id="button-addon4">
                            <a class="btn btn-outline-secondary" href="OpMat?id=<% = item.id.ToString()%>&op=minus">-</a>
                            <a class="btn btn-outline-secondary" href="OpMat?id=<% = item.id.ToString()%>&op=plus">+</a>
                        </div>
                    </div>

                </td>
                <td>$ <% = item.precioUnitario %></td>
                <td>$ <% = (item.cantidad * item.precioUnitario) %></td>
            </tr>
            <%}%>
            <tr>
                <td></td>
                <td></td>
                <td></td>
                <th scope="row">Total: </th>
                <th scope="row">$ <asp:Label ID="lblTotal" runat="server"></asp:Label></th>
            </tr>
        </tbody>
    </table>
</asp:Content>
