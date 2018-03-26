using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESDAssignment.Models
{
   public class WeatherModel
    {
        
        public string weekday { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string conditions { get; set; }
        public string icon_url { get; set; }
    }

    public class City
    {
        public string Name { get; set; }
        public string State { get; set; }
    }

    public class WeatherForecastModel
    {
        public WeatherForecastModel()
        {
            this.weatherModel = new List<WeatherModel>();
            this.city = new City();
        }

        public List<WeatherModel> weatherModel { get; set; }
        public City city { get; set; }
       
    }

}

