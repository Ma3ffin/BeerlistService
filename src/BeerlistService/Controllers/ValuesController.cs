using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeerlistService.Data;

namespace BeerlistService.Controllers
{
    [Route("api")]
    public class ValuesController : Controller
    {
        //Liste auslesen
        // GET api
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return new DataSevice(false).DeSerializeObject<IEnumerable<Person>>();
        }

        //Schuld um 1 erhöhen
        // PUT api/name1/inc/name2
        [HttpPut("{name1}/inc/{name2}")]
        public void Increase(string name1, string name2)
        {
        }

        //Schuld um 1 vermindern
        // PUT api/name1/dec/name2
        [HttpPut("{name1}/dec/{name2}")]
        public void Decrease(string name1, string name2)
        {
        }

        // Person hinzufügen
        // POST api/name/add
        [HttpPost("{name}/add")]
        public void Add(string name)
        {
        }

    }
}
