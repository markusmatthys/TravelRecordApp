﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using System.Text;
using System.ComponentModel;
using Newtonsoft.Json;

namespace TravelRecordApp.Model
{
    public class Post : INotifyPropertyChanged
    {
        //[PrimaryKey, AutoIncrement]
        private string id;

        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        //[MaxLength(250)]
        private string expirence;

        public string Experience
        {
            get { return expirence; }
            set
            {
                expirence = value;
                OnPropertyChanged("Experience");
            }
        }

        private string venueName;

        public string VenueName
        {
            get { return venueName; }
            set
            {
                venueName = value;
                OnPropertyChanged("VenueName");
            }
        }

        private string categoryId;

        public string CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }

        private string categoryName;

        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set
            {

                address = value;
                OnPropertyChanged("Address");
            }
        }

        private float latitude;

        public float Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        private float longitude;

        public float Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        private int distance;

        public int Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static async void Insert(Post post)
        {
            await App.MobileService.GetTable<Post>().InsertAsync(post);
        }

        public static async Task<List<Post>> Read()
        {
            var posts = await App.MobileService.GetTable<Post>().Where(p => p.UserId == App.user.Id).ToListAsync();

            return posts;
        }

        public static Dictionary<string, int> PostCategories(List<Post> posts)
        {
            var categories = (from p in posts
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
            foreach (var category in categories)
            {
                var count = (from post in posts
                             where post.CategoryName == category
                             select post).ToList().Count;

                categoriesCount.Add(category, count);
            }

            return categoriesCount;
        }

        private Venue venue;

        [JsonIgnore]

        public Venue Venue
        {
            get { return venue; }
            set {
                venue = value;

                if (venue.categories != null)
                {
                    var firstCategory = venue.categories.FirstOrDefault();
                    if (firstCategory != null)
                    {
                        CategoryId = firstCategory.id;
                        CategoryName = firstCategory.name;
                    }
                }

                if (venue.location != null)
                {
                    Address = venue.location.address;
                    Distance = venue.location.distance;
                    Latitude = venue.location.lat;
                    Longitude = venue.location.lng;
                }
                VenueName = venue.name;
                UserId = App.user.Id;

                OnPropertyChanged("Venue");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
