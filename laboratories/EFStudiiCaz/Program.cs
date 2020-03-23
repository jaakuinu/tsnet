using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStudiiCaz
{
    class Program
    {
        static void Main(string[] args)
        {
            Scenariu1(false);
            Console.ReadLine();
        }

        static void Scenariu1(bool addData)
        {
            using (Model1 context = new Model1())
            {
                if (addData)
                {
                    SelfReference root = new SelfReference()
                    {
                        Name = "Root",

                    };
                    context.SelfReferences.Add(root);
                    for(uint i = 0; i < 30; ++i)
                    {
                        SelfReference r = new SelfReference()
                        {
                            Name = "Item " + i.ToString(),
                            ParentSelfReference = root
                        };
                        context.SelfReferences.Add(r);
                    }
                    context.SaveChanges();
                }
                var references = context.SelfReferences;
                foreach(var r in references)
                {
                    Console.WriteLine("Item with name " + r.Name);
                    Console.WriteLine("References: ");
                    foreach(var r2 in r.References)
                    {
                        Console.Write(r2.Name + " ");
                    }
                    Console.WriteLine("\n");
                }
                
            }
        }
       
    }
}
