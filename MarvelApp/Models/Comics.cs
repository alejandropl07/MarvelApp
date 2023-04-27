using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.Models
{
    public class Comics
    {
        public int available { get; set; }
        public string collectionURI { get; set; }
        public IList<Items> items { get; set; }
        public int returned { get; set; }

    }
}
