using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of Schedule resources
    /// </summary>
    public class SchedulesResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<Schedule> Schedules { get; set; }
    }
}
