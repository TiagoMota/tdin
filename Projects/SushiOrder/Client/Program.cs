using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

class Program {
  static void Main(string[] args) {
    IOrders lorders;
    List<Order> ls;
    
    RemotingConfiguration.Configure("Client.exe.config", false);
    lorders = (IOrders)RemoteNew.New(typeof(IOrders));
    ls = lorders.GetAllOrders();
    foreach (Order o in ls)
      Console.WriteLine("{0}, {1}", o.Name, o.type);
    Console.ReadLine();

      //TODO para actualizar automáticamente a lista, é preciso implementar um evento em que o trigger seja efectuado no servidor para que seja notificado no cliente
  }
}

/* Mechanism for instanciating a remote object through its interface, using the config file */

class RemoteNew
{
  private static Hashtable types = null;

  private static void InitTypeTable()
  {
    types = new Hashtable();
    foreach (WellKnownClientTypeEntry entry in RemotingConfiguration.GetRegisteredWellKnownClientTypes())
      types.Add(entry.ObjectType, entry);
  }

  public static object New(Type type)
  {
    if (types == null)
      InitTypeTable();
    WellKnownClientTypeEntry entry = (WellKnownClientTypeEntry)types[type];
    if (entry == null)
      throw new RemotingException("Type not found!");
    return RemotingServices.Connect(type, entry.ObjectUrl);
  }
}