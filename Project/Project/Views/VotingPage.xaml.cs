using Project.Repositories;
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
    public partial class VotingPage : ContentPage
    {
        private List<ImageClass> image;

        public VotingPage()
        {
            InitializeComponent();
            this.GetImageRequest();
        }

        private async void GetImageRequest()
        {
            image = await CatRepository.GetImagesAsync();
            imgRandomCat.Source = image[0].Url;
        }

        private void btnUpvote_Clicked(object sender, EventArgs e)
        {
            CatRepository.PostVoteAsync(this.image[0].Id, 1);
            CatRepository.PostFavourites(this.image[0].Id);
            DisplayAlert("", "Je hebt deze foto geliket", "OK");
            this.GetImageRequest();
        }

        private void btnDownvote_Clicked(object sender, EventArgs e)
        {
            CatRepository.PostVoteAsync(this.image[0].Id, -1);
            DisplayAlert("", "Je hebt deze foto gedisliket", "OK");
            this.GetImageRequest();
        }

        private void btnNextPicture_Clicked(object sender, EventArgs e)
        {
            this.GetImageRequest();
        }
    }
}