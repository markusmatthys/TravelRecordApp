using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using TravelRecordApp.Model;
using System.Security.Cryptography;

namespace TravelRecordApp
{
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                //var postTable = conn.Table<Post>().ToList();
                //Two different ways to make a query (categories and categories2)
                ////way 1
                //var categories = (from p in postTable
                //                  orderby p.CategoryId
                //                  select p.CategoryName).Distinct().ToList();

                //way 2
                var postTable = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();
                var categories = postTable.OrderBy(p => p.CategoryId).Select(p => p.CategoryName).Distinct().ToList();

                Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
                foreach(var category in categories)
                {
                    ////Two different ways to make a query (count and count2)
                    ////way 1
                    //var count = (from post in postTable
                    //             where post.CategoryName == category
                    //             select post).ToList().Count;
                    
                    //way 2
                    var count = postTable.Where(p => p.CategoryName == category).ToList().Count;

                    categoriesCount.Add(category, count);
                }

                categoriesListView.ItemsSource = categoriesCount;

                postCountLabel.Text = postTable.Count.ToString();
            }
        }
    }
}
