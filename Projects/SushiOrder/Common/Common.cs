﻿using System;
using System.Collections.Generic;

[Serializable]
public class Order {
  public string Name { get; set; }
  public int type { get; set; }
  public int quantity { get; set; }
  public string address { get; set; }
  public int ccNumber { get; set; }
  /*
   * orded -> preparing -> ready -> delivering -> done
   */
  public string state { get; set; }

  public Order(string name, string add, int cc, int tp, int qt) {
    Name = name;
    address = add;
    ccNumber = cc;
    type = tp;
    quantity = qt;
    state = "orded";
  }
}
 
public interface IOrders {
  void Add(string name, string add, int cc, int tp, int qt);
  List<Order> GetCostumerOrders(string name);
  List<Order> GetAllOrders();
}
