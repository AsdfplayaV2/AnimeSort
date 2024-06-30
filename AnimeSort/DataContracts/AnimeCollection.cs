using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeSort.DataContracts
{
    public class AnimeCollection
    {
        public string Name { get; set; }
        public HashSet<string> FileList { get; set; }

        public AnimeCollection(string Name)
        {
            this.Name = Name;
            FileList = new();
        }
    }
}
