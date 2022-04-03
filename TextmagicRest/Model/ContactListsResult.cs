using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of contact List object
    /// </summary>
    public class ContactListsResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<ContactList> ContactLists { get; set; }
    }
}
