using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using BeerlistService.Data;

namespace BeerlistService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (DataSevice service = new DataSevice(true))
            {
                //List<Person> personlist = new List<Person>();

                //Person alex = new Person { Name = "Alex" };
                //Person basti = new Person { Name = "Basti" };
                //Person marcus = new Person { Name="Marcus" };
                //Person oli = new Person { Name = "Oli" };

                //Schuld a = new Schuld { Schuldner = "Basti", value = 1 };
                //Schuld b = new Schuld { Schuldner = "Marcus", value = 2 };
                //Schuld c = new Schuld { Schuldner = "Oli", value = 3 };

                //Schuld d = new Schuld { Schuldner = "Alex", value = 1 };
                //Schuld e = new Schuld { Schuldner = "Marcus", value = 2 };
                //Schuld f = new Schuld { Schuldner = "Oli", value = 3 };

                //Schuld g = new Schuld { Schuldner = "Alex", value = 1 };
                //Schuld h = new Schuld { Schuldner = "Basti", value = 2 };
                //Schuld i = new Schuld { Schuldner = "Oli", value = 3 };

                //Schuld j = new Schuld { Schuldner = "Alex", value = 1 };
                //Schuld k = new Schuld { Schuldner = "Basti", value = 2 };
                //Schuld l = new Schuld { Schuldner = "Marcus", value = 3 };

                //alex.Schuldnerliste.Add(a);
                //alex.Schuldnerliste.Add(b);
                //alex.Schuldnerliste.Add(c);

                //basti.Schuldnerliste.Add(d);
                //basti.Schuldnerliste.Add(e);
                //basti.Schuldnerliste.Add(f);

                //marcus.Schuldnerliste.Add(g);
                //marcus.Schuldnerliste.Add(h);
                //marcus.Schuldnerliste.Add(i);

                //oli.Schuldnerliste.Add(j);
                //oli.Schuldnerliste.Add(k);
                //oli.Schuldnerliste.Add(l);

                //personlist.Add(alex);
                //personlist.Add(basti);
                //personlist.Add(marcus);
                //personlist.Add(oli);

                //string test = service.SerializeObject<List<Person>>(personlist);

                //personlist.Clear();

                //personlist = service.DeSerializeObject<List<Person>>();
            }
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
