using GalaSoft.MvvmLight.Command;
using MarvelApp.Helpers;
using MarvelApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;

namespace MarvelApp.ViewModels
{
    public class HeroesViewModel : BaseViewModel
    {
        static HttpClient client = new HttpClient();
        public ICommand FindHeroeCommand => new RelayCommand(this.LoadHeroes);

        private int heroeId;
        public int HeroeId { get { return this.heroeId; } set { this.SetValue(ref this.heroeId, value); } }
        private bool isLoading;
        public bool IsLoading { get { return this.isLoading; } set { this.SetValue(ref this.isLoading, value); } }
        private List<Results> myHeroes;
        private ObservableCollection<HeroeItemViewModel> heroes;
        public ObservableCollection<HeroeItemViewModel> Heroes
        {
            get { return this.heroes; }
            set
            {
                this.SetValue(ref this.heroes, value);
            }
        }

        public HeroesViewModel()
        {
            this.HeroeId = 1009368;
            this.LoadHeroes();
            Settings.BaseAdress = "https://gateway.marvel.com:443/v1/public/characters/";
            Settings.ApiKey = "f90d1921cc86b26b35303ebc402b418d";
            Settings.Hash = "4b32f86977fef557a09571e0e4d4f70b";
        }

        public async void LoadHeroes()
        {
            try
            {
                this.IsLoading = true;
                string baseAdress = Settings.BaseAdress;
                string id = this.HeroeId.ToString();
                string apiKey = Settings.ApiKey;
                string ts = "1";
                string hash = Settings.Hash;

                Uri RequestUri = new Uri("" + baseAdress + "" + id + "?apikey=" + apiKey + "&ts=" + ts + "&hash=" + hash + "");

                HttpResponseMessage response = await client.GetAsync(RequestUri);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    var des = (Response)JsonConvert.DeserializeObject(result, typeof(Response));

                    this.myHeroes = (List<Results>)des.data.results;

                    this.IsLoading = false;
                    this.RefreshHeroesList();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Personaje no encontrado", "Aceptar");
                }
                this.IsLoading = false;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error de conexión", ex.Message, "Aceptar");
                this.IsLoading = false;
            }
        }

        private void RefreshHeroesList()
        {
            this.Heroes = new ObservableCollection<HeroeItemViewModel>(this.myHeroes.Select(
                h => new HeroeItemViewModel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Description = h.Description,
                }).ToList());
        }
    }
}
