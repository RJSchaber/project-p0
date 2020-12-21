using System;
using System.Collections.Generic;

namespace PizzaWorld.Domain.Models
{
    public class Store
    {
        public List<Order> Orders { get; set; }
        public void CreateOrder()
        {
            Orders.Add(new Order());
        }

        bool DeleteOrder(Order order)
        {
            try
            {
                Orders.Remove(order);

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            
        }

        public void ListPizzas()
        {
            
        }


    }
}