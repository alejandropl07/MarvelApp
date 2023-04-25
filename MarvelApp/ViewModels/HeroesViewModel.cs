using MarvelApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using Xamarin.Forms;

namespace MarvelApp.ViewModels
{
    public class HeroesViewModel : BaseViewModel
    {
        static HttpClient client = new HttpClient();
        private bool isLoading;
        public bool IsLoading { get { return this.isLoading; } set { this.SetValue(ref this.isLoading, value); } }
        private List<Heroe> myHeroes;
        private ObservableCollection<Heroe> heroes;
        public ObservableCollection<Heroe> Heroes
        {
            get { return this.heroes; }
            set
            {
                this.SetValue(ref this.heroes, value);
            }
        }

        public HeroesViewModel()
        {
            this.LoadHeroes();
        }

        public async void LoadHeroes()
        {
            try
            {
                this.IsLoading = true;
                Uri RequestUri = new Uri("https://gateway.marvel.com:443/v1/public/characters/1009368?apikey=f90d1921cc86b26b35303ebc402b418d&ts=1&hash=4b32f86977fef557a09571e0e4d4f70b");

                HttpResponseMessage response = await client.GetAsync(RequestUri);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();


                    await Application.Current.MainPage.DisplayAlert("Error de conexión", result.ToString(), "Aceptar");

                    //List<Object> list = JsonConvert.
                    //var list = JsonSerializer
                    //this.myHeroes = JsonConvert.DeserializeObject<List<Heroe>>(result);

                    //this.IsLoading = false;
                    //this.RefreshHeroesList();

                    await Application.Current.MainPage.DisplayAlert("Error de conexión", "OKKKKKKKK", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error de conexión", ex.Message, "Aceptar");
            }
        }

        private void RefreshHeroesList()
        {
            //this.Heroes = new ObservableCollection<HeroeDetailViewModel>(this.myHeroes.Select(
            //    h => new HeroeDetailViewModel
            //    {
                    
            //    }).ToList());
        }
    }
}
