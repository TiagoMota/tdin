using System;
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
      int price = 5;//(Convert.ToInt32(ammount1.Text) * 20 + Convert.ToInt32(ammount2.Text) * 30 + Convert.ToInt32(ammount3.Text) * 35);
      orderPriceLabel.Text = "Order Price: " + price;
      orderPriceLabel.Visible = true;

      Panel2.Visible = true;
  }

  protected void Button1_Click(object sender, EventArgs e) {
    //TODO mudar isto

    List<Order> ls;

    ls = orderObj.GetAllOrders();
    foreach (Order o in ls)
        BulletedList1.Items.Add(o.id + " | " + o.client.name + " | " + o.client.address + " | " + o.client.ccNumber + " | " + o.type + " | " + o.quantity + " | " + o.state);
    Panel4.Visible = true;
  }

  protected void SubmitOrder(object sender, EventArgs e)
  {
      //TODO adicionar nova order ao objecto remoto
      Panel1.Visible = false;
      Dictionary<int, string> orders = new Dictionary<int, string>();
      //orders.Add(1, ammount1.Text);
      //orders.Add(2, ammount2.Text);
      orders.Add(2, "2");
      orderObj.Add(costumerName.Text, costumerAddress.Text, Convert.ToInt32(costumerCC.Text),orders);
  }
}