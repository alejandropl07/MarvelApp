using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.Models
{
    public class Results
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Modified { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public string ResourceURI { get; set; }
        public Comics Comics { get; set; }
        public Series Series { get; set; }
        public Stories Stories { get; set; }
        public Events Events { get; set; }
        public IList<Urls> Urls { get; set; }

        //public Heroe(int id, string name, string description)
        //{
        //    this.Id = id;
        //    this.Name = name;
        //    this.Description = description;
        //}

    }
}
