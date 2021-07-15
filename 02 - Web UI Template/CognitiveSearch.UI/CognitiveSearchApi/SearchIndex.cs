using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CognitiveSearch.UI.CognitiveSearchApi
{
    public class SearchIndex
    {
        public string name { get; set; }
        public string defaultScoringProfile { get; set; }
        public Field[] fields { get; set; }

        //todo: optional index properties
        //public {} similarity { get; set; }
        //public {} suggesters { get; set; }
        //public {} scoringProfiles { get; set; }
        //public {} analyzers { get; set; }
        //public {} charFilters { get; set; }
        //public {} tokenizers { get; set; }
        //public {} tokenFilters { get; set; }
       
        //public {} corsOptions { get; set; }
        //public {} encryptionKey { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string type { get; set; }
        public bool searchable { get; set; }
        public bool filterable { get; set; }
        public bool retrievable { get; set; }
        public bool sortable { get; set; }
        public bool facetable { get; set; }
        public bool key { get; set; }
        public string indexAnalyzer { get; set; }
        public string searchAnalyzer { get; set; }
        public string analyzer { get; set; }
        public string[] synonymMaps { get; set; }
    }
}
