using MarvelApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.ViewModels
{
    public class HeroeDetailViewModel
    {
        public Heroe Heroe { get; set; }

        public HeroeDetailViewModel(Heroe heroe)
        {
            this.Heroe = heroe;
        }
    }
}
