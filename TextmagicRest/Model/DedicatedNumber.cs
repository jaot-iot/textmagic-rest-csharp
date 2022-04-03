using System;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    public enum DedicatedNumberStatus
    {
        Active = 'A',
        Unused = 'U'
    }

    /// <summary>
    /// Dedicated number class
    /// </summary>
    public class DedicatedNumber : BaseModel
    {
        /// <summary>
        /// Dedicated number ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Dedicated number assignee
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Dedicated number purchase date
        /// </summary>
        public DateTime? PurchasedAt { get; set; }

        /// <summary>
        /// Dedicated number expiration date
        /// </summary>
        public DateTime? ExpireAt { get; set; }

        /// <summary>
        /// Dedicated phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Dedicated number country
        /// </summary>
        public Country Country { get; set; }

        [JsonPropertyName("status")]
        public char StatusChar { get; set; }
        /// <summary>
        /// Dedicated number status
        /// </summary>
        [JsonPropertyName("fake-unused-name")]
        public DedicatedNumberStatus Status
        {
            get { return (DedicatedNumberStatus)StatusChar; }
            set { StatusChar = value.ToString()[0]; }
        }
    }
}
