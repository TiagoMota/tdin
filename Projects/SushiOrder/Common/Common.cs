using System;
using System.Collections.Generic;


//Delegates
public delegate void AddOrderEventHandler();
public delegate void PreparingOrderEventHandler();
public delegate void ReadyOrderEventHandler();
public delegate void DeliveringOrderEventHandler();
public delegate void FinalizingOrderEventHandler();

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
  public string deliveryTeamAssigned { get; set; }

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
  event DeliveringOrderEventHandler DeliveringOrder;
  event FinalizingOrderEventHandler FinalizingOrder;

  void Add(string name, string add, int cc, int tp, int qt);
  List<Order> GetCostumerOrders(string name);
  List<Order> GetAllOrders();
  List<Order> GetOrdedOrders();
  List<Order> GetPreparingOrders();
  List<Order> GetReadyOrders();
  List<Order> GetDeliveringOrders();
  void setOrderPreparing(string t);
  void setOrderReady(string t);
  void setOrderDelivering(string t, string team);
  void setOrderDone(string t);

  List<String> GetDeliveryTeams();
  void AddDeliveryTeam(string i);

}

public class EventIntermediate : MarshalByRefObject
{
    public event AddOrderEventHandler AddingOrder;
    public event PreparingOrderEventHandler PreparingOrder;
    public event ReadyOrderEventHandler ReadyOrder;
    public event DeliveringOrderEventHandler DeliveringOrder;
    public event FinalizingOrderEventHandler FinalizingOrder;

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

    public void FireDeliveringOrder()
    {
        DeliveringOrder();
    }

    public void FireFinalizingOrder()
    {
        FinalizingOrder();
    }


    public override object InitializeLifetimeService()
    {
        Console.WriteLine("[EventIntermediate]: InitilizeLifetimeService");
        return null;
    }

}





