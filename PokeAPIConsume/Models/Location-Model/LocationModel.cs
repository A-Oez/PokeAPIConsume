using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPIConsume.Models.Location_Model
{
    public class LocationModel
    {
        public int id { get; set; }
        public string location { get; set; }
        public int countLocationArea { get; set; }

        public LocationModel(int id, string location, int countLocationArea)
        {
            this.id = id;
            this.location = location;
            this.countLocationArea = countLocationArea;
        }

    }
}
