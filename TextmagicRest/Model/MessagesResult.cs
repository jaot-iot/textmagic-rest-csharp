using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of Message objects
    /// </summary>
    public class MessagesResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<Message> Messages { get; set; }
    }
}
