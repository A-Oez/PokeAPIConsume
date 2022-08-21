using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPIConsume.Models.Location_Model
{

    public class GetSpecificLocation
    {
        public Area[] areas { get; set; }
        public Game_Indices[] game_indices { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public NameSpecific[] names { get; set; }
        public Region region { get; set; }
    }

    public class Region
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Area
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Game_Indices
    {
        public int game_index { get; set; }
        public GenerationSpecific generation { get; set; }
    }

    public class GenerationSpecific
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class NameSpecific
    {
        public LanguageSpecific language { get; set; }
        public string name { get; set; }
    }

    public class LanguageSpecific
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
