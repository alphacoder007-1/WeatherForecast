using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESDAssignment.Models
{

    public class POIByCityModel
    {
        public POIByCityModel()
        {
            this.results = new List<Result>();
        }

        public List<Result> results { get; set; }
        public string status { get; set; }

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
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Bounds
        {
            public Bounds()
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
                this.bounds = new Bounds();
                this.location = new Location();
                this.viewport = new Viewport();

            }
            public Bounds bounds { get; set; }
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }
    }

}
