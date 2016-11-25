using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BeerlistService.Data
{
    public class Person : IComparable
    {
        public string Name { get; set; }

        public List<Schuld> Schuldnerliste { get; set; }

        public Person()
        {
            Schuldnerliste = new List<Schuld>();
        }

        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                return 1;
            }

            if (obj is Person)
            {
                return this.Name.CompareTo((obj as Person).Name);
            }

            return base.GetHashCode().CompareTo(obj.GetHashCode());
        }
    }
}
