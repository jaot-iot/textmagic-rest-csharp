using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of Schedule resources
    /// </summary>
    public class SpendingStatsResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<SpendingStats> SpendingStats { get; set; }
    }
}
