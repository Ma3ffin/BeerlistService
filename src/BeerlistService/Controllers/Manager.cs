using BeerlistService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerlistService.Controllers
{
    public class Manager
    {
        
        

        public bool ChangeValue(List<Person> personlist, string getperson, string oweperson, Action<Schuld> action)
        {
            Person addPerson;
            Schuld addSchuld;
            if ((addPerson = this.PersonExist(personlist, getperson)) != null)
            {
                if ((addSchuld = this.SchuldExist(addPerson, oweperson)) != null)
                {
                    action(addSchuld);
                    return true;
                }
            }
            return false;
        }

        

        public bool DeletePerson(List<Person> personlist, string name)
        {
            if (CanDeletePerson(personlist, name))
            {
                var deletePerson = new Person();
                foreach (var person in personlist)
                {
                    var deleteSchuld = new Schuld();
                    foreach (var item in person.Schuldnerliste)
                    {
                        if (item.Schuldner.Equals(name))
                        {
                            deleteSchuld = item;
                        }
                    }

                    if (person.Name.Equals(name))
                    {
                        deletePerson = person;
                    }
                    else
                    {
                        person.Schuldnerliste.Remove(deleteSchuld);
                    }
                    
                }
                personlist.Remove(deletePerson);
                SortPersonList(personlist);
                return true;
            }
            return false;
        }

        public bool CanDeletePerson(List<Person> personlist, string name)
        {
            if (PersonExist(personlist, name) != null)
            {
                var ret = true;
                foreach (var person in personlist)
                {
                    foreach (var item in person.Schuldnerliste)
                    {
                        if (item.Schuldner.Equals(name) && item.Value != 0)
                        {
                            ret = false;
                        }
                    }

                    if (person.Name.Equals(name))
                    {
                        foreach (var item in person.Schuldnerliste)
                        {
                            if (item.Value != 0)
                            {
                                ret = false;
                            }
                        }
                    }

                }

                return ret;
            }
            return false;
        }

        public bool AddPerson(List<Person> personlist, string name)
        {
            if (PersonExist(personlist, name) == null)
            {
                Person newperson = new Person();
                newperson.Name = name;

                foreach (var item in personlist)
                {
                    newperson.Schuldnerliste.Add(new Schuld {
                        Schuldner = item.Name,
                        Value = 0
                    });

                    item.Schuldnerliste.Add(new Schuld {
                        Schuldner = newperson.Name,
                        Value = 0
                    });
                }
                personlist.Add(newperson);
                SortPersonList(personlist);
                return true;
            }
            return false;
        }

        private void SortPersonList(List<Person> personlist)
        {
            personlist.Sort();

            foreach (var item in personlist)
            {
                item.Schuldnerliste.Sort();
            }
        }


        private Person PersonExist(List<Person> personlist, string name)
        {
            Person foundPerson = personlist.FirstOrDefault(p => p.Name.Equals(name));
            return foundPerson;

        }

        private Schuld SchuldExist(Person person, string name)
        {
            Schuld foundSchuld = person.Schuldnerliste.FirstOrDefault(p => p.Schuldner.Equals(name));
            return foundSchuld;

        }

    }
}
