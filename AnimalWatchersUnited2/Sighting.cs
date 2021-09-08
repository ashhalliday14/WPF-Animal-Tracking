using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalWatchersUnited2
{
    public class Sighting : Animal
    {
        public string SightingLocation { get; set; }
        public int Size { get; set; }
        public int Quantity { get; set; }
        public string Sex { get; set; }
    }
}
