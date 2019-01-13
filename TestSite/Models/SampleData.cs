using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestSite.Models {

    public class SampleData {

        public List<Country> Countries { get; set; }
        public List<Person> People { get; set; }
        public int SelectedID { get; set; }
        public int SelectedCountryID { get; set; }
        public string SelectedName { get; set; }

        public SampleData() {
            Countries = new List<Country>();
            People = new List<Person>();

            Countries.Add(new Country(1, "United Kingdom"));
            Countries.Add(new Country(2, "United States"));
            Countries.Add(new Country(3, "Republic of Ireland"));
            Countries.Add(new Country(4, "India"));


            People.Add(new Person(1, 1, "AJSON"));
            People.Add(new Person(2, 2, "Fred"));
            People.Add(new Person(3, 2, "Mary"));
        }

        public void SetSelected(int ID) {
            var p = People.SingleOrDefault(x => x.ID == ID);
            if (p == null) { return; }
            this.SelectedID = p.ID;
            this.SelectedCountryID = p.Nationality;
            this.SelectedName = p.Name;
        }

    }

    public class Person {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Nationality { get; set; }

        public Person(int id, int nationality, string name) {
            ID = id;
            Nationality = nationality;
            Name = name;
        }
    }

    public class Country {
        public int ID { get; set; }
        public string Name { get; set; }

        public Country(int id, string name) {
            ID = id;
            Name = name;
        }
    }
}
