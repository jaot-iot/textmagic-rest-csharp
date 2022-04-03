using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// Contact custom fields list
    /// </summary>
    public class CustomFieldsResult
    {
        [JsonPropertyName("resources")]
        public List<CustomField> CustomFields { get; set; }
    }
}
