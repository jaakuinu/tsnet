using System;

namespace ModelCodeFirst
{
    public class API
    {
        public static int AddCustomer(string name, string city)
        {
            using (ModelContext context = new ModelContext())
            {
                Customer c = new Customer()
                {
                    Name = name,
                    City = city
                };
                context.Customers.Add(c);
                context.SaveChanges();
                return c.CustomerId;
            }
        }

        public static int PlaceOrder(int customerId, int value)
        {
            using (ModelContext context = new ModelContext())
            {
                Customer c = context.Customers.Find(customerId);
                if(c == null)
                {
                    return -1;
                }
                Order o = new Order()
                {
                    Value = value,
                    Customer = c,
                    Date = DateTime.Now
                };
                context.Orders.Add(o);
                context.SaveChanges();
                return o.OrderId;
            }
        }
    }
}
