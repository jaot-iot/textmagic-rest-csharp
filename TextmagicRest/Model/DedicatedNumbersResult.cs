using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of DedicatedNumber objects
    /// </summary>
    public class DedicatedNumbersResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<DedicatedNumber> DedicatedNumbers { get; set; }
    }
}
