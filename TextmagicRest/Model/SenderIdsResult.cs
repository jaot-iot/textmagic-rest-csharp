using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of SenderId objects
    /// </summary>
    public class SenderIdsResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<SenderId> SenderIds { get; set; }
    }
}
