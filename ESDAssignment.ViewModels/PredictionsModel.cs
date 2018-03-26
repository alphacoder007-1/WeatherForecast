using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESDAssignment.Models
{
    public class AutoPlacesModel
    {
        public AutoPlacesModel()
        {
            this.desc = new List<string>();
        }

        public List<string> desc { get; set; }
    }

    public class PlacesModel
    {
        public string description { get; set; }
    }


    public class Prediction
    {
        public string description { get; set; }
        public string id { get; set; }
        public IList<MatchedSubstring> matched_substrings { get; set; }
        public string place_id { get; set; }
        public string reference { get; set; }
        public StructuredFormatting structured_formatting { get; set; }
        public IList<Term> terms { get; set; }
        public IList<string> types { get; set; }
    }

    public class StructuredFormatting
    {
        public string main_text { get; set; }
        public IList<MainTextMatchedSubstring> main_text_matched_substrings { get; set; }
        public string secondary_text { get; set; }
    }
    public class Term
    {
        public int offset { get; set; }
        public string value { get; set; }
    }

    public class MatchedSubstring
    {
        public int length { get; set; }
        public int offset { get; set; }
    }

    public class MainTextMatchedSubstring
    {
        public int length { get; set; }
        public int offset { get; set; }
    }

    public class PredictionsModel
    {
        public PredictionsModel()
        {
            this.predictions = new List<Prediction>();
        }

        public List<Prediction> predictions { get; set; }

        
        public string status { get; set; }


    }
}
