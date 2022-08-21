using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPIConsume.Models
{

    public class PokemonRegion
    {
        public object[] abilities { get; set; }
        public int id { get; set; }
        public Main_Region main_region { get; set; }
        public MoveRegion[] moves { get; set; }
        public string name { get; set; }
        public Name[] names { get; set; }
        public Pokemon_Species[] pokemon_species { get; set; }
        public TypeRegion[] types { get; set; }
        public Version_Groups[] version_groups { get; set; }
    }

    public class Main_Region
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class MoveRegion
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

    public class Pokemon_Species
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class TypeRegion
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
