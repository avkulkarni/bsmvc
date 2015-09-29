namespace BsMvc.Widgets.Grid.GridExt
{
    using Newtonsoft.Json;

    internal class Editable
    {
        [JsonProperty("title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _title;

        [JsonProperty("type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _type;

        [JsonProperty("container", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _container;

        [JsonProperty("validate", DefaultValueHandling = DefaultValueHandling.Ignore)]
        private string _validate;

        internal Editable(string type, string title, string validate = null, string container = "body")
        {
            this._type = type;
            this._title = title;
            this._container = container;
            this._validate = validate;
        }
    }
}
