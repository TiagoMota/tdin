<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
            <table>
                <tr>
                    <td>Type</td>
                    <td>Amount</td>
                </tr>
                <tr>
                    <td>
                       <select>
                          <option value="1">Type 1</option>
                          <option value="2">Type 2</option>
                          <option value="3">Type 3</option>
                        </select>
                    </td>
                    <td><asp:TextBox id="ammount" value="0" runat="server"/></td>
                </tr>
            </table>
            <asp:ImageButton ID="more" runat="server" />
            <asp:ImageButton ID="ImageButton2" runat="server" />
            <br />
            <asp:Button ID="placeOrderButton" runat="server" Text="Place Order" OnClick="PlaceOrder_Click" />
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
        <asp:Panel ID="Panel4" runat="server">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:BulletedList ID="BulletedList1" runat="server"></asp:BulletedList>
          <br /> 
        </asp:Panel> 
    </form>

    
    
</body>
</html>
