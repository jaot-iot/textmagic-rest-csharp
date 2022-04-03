using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of ChatMessage objects
    /// </summary>
    public class ChatMessagesResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<ChatMessage> Messages { get; set; }
    }
}
