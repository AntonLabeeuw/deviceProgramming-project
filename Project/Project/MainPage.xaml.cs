using Project.Models;
using Project.Repositories;
using Project.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Project
{
    public partial class MainPage : ContentPage
    {
        public List<Breed> breeds = new List<Breed>();
        public int selectedEnergyLevel = 0;
        public string selectedCountry = null;
        public List<string> countries = new List<string>();

        public MainPage()
        {
            InitializeComponent();
            //Connectivity.ConnectivityChanged += ConnectivityChangedHandler;
            TestModelsAndRepositories();
            LoadBreeds();
        }

        //private void ConnectivityChangedHandler(object sender, ConnectivityChangedEventArgs e)
        //{
        //    if (e.NetworkAccess.ToString() != "Internet")
        //    {
        //        Navigation.PushAsync(new NoNetwerkPage());
        //    }
        //    else
        //    {
        //        Navigation.PopAsync();
        //    }
        //}

        private async void TestModelsAndRepositories()
        {
            List<Breed> breeds = await CatRepository.GetBreedsAsync();

            foreach (var breed in breeds)
            {
                Debug.WriteLine(breed.Name);
            }
        }

        private async void LoadBreeds()
        {
            breeds = await CatRepository.GetBreedsAsync();
            LoadCountriesFilter(breeds);
            ShowBreeds(breeds);
        }

        private void LoadCountriesFilter(List<Breed> breeds)
        {
            foreach (Breed breed in breeds)
            {
                int inArray = 0;

                foreach (string country in countries)
                {
                    if (breed.Origin.ToLower() == country.ToLower())
                    {
                        inArray = 1;
                    }
                }

                if (inArray == 0)
                {
                    countries.Add(breed.Origin);
                }
            }

            countries.ForEach(country => pickEnergyLevel.Items.Add(country));
        }

        private void ShowBreeds(List<Breed> breeds)
        {
            Debug.WriteLine(selectedCountry);
            if (selectedCountry != null)
            {
                List<Breed> breedsFiltered = new List<Breed>();

                foreach (Breed breed in breeds)
                {
                    if (breed.Origin.ToLower() == selectedCountry)
                    {
                        breedsFiltered.Add(breed);
                    }
                }

                lvwBreeds.ItemsSource = breedsFiltered;
            }
            else
            {
                lvwBreeds.ItemsSource = breeds;
            }
            
        }

        private void pickEnergyLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCountry = pickEnergyLevel.SelectedItem.ToString().ToLower();
            ShowBreeds(breeds);
        }

        private void lvwBreeds_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvwBreeds.SelectedItem != null)
            {
                Breed selectedBreed = (Breed)lvwBreeds.SelectedItem;
                Navigation.PushAsync(new DetailPage(selectedBreed));
                lvwBreeds.SelectedItem = null;
            }
        }

        private void BtnRandomizer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VotingPage());
        }

        private void btnQuoteOrFact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FavouritesPage());
        }
    }
}
