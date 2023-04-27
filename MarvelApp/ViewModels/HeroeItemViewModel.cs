using GalaSoft.MvvmLight.Command;
using MarvelApp.Models;
using MarvelApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MarvelApp.ViewModels
{
    public class HeroeItemViewModel : Results
    {
        public ICommand SelectHeroeCommand => new RelayCommand(this.SelectHeroe);
        private async void SelectHeroe()
        {
            MainViewModel.GetInstance().HeroeDetail = new HeroeDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new HeroeDetailPage());
        }
    }
}
