using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BeerlistService.Data
{
    public class Person
    {
        public string Name { get; set; }

        public List<Schuld> Schuldnerliste { get; set; }

        public Person()
        {
            Schuldnerliste = new List<Schuld>();
        }
    }
}
