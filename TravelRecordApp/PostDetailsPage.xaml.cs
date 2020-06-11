using System;
using System.Collections.Generic;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class PostDetailsPage : ContentPage
    {
        Post selectedPost;

        public PostDetailsPage()
        {

        }

        public PostDetailsPage(Post selectedPost)
        {
            InitializeComponent();

            this.selectedPost = selectedPost;

            experienceEntry.Text = selectedPost.Experience;
            venueLabel.Text = selectedPost.VenueName;
            categoryLabel.Text = selectedPost.CategoryName;
            addressLabel.Text = selectedPost.Address;
            coordinatesLabel.Text = $"{selectedPost.Latitude}, {selectedPost.Longitude}";
            distanceLabel.Text = $"{selectedPost.Distance} Meter";

        }
        async void Update_Clicked(object sender, System.EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;

            await App.MobileService.GetTable<Post>().UpdateAsync(selectedPost);
            await DisplayAlert("Success", "Experience succesfully updated", "Ok");
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            await App.MobileService.GetTable<Post>().DeleteAsync(selectedPost);
            await DisplayAlert("Success", "Experience succesfully deleted", "Ok");
        }
    }
}
