using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESDAssignment.Models
{
   public  class PointOfInterestModel
    {
        public PointOfInterestModel()
        {
            this.html_attributions = new List<object>();
            this.results = new List<Result>();
        }

        public List<object> html_attributions { get; set; }
        public List<Result> results { get; set; }
        public string status { get; set; }

    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }


    public class Geometry
    {
        public Location location { get; set; }
    }

    public class Result
    {
        public Geometry geometry { get; set; }
        public string id { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
    }
}
