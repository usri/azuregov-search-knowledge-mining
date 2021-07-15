using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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

        public string format { get; set; }

        [Required()]
        public string synonyms { get; set; }

        public string encryptionKey { get; set; }
    }
}
