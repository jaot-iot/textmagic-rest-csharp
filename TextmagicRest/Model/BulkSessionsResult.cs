using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of BulkSession objects
    /// </summary>
    public class BulkSessionsResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<BulkSession> BulkSessions { get; set; }
    }
}
