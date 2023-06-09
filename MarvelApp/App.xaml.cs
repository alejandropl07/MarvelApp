﻿using MarvelApp.ViewModels;
using MarvelApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarvelApp
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public App()
        {
            InitializeComponent();

            MainViewModel.GetInstance().Heroes = new HeroesViewModel();
            this.MainPage = new NavigationPage(new HeroesPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
