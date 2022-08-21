using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPIConsume.Models
{
    public class PokemonModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<string> types{ get; set; }

        public PokemonModel(int id, string name, List<string> types)
        {
            this.id = id;
            this.name = name;
            this.types = types;
        }
    }
}
