using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of Subaccounts
    /// </summary>
    public class UserResults : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<User> Subaccounts { get; set; }
    }
}