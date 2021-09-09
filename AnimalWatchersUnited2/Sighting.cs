using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalWatchersUnited2
{
    public class Sighting : Animal
    {
        public string Username { get; set; }
        public string SightingLocation { get; set; }
        public string Size { get; set; }
        public string Sex { get; set; }
    }
}
