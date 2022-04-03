using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of MessagingStats object
    /// </summary>
    public class MessagingStatsResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<MessagingStats> MessagingStats { get; set; }
    }
}
