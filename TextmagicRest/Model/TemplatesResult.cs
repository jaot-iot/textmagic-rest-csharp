using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of Template objects
    /// </summary>
    public class TemplatesResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<Template> Templates { get; set; }
    }
}
