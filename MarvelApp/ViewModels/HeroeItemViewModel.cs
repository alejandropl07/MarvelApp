using GalaSoft.MvvmLight.Command;
using MarvelApp.Models;
using MarvelApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MarvelApp.ViewModels
{
    public class HeroeItemViewModel : Heroe
    {
        public ICommand SelectHeroeCommand => new RelayCommand(this.SelectHeroe);
        private async void SelectHeroe()
        {
            MainViewModel.GetInstance().HeroeDetail = new HeroeDetailViewModel(this);
            await App.Navigator.PushAsync(new HeroeDetailPage());
        }
    }
}
