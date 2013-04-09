using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


public class Orders : MarshalByRefObject, IOrders {
  private List<Order> AOrders;
  public event AddOrderEventHandler AddingOrder;
  public event PreparingOrderEventHandler PreparingOrder;
  public event ReadyOrderEventHandler ReadyOrder;


  public Orders() {
    if (!File.Exists("save.bin"))
    {
        Console.WriteLine("Save dont exist");
        AOrders = new List<Order>();
    }
    else
    {
        AOrders = load("save.bin");
        Console.WriteLine("Save exist");
    }
    //AOrders.Add(new Order("pete", "address", 11111, 1, 2));
    Console.WriteLine("[Orders] built.");
  }

  ~Orders()
  {
      System.Diagnostics.Trace.WriteLine("First's destructor is called.");
      save("save.bin");
  }

  public void save(string filename)
  {
      IFormatter formatter = new BinaryFormatter();
      Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
      formatter.Serialize(stream, AOrders);
      stream.Close();
  }
  public List<Order> load(string filename)
  {
      List<Order> AOrders;
      Stream stream = File.Open(filename, FileMode.Open);
      BinaryFormatter bFormatter = new BinaryFormatter();
      AOrders = (List<Order>)bFormatter.Deserialize(stream);
      stream.Close();
      return AOrders;
  }
  public void addPayOrder(Order o)
  {
      using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Tiago\Documents\GitHub\tdin\Encomendas.txt", true))
      {
          //(seu identificador numérico), data e hora, nome do cliente e número do cartão de crédito.
          file.WriteLine(o.id.ToString() + " " + o.client.timestamp.ToString() + " " + o.client.name +  " " + o.client.ccNumber.ToString());
      }
  }  
    
  public override object InitializeLifetimeService()
  {
      Console.WriteLine("[Orders]: InitilizeLifetimeService");
      return null;
  }

  public void Add(string name, string add, int cc, int tp, int qt)
  {
    Order nO = new Order(name, add, cc, tp, qt);
    nO.id = AOrders.Count + 1;
    AOrders.Add(nO);
    AddingOrder();
    Console.WriteLine("[Add] called.");
  }

  public List<Order> GetCostumerOrders(string name) {
    List<Order> result = new List<Order>();

    foreach (Order or in AOrders)
      if (or.client.name == name)
        result.Add(or);
    Console.WriteLine("[GetCostumerOrders] called.");
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

  public List<Order> GetReadyOrders()
  {
      Console.WriteLine("[GetReadyOrders] called.");
      return AOrders.FindAll(x => x.state == "ready");
  }


  public void setOrderPreparing(string t)
  {

      AOrders.Find(x => x.id == Convert.ToInt32(t)).state = "preparing";
      PreparingOrder();
      AOrders.Find(x => x.id == Convert.ToInt32(t)).client.timestamp = DateTime.Now;
      //TODO meter a gravar para ficheiro as encomendas pagas, com o ID, timestamp, nome e cc.
      addPayOrder(AOrders.Find(x => x.id == Convert.ToInt32(t)));
  }

  public void setOrderReady(string t)
  {
      AOrders.Find(x => x.id == Convert.ToInt32(t)).state = "ready";
      ReadyOrder();
  }

}


