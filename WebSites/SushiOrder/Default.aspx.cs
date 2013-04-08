using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
  IOrders orderObj;

  protected void Page_Load(object sender, EventArgs e) {
      if (!IsPostBack)
      {                                       // first load in a session
          GridView1.Visible = false;
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
  }

  protected void PlaceOrder_Click(object sender, EventArgs e)
  {
      if (orderType.Text == "1")
      {
          orderPriceLabel.Text = "Order Price: " + Convert.ToInt32(orderQuantity.Text) * 20;
          orderPriceLabel.Visible = true;
      }
      else if (orderType.Text == "2")
      {
          orderPriceLabel.Text = "Order Price: " + Convert.ToInt32(orderQuantity.Text) * 30;
          orderPriceLabel.Visible = true;
      }
      else
      {
          orderPriceLabel.Text = "Order Price: " + Convert.ToInt32(orderQuantity.Text) * 35;
          orderPriceLabel.Visible = true;
      }

      Panel2.Visible = true;
  }

  protected void Button1_Click(object sender, EventArgs e) {
    //TODO mudar isto

    List<Order> ls;

    ls = orderObj.GetAllOrders();
    foreach (Order o in ls)
        BulletedList1.Items.Add(o.Name + " | " + o.address + " | " + o.ccNumber + " | " + o.type + " | " + o.quantity + " | " + o.state);
    Panel4.Visible = true;
  }

  protected void SubmitOrder(object sender, EventArgs e)
  {
      //TODO adicionar nova order ao objecto remoto
      Panel1.Visible = false;
      orderObj.Add(costumerName.Text, costumerAddress.Text, Convert.ToInt32(costumerCC.Text), Convert.ToInt32(orderType.Text), Convert.ToInt32(orderQuantity.Text));
  }
}