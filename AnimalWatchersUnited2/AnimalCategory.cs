using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalWatchersUnited2
{
    public class AnimalCategory
    {
        public string Id { get; set; }
        public string Category { get; set; }

        public AnimalCategory()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Category = "Not Set";
        }
    }
}
