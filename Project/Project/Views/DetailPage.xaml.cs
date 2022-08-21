using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public Breed breed { get; set; }

        public DetailPage(Breed selectedBreed)
        {
            InitializeComponent();

            breed = selectedBreed;
            ShowBreedDetails(selectedBreed);
        }

        private void ShowBreedDetails(Breed breed)
        {
            lblBreedName.Text = breed.Name;
            lblBreedDescription.Text = breed.Description;
            lblBreedTemperament.Text = breed.Temperament;
            lblBreedLifespan.Text = "Lifespan: " + breed.LifeSpan;
            lblBreedAffectionlevel.Text = "Affectionlevel: " + breed.AffectionLevel.ToString();
            lblBreedChildFriendly.Text = "Child friendly: " + breed.ChildFriendly.ToString();
            lblBreedDogFriendly.Text = "Dog friendly: " + breed.DogFriendly.ToString();
            lblBreedEnergyLevel.Text = "Energy level: " + breed.EnergyLevel.ToString();
            lblBreedIntelligence.Text = "Intelligence: " + breed.Intelligence.ToString();
            lblBreedStrangerFriendly.Text = "Stranger friendly: " + breed.StrangerFriendly.ToString();
            imgBreed.Source = $"https://cdn2.thecatapi.com/images/{breed.Image}.jpg";
        }

        private void btnUpdateBrewery_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}