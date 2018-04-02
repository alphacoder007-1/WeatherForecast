using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ESDAssignment.Models;
using System.Threading.Tasks;


namespace ESDAssignment.API.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PlacesController : ApiController
    {
        string strPlacesAPI = "https://maps.googleapis.com/maps/api/place/autocomplete/json?input={{pred}}&types=(cities)&key=AIzaSyB1UXBM2YIZBBZbzETM6psPtmM27R4QN0E";

        string strPointsOfInterestsAPI = "https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={{latlong}}&radius=500&type=point_of_interest&key=AIzaSyB1UXBM2YIZBBZbzETM6psPtmM27R4QN0E";

        string strPOIByCityAPI = "https://maps.googleapis.com/maps/api/geocode/json?address={{City}},{{State}}&key=AIzaSyB1UXBM2YIZBBZbzETM6psPtmM27R4QN0E";
        

        public PlacesController()
        {

        }

        public async Task<List<PlacesModel>> GetPlacesPredictions(string input)
        {

            HttpClient client = new HttpClient();
            PredictionsModel predictionsModel = new PredictionsModel();
            HttpResponseMessage placesResponse;


            strPlacesAPI = strPlacesAPI.Replace("{{pred}}", input);

            placesResponse = client.GetAsync(strPlacesAPI).Result;

            if (placesResponse.IsSuccessStatusCode)
            {
                predictionsModel = await placesResponse.Content.ReadAsAsync<PredictionsModel>();
            }

           
            PlacesModel placesModel;
            List<PlacesModel> placesList = new List<PlacesModel>();

            foreach (Prediction p in predictionsModel.predictions)
            {
                placesModel = new PlacesModel();
                placesModel.description = p.description;
                placesList.Add(placesModel);
            }

            return placesList;
        }


        public async Task<List<POIResultModel>> GetPointsOfInterests(string latlong)
        {

            HttpClient client = new HttpClient();
            PointOfInterestModel pointOfInterestModel = new PointOfInterestModel();
            HttpResponseMessage poiResponse;
            HttpResponseMessage poiPlaceIDResponse;
            POIPlacesModel objPOIPlacesModel;

            List<POIPlacesModel> objPOIPlacesModelList = new List<POIPlacesModel>();

            strPointsOfInterestsAPI = strPointsOfInterestsAPI.Replace("{{latlong}}", latlong);

            poiResponse = client.GetAsync(strPointsOfInterestsAPI).Result;

            if (poiResponse.IsSuccessStatusCode)
            {
                pointOfInterestModel = await poiResponse.Content.ReadAsAsync<PointOfInterestModel>();
                List<Result> objResult = pointOfInterestModel.results;

                foreach (Result res in objResult)
                {
                    string strPOIPlacesAPI = "https://maps.googleapis.com/maps/api/place/details/json?placeid={{Placeid}}&key=AIzaSyB1UXBM2YIZBBZbzETM6psPtmM27R4QN0E";

                    objPOIPlacesModel = new POIPlacesModel();
                    strPOIPlacesAPI = strPOIPlacesAPI.Replace("{{Placeid}}", res.place_id);
                    poiPlaceIDResponse = client.GetAsync(strPOIPlacesAPI).Result;
                    objPOIPlacesModel = await poiPlaceIDResponse.Content.ReadAsAsync<POIPlacesModel>();

                    objPOIPlacesModelList.Add(objPOIPlacesModel);
                }
            }

            POIResultModel resultModel ;

            List<POIResultModel> resultModelList = new List<POIResultModel>();

            foreach (POIPlacesModel objModel in objPOIPlacesModelList)
            {
                resultModel = new POIResultModel();
                resultModel.name = objModel.result.name;
                resultModel.icon = objModel.result.icon;
                resultModel.website = objModel.result.website;
                resultModelList.Add(resultModel);
            }

            return resultModelList;
        }

        public async Task<List<POIResultModel>> GetPointsOfInterests(string city, string state)
        {

            HttpClient client = new HttpClient();
            PointOfInterestModel pointOfInterestModel = new PointOfInterestModel();
            HttpResponseMessage poiResponse;
          

            List<POIPlacesModel> objPOIPlacesModelList = new List<POIPlacesModel>();

            strPOIByCityAPI = strPOIByCityAPI.Replace("{{City}}", city).Replace("{{State}}",state);

            poiResponse = client.GetAsync(strPOIByCityAPI).Result;

            List<POIResultModel> resultModelList = new List<POIResultModel>();

            if (poiResponse.IsSuccessStatusCode)
            {
                POIByCityModel poiByCityModel = await poiResponse.Content.ReadAsAsync<POIByCityModel>();

                List<Result> resModelList = new List<Result>();

                resModelList = poiByCityModel.results;

                

                foreach (Result resModel in resModelList)
                {
                    Geometry geometry = resModel.geometry;

                    Location loc = geometry.location;

                    string lat = Convert.ToString(loc.lat);
                    string lng = Convert.ToString(loc.lng);

                    string latlong = Convert.ToString(lat + ',' + lng);
                    ////////////////

                    resultModelList = await GetPointsOfInterests(latlong);

                }
                
            }

            return  resultModelList;

        }



        // GET: api/Places
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Places/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Places
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Places/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Places/5
        public void Delete(int id)
        {
        }
    }
}
