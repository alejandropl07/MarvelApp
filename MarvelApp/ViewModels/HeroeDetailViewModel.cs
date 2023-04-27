using MarvelApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.ViewModels
{
    public class HeroeDetailViewModel
    {
        public Results Heroe { get; set; }

        public HeroeDetailViewModel(Results heroe)
        {
            this.Heroe = heroe;
        }
    }
}
