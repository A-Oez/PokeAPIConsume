using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPIConsume.Models.Location_Model
{

    public class GetLocation
    {
        public int id { get; set; }
        public Location[] locations { get; set; }
        public Main_Generation main_generation { get; set; }
        public string name { get; set; }
        public Name[] names { get; set; }
        public Pokedex[] pokedexes { get; set; }
        public Version_Groups[] version_groups { get; set; }
    }

    public class Main_Generation
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Location
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Name
    {
        public Language language { get; set; }
        public string name { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Pokedex
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version_Groups
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
