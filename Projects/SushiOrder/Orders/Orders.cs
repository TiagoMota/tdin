using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Orders : MarshalByRefObject, IOrders {
  private List<Order> AOrders;
  public event AddOrderEventHandler AddingOrder;
  public event PreparingOrderEventHandler PreparingOrder;

  public Orders() {
    AOrders = new List<Order>();
    //AOrders.Add(new Order("pete", "address", 11111, 1, 2));
    Console.WriteLine("[Orders] built.");
  }

  public override object InitializeLifetimeService()
  {
      Console.WriteLine("[Orders]: InitilizeLifetimeService");
      return null;
  }

  public void Add(string name, string add, int cc, int tp, int qt)
  {
    AOrders.Add(new Order(name, add, cc, tp, qt));
    AddingOrder();
    Console.WriteLine("[Add] called.");
  }

  public List<Order> GetCostumerOrders(string name) {
    List<Order> result = new List<Order>();

    foreach (Order or in AOrders)
      if (or.Name == name)
        result.Add(or);
    Console.WriteLine("[GetOrders] called.");
    return result;
  }

  public List<Order> GetAllOrders()
  {
      Console.WriteLine("[GetAllOrders] called.");
      return AOrders;
      
  }

  public List<Order> GetOrdedOrders()
  {
      Console.WriteLine("[GetOrdedOrders] called.");
      return AOrders.FindAll(x => x.state == "orded");
  }

  public List<Order> GetPreparingOrders()
  {
      Console.WriteLine("[GetPreparingOrders] called.");
      return AOrders.FindAll(x => x.state == "preparing");
  }

  public void setOrderPreparing(string t)
  {
      AOrders.Find(x => x.Name == t).state = "preparing";
      PreparingOrder();
  }

  

}


