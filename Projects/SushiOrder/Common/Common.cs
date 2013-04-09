using System;
using System.Collections.Generic;


//Delegates
public delegate void AddOrderEventHandler();
public delegate void PreparingOrderEventHandler();
public delegate void ReadyOrderEventHandler();

[Serializable]
public class Client
{
    public string name { get; set; }
    public string address { get; set; }
    public int ccNumber { get; set; }
    public DateTime timestamp { get; set; }

    public Client(string n, string addr, int cc)
    {
        name = n;
        address = addr;
        ccNumber = cc;
    }
}

[Serializable]
public class Order {
  public int id { get; set; }
  public int type { get; set; }
  public int quantity { get; set; }
  public Client client { get; set; }
  /*
   * orded -> preparing -> ready -> delivering -> done
   */
  public string state { get; set; }

  public Order(string name, string add, int cc, int tp, int qt) {
    client = new Client(name, add, cc);
    type = tp;
    quantity = qt;
    state = "orded";
  }
}
 
public interface IOrders {
  
  event AddOrderEventHandler AddingOrder;
  event PreparingOrderEventHandler PreparingOrder;
  event ReadyOrderEventHandler ReadyOrder;

  void Add(string name, string add, int cc, int tp, int qt);
  List<Order> GetCostumerOrders(string name);
  List<Order> GetAllOrders();
  List<Order> GetOrdedOrders();
  List<Order> GetPreparingOrders();
  List<Order> GetReadyOrders();
  void setOrderPreparing(string t);
  void setOrderReady(string t);

}

public class EventIntermediate : MarshalByRefObject
{
    public event AddOrderEventHandler AddingOrder;
    public event PreparingOrderEventHandler PreparingOrder;
    public event ReadyOrderEventHandler ReadyOrder;

    public void FireAddingOrder()
    {
        AddingOrder();
    }

    public void FirePreparingOrder() 
    {
        PreparingOrder();
    }

    public void FireReadyOrder()
    {
        ReadyOrder();
    }


    public override object InitializeLifetimeService()
    {
        Console.WriteLine("[EventIntermediate]: InitilizeLifetimeService");
        return null;
    }

}





