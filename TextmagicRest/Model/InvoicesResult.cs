using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    /// <summary>
    /// List of Invoice resources
    /// </summary>
    public class InvoicesResult : BaseModelList
    {
        [JsonPropertyName("resources")]
        public List<Invoice> Invoices { get; set; }
    }
}
