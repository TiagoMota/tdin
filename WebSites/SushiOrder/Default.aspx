<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Welcome to SushiHouse</title>
</head>
<body>
    <h2>Available Sushi types:</h2>
    <p>Type 1 - 20€</p>
    <p>Type 2 - 30€</p>
    <p>Type 3 - 35€</p>
    
   
    <form id="newOrderForm" runat="server">
        <asp:Button ID="buttonOrder" runat="server" Text="New Order" OnClick="ShowOrderForm" />
        <asp:Panel ID="Panel1" runat="server">
            <asp:Label ID="nameLabel" Text="Name " runat="server"/>
            <asp:TextBox id="costumerName" runat="server"/>
            <br />
            <asp:Label ID="addressLabel" Text="Address " runat="server"/>
            <asp:TextBox id="costumerAddress" runat="server"/>
            <br />
            <asp:Label ID="ccLabel" Text="Credit Card Number " runat="server"/>
            <asp:TextBox id="costumerCC" runat="server"/>
            <br />
            <asp:Label ID="numeroPedidos" Text="Numero de pedidos " runat="server"/>
            <asp:TextBox id="pedidos" runat="server"/>
            <br />
            <asp:Button ID="buttonPedidos" runat="server" Text="Next" OnClick="buttonPedidos_Click" />
            <asp:Panel ID="ordersPanel" runat="server" Visible="False">
                   
            </asp:Panel>
            <br />
            <asp:Button ID="placeOrderButton" runat="server" Text="Place Order" OnClick="PlaceOrder_Click" />
        </asp:Panel>
        <asp:Panel ID="listaFinal" runat="server">
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server">   
            <asp:Label ID="orderPriceLabel" runat="server" />
            <br />
            <asp:Button ID="confirmOrderButton" Text="Confirm order" runat="server" OnClick="SubmitOrder" />   
        </asp:Panel>
        <asp:Panel ID="Panel3" runat="server"> 
          <asp:Button ID="Button1" runat="server" Text="GetOrders" OnClick="Button1_Click" />
          <br />
        </asp:Panel>
        <asp:Panel ID="botao" runat="server" Visible="False">
            <asp:Label ID="ccl" runat="server" Text="Credit Card"></asp:Label>
            <asp:TextBox ID="cc" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button2_Click" />
        </asp:Panel>
        <asp:Panel ID="Panel4" runat="server">
          <br /> 
        </asp:Panel> 
    </form>

    
    
</body>
</html>
