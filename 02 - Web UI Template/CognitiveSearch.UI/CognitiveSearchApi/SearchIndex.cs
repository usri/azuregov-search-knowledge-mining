namespace CognitiveSearch.UI.CognitiveSearchApi
{
    public class SearchIndex
    {
        public string name { get; set; }
        public string defaultScoringProfile { get; set; }
        public Field[] fields { get; set; }
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
