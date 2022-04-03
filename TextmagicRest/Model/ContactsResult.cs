using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of Contact objects
    /// </summary>
    public class ContactsResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<Contact> Contacts { get; set; }
    }
}
