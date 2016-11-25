using System;

namespace BeerlistService.Data
{
    public class Schuld : IComparable
    {
        public string Schuldner { get; set; }

        public int Value { get; set; }

        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                return 1;
            }

            if (obj is Schuld)
            {
                return this.Schuldner.CompareTo((obj as Schuld).Schuldner);
            }

            return base.GetHashCode().CompareTo(obj.GetHashCode());
        }
    }
}