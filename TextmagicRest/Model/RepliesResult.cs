using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of Reply objects
    /// </summary>
    public class RepliesResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<Reply> Replies { get; set; }
    }
}
