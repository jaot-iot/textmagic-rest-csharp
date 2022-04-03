using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// Chats list
    /// </summary>
    public class ChatsResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<Chat> Chats { get; set; }
    }
}
