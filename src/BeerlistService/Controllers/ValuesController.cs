using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeerlistService.Data;

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
            IEnumerable<Person> personlist;
            using (DataSevice service = new DataSevice(false))
            {
                personlist = service.DeSerializeObject<IEnumerable<Person>>();
            }

            return personlist;
        }

        //Schuld um 1 erhöhen
        // PUT api/name1/inc/name2
        [HttpPut("{getperson}/inc/{oweperson}")]
        public bool Increase(string getperson, string oweperson)
        {
            List<Person> personlist = new List<Person>();
            Manager incManager = new Manager();
            bool ret = false;

            using (DataSevice service = new DataSevice(true))
            {
                personlist = service.DeSerializeObject<List<Person>>();

                if (incManager.ChangeValue(personlist, getperson, oweperson, (s) => s.Value++))
                {
                    service.SerializeObject<List<Person>>(personlist);
                    ret = true;
                }
            }

            return ret;
        }

        //Schuld um 1 vermindern
        // PUT api/name1/dec/name2
        [HttpPut("{getperson}/dec/{oweperson}")]
        public bool Decrease(string getperson, string oweperson)
        {
            List<Person> personlist = new List<Person>();
            Manager incManager = new Manager();
            bool ret = false;

            using (DataSevice service = new DataSevice(true))
            {
                personlist = service.DeSerializeObject<List<Person>>();

                if (incManager.ChangeValue(personlist, getperson, oweperson, (s) => s.Value = Math.Max(s.Value - 1, 0)))
                {
                    service.SerializeObject<List<Person>>(personlist);
                    ret = true;
                }
            }
            return ret;
        }

        // Person hinzufügen
        // POST api/name/add
        [HttpPost("{name}/add")]
        public IEnumerable<Person> Add(string name)
        {
            List<Person> personlist = new List<Person>();
            Manager incManager = new Manager();

            using (DataSevice service = new DataSevice(true))
            {
                personlist = service.DeSerializeObject<List<Person>>();

                if (incManager.AddPerson(personlist, name))
                {
                    service.SerializeObject<List<Person>>(personlist);
                }
            }

            return personlist;
        }

    }
}
