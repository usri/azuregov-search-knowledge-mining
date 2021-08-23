using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CognitiveSearch.UI.CognitiveSearchApi
{
    public class SynonymMapList
    {
        [JsonPropertyName("@odata.context")]
        public string context { get; set; }

        public SynonymMap[] value { get; set; }
    }


    public class SynonymMap
    {
        [Required()]
        public string name { get; set; }

        public string format
        {
            //currently solr is the only accepted format
            get { return "solr"; }
        }

        [Required()]
        public string synonyms { get; set; }

        public string encryptionKey { get; set; }

        [IgnoreDataMember]
        public bool isActive { get; set; }
    }
}
