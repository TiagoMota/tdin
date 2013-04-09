using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;


class DeliveryRoom
{
    EventIntermediate inter;
    IOrders ordersList;
    public DeliveryRoom()
    {
    }

    public void OnReadyOrder()
    {
        Console.WriteLine("FUNCIONA!");
    }

    public void start(){

        RemotingConfiguration.Configure("DeliveryRoom.exe.config", false);
        inter = new EventIntermediate();
        inter.ReadyOrder += OnReadyOrder;
        ordersList = (IOrders)Activator.GetObject(typeof(IOrders), "tcp://localhost:9000/Server/OrdersServer");
        ordersList.ReadyOrder += inter.FireReadyOrder;
        Console.ReadLine();
    }

    static void Main(string[] args)
    {
        DeliveryRoom n = new DeliveryRoom();
        n.start();
    }
}

