using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CognitiveSearch.UI.CognitiveSearchApi
{
    public class SynonymMap
    {
        public string name { get; set; }
        public string format { get; set; }
        public string synonyms { get; set; }
        public string encryptionKey { get; set; }
    }
}
