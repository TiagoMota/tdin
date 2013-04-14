using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    //TODO meter a dar para fazer encomendas de vários tipos de sushi de uma vez
  IOrders orderObj;
  private int size = 1;
  protected void Page_Load(object sender, EventArgs e) {
      if (!IsPostBack)
      {                                       // first load in a session
      
          Panel1.Visible = false;
          Panel2.Visible = false;
          Panel4.Visible = false;
      }
    string address = ConfigurationManager.AppSettings["RemoteAddress"];
    orderObj = (IOrders) Activator.GetObject(typeof(IOrders), address);
  
  }

  protected void ShowOrderForm(object sender, EventArgs e)
  {
      Panel1.Visible = true;
      placeOrderButton.Visible = true;
      numeroPedidos.Visible = true;
      pedidos.Visible = true;
      buttonPedidos.Visible = true;
  }

  protected void PlaceOrder_Click(object sender, EventArgs e)
  {
      int price = 0;
      string[] amounts = Request.Form.GetValues("amount");
      string[] types = Request.Form.GetValues("type");
      for (int i = 0; i < Convert.ToInt32(pedidos.Text); i++)
      {
          switch (types[i])
          {
              case "1":
                  price += Convert.ToInt32(amounts[i]) * 20;
                  break;
              case "2":
                  price += Convert.ToInt32(amounts[i]) * 30;
                  break;
              case "3" :
                  price += Convert.ToInt32(amounts[i]) * 35;
                  break;
          }
      }
      orderPriceLabel.Text = "Order Price: " + price;
      orderPriceLabel.Visible = true;
      ordersPanel.Visible = true;

      Table table = new Table();
      for (int i = 0; i < Convert.ToInt32(pedidos.Text); i++)
      {
          TableRow row = new TableRow();
          row.ID = i.ToString();
          TableCell cell1 = new TableCell();
          TableCell cell2 = new TableCell();

          DropDownList drop = new DropDownList();
          drop.ID = "typex";
          ListItem temp = new ListItem();
          temp.Text = "Type " + types[i];
          drop.Items.Add(temp);
          drop.Enabled = false;
          cell1.Controls.Add(drop);
          TextBox input = new TextBox();
          input.ID = "amountx";
          input.Enabled = false;
          input.Text = amounts[i];
          cell2.Controls.Add(input);
          row.Cells.Add(cell1);
          row.Cells.Add(cell2);
          table.Controls.Add(row);
      }
      listaFinal.Controls.Add(table);
      listaFinal.Visible = true;
      HiddenField inputpedidos = new HiddenField();
      inputpedidos.ID = "pedidos";
      inputpedidos.Value = pedidos.Text;
      ordersPanel.Controls.Add(inputpedidos);
      for (int i = 0; i < Convert.ToInt32(pedidos.Text); i++)
      {

          HiddenField inputType = new HiddenField();
          inputType.ID = "type";
          inputType.Value = types[i];
          ordersPanel.Controls.Add(inputType);
          //
          HiddenField inputAmount = new HiddenField();
          inputAmount.ID = "amount";
          inputAmount.Value = amounts[i];
          ordersPanel.Controls.Add(inputAmount);
      }
      Panel2.Visible = true;
      placeOrderButton.Visible = false;
      numeroPedidos.Visible = false;
      pedidos.Visible = false;
      buttonPedidos.Visible = false;
  }

  protected void buttonPedidos_Click(object sender, EventArgs e)
  {

      ordersPanel.Visible = true;
      add(Convert.ToInt32(pedidos.Text));
  }

  protected void Button1_Click(object sender, EventArgs e) 
  {
    //TODO mudar isto
      botao.Visible = true;
  
  }

  protected void SubmitOrder(object sender, EventArgs e)
  {
      //TODO adicionar nova order ao objecto remoto
      Panel1.Visible = false;
      Dictionary<int, int> orders = new Dictionary<int, int>();
      string[] amounts = Request.Form.GetValues("amount");
      string[] types = Request.Form.GetValues("type");
      for (int i = 0; i < Convert.ToInt32(pedidos.Text); i++)
      {
          orders.Add(Convert.ToInt32(types[i]), Convert.ToInt32(amounts[i]));
      }
      orderObj.Add(costumerName.Text, costumerAddress.Text, Convert.ToInt32(costumerCC.Text),orders);
  }

  private void add(int n)
  {

      //tipos
        ArrayList tipos= new ArrayList();
        tipos.Add("Type 1");
        tipos.Add("Type 2");
        tipos.Add("Type 3");
      //

      Table table = new Table();
      for(int i =0; i < n; i++)
      {
          TableRow row = new TableRow();
          row.ID = i.ToString();
          TableCell cell1 = new TableCell();
          TableCell cell2 = new TableCell();

          DropDownList drop = new DropDownList();
          drop.ID = "type";
          for (int j = 0; j < tipos.Count; j++)
          {
              ListItem temp = new ListItem();
              if (j == 0)
                  temp.Selected = true;
              int index = j + 1;
              temp.Value = index.ToString();
              temp.Text = (string)tipos[j];
              drop.Items.Add(temp);
          }
          cell1.Controls.Add(drop);
          TextBox input = new TextBox();
          input.ID = "amount";
          cell2.Controls.Add(input);
          row.Cells.Add(cell1);
          row.Cells.Add(cell2);
          table.Controls.Add(row);
     }
      ordersPanel.Controls.Add(table);
  }
  protected void Button2_Click(object sender, EventArgs e)
  {
      List<Order> ls;
      ls = orderObj.GetAllOrders();
      List<String> itemsList = new List<string>();

      foreach (Order o in ls)
      {
          Label l = new Label();
          l.Text= o.client.name + "- Encomenda id: " + o.id + " [" + o.state + "]";
          Table t = new Table();
          TableRow row = new TableRow();
          TableCell cell1 = new TableCell();
          TableCell cell2 = new TableCell();
          Label l1 = new Label();
          l1.Text = "Type";
          Label l2 = new Label();
          l2.Text = "Amount";
          cell1.Controls.Add(l1);
          cell2.Controls.Add(l2);
          row.Controls.Add(cell1);
          row.Controls.Add(cell2);
          t.Controls.Add(row);
          
          foreach (var pair in o.order)
          {
              TableRow row1 = new TableRow();
              TableCell cell11 = new TableCell();
              TableCell cell12 = new TableCell();
              Label Ll = new Label();
              Label Lr = new Label();
              Ll.Text = pair.Key.ToString();
              Lr.Text = pair.Value.ToString();
              cell11.Controls.Add(Ll);
              cell12.Controls.Add(Lr);
              row1.Controls.Add(cell11);
              row1.Controls.Add(cell12);
              t.Controls.Add(row1);
          }
          Panel4.Controls.Add(l);
          Panel4.Controls.Add(t);
          Label temp = new Label();
          temp.Text = "###################################################<br>";
          Panel4.Controls.Add(temp);
      }
      Panel4.Visible = true;
  }
}