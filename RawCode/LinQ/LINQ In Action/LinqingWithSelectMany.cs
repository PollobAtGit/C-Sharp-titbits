using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqingWithSelectMany
{
    public class Client
    {
        public class Order { public string OrderNumber { get { return "N/A"; } } }
        public class Customer { public IEnumerable<Order> Orders { get; set; } }

        public static void Main()
        {
            IEnumerable<Customer> customers = new List<Customer>
            {
                new Customer
                {
                    Orders = new List<Order>
                    {
                        new Order(),
                        new Order()
                    }
                },
                new Customer
                {
                    Orders = new List<Order>
                    {
                        new Order(),
                        new Order()
                    }
                }
            };

            IEnumerable<IEnumerable<Order>> listOfOrders = customers.Select<Customer, IEnumerable<Order>>(cust => cust.Orders);

            //Poi: Here to get all Orders two loops has been used. To avoid this noise, we need to flatten the list of orders
            foreach(var orders in listOfOrders)
            {
                foreach(var order in orders)
                {
                    Console.WriteLine(order.OrderNumber);
                }
            }

            Console.WriteLine();

            //Poi: '...SelectMany<TSource, TResult>(...)' returns a flattened list where 'TSource' & 'TResult' has a one to many relationship
            IEnumerable<Order> ordersFlattened = customers.SelectMany<Customer, Order>(cust => cust.Orders);
            foreach(Order ordr in ordersFlattened)
            {
                Console.WriteLine(ordr.OrderNumber);
            }

            Customer[] customersArray = new Customer[]
            {
                new Customer { Orders = new Order[] { new Order(), new Order() } },
                new Customer { Orders = new Order[] { new Order(), new Order() } }
            };

            Console.WriteLine();
            Order[] ordersArray = customersArray.SelectMany<Customer, Order>(cust => cust.Orders).ToArray();
            foreach(var order in ordersArray)
            {
                Console.WriteLine(order.OrderNumber);
            }
        }
    }
}