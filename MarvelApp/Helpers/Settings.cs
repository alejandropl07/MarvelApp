using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarvelApp.Helpers
{
    public static class Settings

    {
        private const string baseAdress = "baseAdress";

        private const string apiKey = "apiKey";

        private const string hash = "hash";

        private static readonly string stringDefault = string.Empty;

        private static ISettings AppSettings => CrossSettings.Current;

        public static string BaseAdress

        {
            get => AppSettings.GetValueOrDefault(baseAdress, stringDefault);

            set => AppSettings.AddOrUpdateValue(baseAdress, value);

        }

        public static string ApiKey

        {

            get => AppSettings.GetValueOrDefault(apiKey, stringDefault);

            set => AppSettings.AddOrUpdateValue(apiKey, value);

        }

        public static string Hash

        {

            get => AppSettings.GetValueOrDefault(hash, stringDefault);

            set => AppSettings.AddOrUpdateValue(hash, value);

        }

    }
}
