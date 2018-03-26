using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESDAssignment.Models
{
    public class POIPlacesModel
    {
        public POIPlacesModel()
        {
            this.html_attributions = new List<object>();
            this.result = new Result();
        }


        public List<object> html_attributions { get; set; }
        public Result result { get; set; }
        public string status { get; set; }

        public class AddressComponent
        {
            public AddressComponent()
            {
                this.types = new List<string>();
            }
            
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Viewport
        {
            public Viewport()
            {
                this.northeast = new Northeast();
                this.southwest = new Southwest();
            }
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Geometry
        {
            public Geometry()
            {
                this.location = new Location();
                this.viewport = new Viewport();
            }

            public Location location { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Photo
        {
            public Photo()
            {
                this.html_attributions = new List<string>();
            }
            public int height { get; set; }
            public List<string> html_attributions { get; set; }
            public string photo_reference { get; set; }
            public int width { get; set; }
        }

        public class Review
        {
            public string author_name { get; set; }
            public string author_url { get; set; }
            public string language { get; set; }
            public string profile_photo_url { get; set; }
            public int rating { get; set; }
            public string relative_time_description { get; set; }
            public string text { get; set; }
            public int time { get; set; }
        }

        public class Result
        {
            public Result()
            {
                this.address_components = new List<AddressComponent>();
                this.geometry = new Geometry();
                this.photos = new List<Photo>();
                this.reviews = new List<Review>();
                this.types = new List<string>();

            }
            public List<AddressComponent> address_components { get; set; }
            public string adr_address { get; set; }
            public string formatted_address { get; set; }
            public string formatted_phone_number { get; set; }
            public Geometry geometry { get; set; }
            public string icon { get; set; }
            public string id { get; set; }
            public string international_phone_number { get; set; }
            public string name { get; set; }
            public List<Photo> photos { get; set; }
            public string place_id { get; set; }
            public double rating { get; set; }
            public string reference { get; set; }
            public List<Review> reviews { get; set; }
            public string scope { get; set; }
            public List<string> types { get; set; }
            public string url { get; set; }
            public int utc_offset { get; set; }
            public string vicinity { get; set; }
            public string website { get; set; }
        }


    }
}
