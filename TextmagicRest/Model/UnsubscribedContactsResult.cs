using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of UnsubscribedContact objects
    /// </summary>
    public class UnsubscribedContactsResult
    {
        [JsonPropertyName("resources")]
        public List<UnsubscribedContact> UnsubscribedContacts { get; set; }
    }
}
