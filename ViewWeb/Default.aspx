<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ViewWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">

        <div class="row">

            <div class="sidebar-sticky">
                <ul class="nav flex-column">
                    <li class="nav-item">
                        <h3>Filter</h3>
                    </li>
                    <li class="nav-item">Code</li>
                    <li class="nav-item">
                        <asp:TextBox ID="tbCodigo" runat="server"></asp:TextBox>
                    </li>
                    <li class="nav-item">Name</li>
                    <li class="nav-item">
                        <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
                    </li>
                    <li class="nav-item">Description</li>
                    <li class="nav-item">
                        <asp:TextBox ID="tbDescripcion" runat="server"></asp:TextBox>
                    </li>
                    <li class="nav-item">Brand</li>
                    <li class="nav-item">
                        <asp:TextBox ID="tbMarca" runat="server"></asp:TextBox>
                    </li>
                    <li class="nav-item">Category</li>
                    <li class="nav-item">
                        <asp:TextBox ID="tbCategoria" runat="server"></asp:TextBox>
                    </li>
                    <li class="nav-item">Price</li>
                    <li class="nav-item">
                        <asp:TextBox ID="tbPrecio" runat="server"></asp:TextBox>
                    </li>
                    <li class="nav-item">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                    </li>
                </ul>
            </div>

            <main role="main" class="col-md-9 ml-sm-auto col-lg-10 px-4">
                <div class="card-deck">
                    <asp:Repeater runat="server" ID="repeater">
                        <ItemTemplate>
                            <div class="col-md-4 p-3">
                                <div class="card">
                                    <img src="<%#Eval("imagen") %>" class="card-img-top" alt="...">
                                    <div class="card-body">
                                        <h5 class="card-title"><%#Eval("nombre")%></h5>
                                        <p class="card-text"><%#Eval("descripcion")%></p>
                                    </div>
                                    <a class="btn btn-primary" href="ShoppingCart.aspx?id=<%#Eval("id")%>">Add to Cart</a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </main>
        </div>
    </div>
</asp:Content>
