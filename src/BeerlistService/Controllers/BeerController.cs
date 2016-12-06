using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeerlistService.Data;
using System.Net;
using System.Web.Http;

namespace BeerlistService.Controllers
{
    [Route("api")]
    public class BeerController : Controller
    {
        //Liste auslesen
        // GET api
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            try{
                IEnumerable<Person> personlist;
                using (DataSevice service = new DataSevice(false))
                {
                    personlist = service.DeSerializeObject<IEnumerable<Person>>();
                }

                return personlist;
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        //Schuld um 1 erhöhen
        // PUT api/name1/inc/name2
        [HttpPut("{getperson}/inc/{oweperson}")]
        public void Increase(string getperson, string oweperson)
        {
            if (this.Request.Method == "PUT")
            {
                try {
                        List<Person> personlist = new List<Person>();
                        Manager incManager = new Manager();
                        bool ret = false;

                        using (DataSevice service = new DataSevice(true))
                        {
                            personlist = service.DeSerializeObject<List<Person>>();

                            if (incManager.ChangeValue(personlist, getperson, oweperson, (s) => s.Value++))
                            {
                                service.SerializeObject<List<Person>>(personlist);
                            }
                        }
                    }
                
                catch (Exception)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
            }
        }

        //Schuld um 1 vermindern
        // PUT api/name1/dec/name2
        [HttpPut("{getperson}/dec/{oweperson}")]
        public void Decrease(string getperson, string oweperson)
        {
            var x = this.Request.Method;
            if (this.Request.Method == "PUT")
            {
                try
                {
                    List<Person> personlist = new List<Person>();
                    Manager incManager = new Manager();

                    using (DataSevice service = new DataSevice(true))
                    {
                        personlist = service.DeSerializeObject<List<Person>>();

                        if (incManager.ChangeValue(personlist, getperson, oweperson, (s) => s.Value = Math.Max(s.Value - 1, 0)))
                        {
                            service.SerializeObject<List<Person>>(personlist);
                        }
                    }

                }
                catch (Exception)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
               
            }
        }

        // Person hinzufügen
        // POST api/name/add
        [HttpPost("{name}/add")]
        public IEnumerable<Person> Add(string name)
        {
            List<Person> personlist = new List<Person>();
            if (this.Request.Method == "POST")
            {
                try
                {
                    Manager incManager = new Manager();

                    using (DataSevice service = new DataSevice(true))
                    {
                        personlist = service.DeSerializeObject<List<Person>>();

                        if (incManager.AddPerson(personlist, name))
                        {
                            service.SerializeObject<List<Person>>(personlist);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
               
            }
            return personlist;
        }

        // Person Löschen
        // POST api/name/delete
        [HttpDelete("{name}/delete")]
        public IEnumerable<Person> Delete(string name)
        {
            List<Person> personlist = new List<Person>();
            if (this.Request.Method == "DELETE")
            {
                try
                {
                    Manager incManager = new Manager();

                    using (DataSevice service = new DataSevice(true))
                    {
                        personlist = service.DeSerializeObject<List<Person>>();

                        if (incManager.DeletePerson(personlist, name))
                        {
                            service.SerializeObject<List<Person>>(personlist);
                        }
                    }
                }
                catch (Exception)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }

            }
            return personlist;
        }

        [HttpGet("/neu")]
        public bool Neu()
        {
            //using (DataSevice service = new DataSevice(true))
            //{
            //    List<Person> personlist = new List<Person>();

            //    Person alex = new Person { Name = "Alex" };
            //    Person basti = new Person { Name = "Basti" };
            //    Person marcus = new Person { Name = "Marcus" };
            //    Person oli = new Person { Name = "Oli" };

            //    Schuld a = new Schuld { Schuldner = "Basti", Value = 1 };
            //    Schuld b = new Schuld { Schuldner = "Marcus", Value = 2 };
            //    Schuld c = new Schuld { Schuldner = "Oli", Value = 3 };

            //    Schuld d = new Schuld { Schuldner = "Alex", Value = 1 };
            //    Schuld e = new Schuld { Schuldner = "Marcus", Value = 2 };
            //    Schuld f = new Schuld { Schuldner = "Oli", Value = 3 };

            //    Schuld g = new Schuld { Schuldner = "Alex", Value = 1 };
            //    Schuld h = new Schuld { Schuldner = "Basti", Value = 2 };
            //    Schuld i = new Schuld { Schuldner = "Oli", Value = 3 };

            //    Schuld j = new Schuld { Schuldner = "Alex", Value = 1 };
            //    Schuld k = new Schuld { Schuldner = "Basti", Value = 2 };
            //    Schuld l = new Schuld { Schuldner = "Marcus", Value = 3 };

            //    alex.Schuldnerliste.Add(a);
            //    alex.Schuldnerliste.Add(b);
            //    alex.Schuldnerliste.Add(c);

            //    basti.Schuldnerliste.Add(d);
            //    basti.Schuldnerliste.Add(e);
            //    basti.Schuldnerliste.Add(f);

            //    marcus.Schuldnerliste.Add(g);
            //    marcus.Schuldnerliste.Add(h);
            //    marcus.Schuldnerliste.Add(i);

            //    oli.Schuldnerliste.Add(j);
            //    oli.Schuldnerliste.Add(k);
            //    oli.Schuldnerliste.Add(l);

            //    personlist.Add(alex);
            //    personlist.Add(basti);
            //    personlist.Add(marcus);
            //    personlist.Add(oli);

            //    string test = service.SerializeObject<List<Person>>(personlist);

            //    personlist.Clear();

            //    personlist = service.DeSerializeObject<List<Person>>();
            //}
            return true;
        }

    }
}
