using System;
using SQLite;

namespace TravelRecordApp.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }

        [MaxLength(250)]
        public string Experience { get; set; }

        public string VenueName { get; set; }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string Address { get; set; }

        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public int Distance { get; set; }

        public string UserId { get; set; }
    }
}
