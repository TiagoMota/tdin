using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Orders : MarshalByRefObject, IOrders {
  private List<Order> AOrders;

  public Orders() {
    AOrders = new List<Order>();
    //AOrders.Add(new Order("pete", 2));
    Console.WriteLine("[Orders] built.");
  }

  public void Add(string name, string add, int cc, int tp, int qt)
  {
    AOrders.Add(new Order(name, add, cc, tp, qt));
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
      return AOrders;
  }
}
