using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalWatchersUnited2
{
    public class Animal : AnimalCategory
    {
        public string Type { get; set; }
        public string Colour { get; set; }
        public string Origin { get; set; }

        public Animal()
        {
            this.Type = "Not Set";
            this.Colour = "Not Set";
            this.Origin = "Not Set";
        }
    }
}
