using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of Session resources
    /// </summary>
    public class SessionsResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<Session> Sessions { get; set; }
    }
}
