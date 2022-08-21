using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPIConsume.Models.Location_Model
{

    public class GetLocationArea
    {
        public Encounter_Method_Rates[] encounter_method_rates { get; set; }
        public int game_index { get; set; }
        public int id { get; set; }
        public LocationArea location { get; set; }
        public string name { get; set; }
        public NameArea[] names { get; set; }
        public Pokemon_Encounters[] pokemon_encounters { get; set; }
    }

    public class LocationArea
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Encounter_Method_Rates
    {
        public Encounter_Method encounter_method { get; set; }
        public Version_Details[] version_details { get; set; }
    }

    public class Encounter_Method
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version_Details
    {
        public int rate { get; set; }
        public Version version { get; set; }
    }

    public class Version
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class NameArea
    {
        public LanguageArea language { get; set; }
        public string name { get; set; }
    }

    public class LanguageArea
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Pokemon_Encounters
    {
        public Pokemon pokemon { get; set; }
        public Version_Details1[] version_details { get; set; }
    }

    public class Pokemon
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Version_Details1
    {
        public Encounter_Details[] encounter_details { get; set; }
        public int max_chance { get; set; }
        public Version1 version { get; set; }
    }

    public class Version1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Encounter_Details
    {
        public int chance { get; set; }
        public object[] condition_values { get; set; }
        public int max_level { get; set; }
        public Method method { get; set; }
        public int min_level { get; set; }
    }

    public class Method
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
