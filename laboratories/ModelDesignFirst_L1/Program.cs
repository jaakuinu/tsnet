using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDesignFirst_L1
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Test Model Designer First");
            do
            {
                String operation = Console.ReadLine();
                if (operation == "exit")
                {
                    break;
                }
                else if (operation == "people")
                {
                    String firstName, lastName, middleName, phoneNumber;
                    firstName = GetStrEntry("first name");
                    lastName = GetStrEntry("last name");
                    middleName = GetStrEntry("middle name");
                    phoneNumber = GetStrEntry("phone number");
                    Person p = new Person()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        MiddleName = middleName,
                        TelephoneNumber = phoneNumber
                    };
                    AddPerson(p);
                    PrintPeople();
                }
                else if (operation == "otm")
                {
                    String name, city;
                    name = GetStrEntry("name");
                    city = GetStrEntry("city");
                    Customer c = new Customer()
                    {
                        Name = name,
                        City = city
                    };
                    AddCustomer(c);
                    do
                    {
                        String placeOrder;
                        Console.WriteLine("Do you want to place an order? (y/n): ");
                        placeOrder = Console.ReadLine();
                        if (placeOrder.ToLower() == "n")
                        {
                            break;
                        }
                        else if(placeOrder.ToLower() == "y")
                        {
                            int value = GetIntEntry("value");

                            Order o = new Order()
                            {
                                TotalValue = value,
                                Date = DateTime.Now,
                                Customer = c
                            };
                            PlaceOrder(o);
                        }

                    } while (true);
                    PrintCustomersAndOrders();
                }
                else
                {
                    Console.WriteLine("Operation must be one of the following: exit, poeple, otm");

                }
            } while (true);

            // TestOneToMany();
            // TestPerson();
            // Console.ReadKey();
        }
        static void AddCustomer(Customer c)
        {
            using (ModelOneToManyContainerContainer context = new ModelOneToManyContainerContainer())
            {
                context.Customers.Add(c);
                context.SaveChanges();
            }
        }
        static void PlaceOrder(Order o)
        {
            using (ModelOneToManyContainerContainer context = new ModelOneToManyContainerContainer())
            {
                context.Orders.Add(o);
                context.SaveChanges();
            }
        }

        static void PrintCustomersAndOrders()
        {
            using (ModelOneToManyContainerContainer context = new ModelOneToManyContainerContainer())
            {
                var items = context.Customers;
                foreach (var x in items)
                {
                    Console.WriteLine("Customer: {0}, {1}, {2}", x.CustomerId, x.Name, x.City);
                    foreach (var ox in x.Orders)
                    {
                        Console.WriteLine("\tOrders: {0}, {1}, {2}", ox.OrderId, ox.Date, ox.TotalValue);
                    }
                }
            }
        }
        static void AddPerson(Person p)
        {
            using (Model1Container context = new Model1Container())
            {
                context.People.Add(p);
                context.SaveChanges();
            }
        }
        static void PrintPeople()
        {
            using (Model1Container context = new Model1Container())
            {
                var items = context.People;
                foreach (var x in items)
                {
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
                }
            }
        }
        static void TestPerson()
        {
            using (Model1Container context = new Model1Container())
            {
                Person p = new Person()
                {
                    FirstName = "Julie",
                    LastName = "Andrew",
                    MiddleName = "T",
                    TelephoneNumber = "1234567890"
                };
                context.People.Add(p);
                context.SaveChanges();
                var items = context.People;
                foreach(var x in items)
                {
                    Console.WriteLine("{0} {1}", x.Id, x.FirstName);
                }
            }
        }
        static String GetStrEntry(String field)
        {
            String entry;
            do
            {
                Console.Write("Please enter a value for {0} (must not be empty): ", field);
                entry = Console.ReadLine();
            } while (entry == "");
            return entry;
        }
        static int GetIntEntry(String field)
        {
            int entry;
            String tmpEntry;
            do
            {
                Console.Write("Please enter a value for {0} (must not be empty): ", field);
                tmpEntry = Console.ReadLine();
            } while (tmpEntry == "");
            Int32.TryParse(tmpEntry, out entry);
            return entry;
        }

        static void TestOneToMany()
        {
            Console.WriteLine("One to many association");
            using (ModelOneToManyContainerContainer context = new ModelOneToManyContainerContainer())
            {
                Customer c = new Customer()
                {
                    Name = "Customer 1",
                    City = "Iasi"
                };
            Order o1 = new Order()
            {
                TotalValue = 200,
                Date = DateTime.Now,
                Customer = c
            };
                Order o2 = new Order()
                {
                    TotalValue = 300,
                    Date = DateTime.Now,
                    Customer = c
                };
                context.Customers.Add(c);
                context.Orders.Add(o1);
                context.Orders.Add(o2);
                context.SaveChanges();

                var items = context.Customers;
                foreach(var x in items)
                {
                    Console.WriteLine("Customer: {0}, {1}, {2}", x.CustomerId, x.Name, x.City);
                    foreach(var ox in x.Orders)
                    {
                        Console.WriteLine("\tOrders: {0}, {1}, {2}", ox.OrderId, ox.Date, ox.TotalValue);
                    }
                }
            }
        }
    }
}
