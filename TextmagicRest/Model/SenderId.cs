using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    public enum SenderIdStatus
    {
        Active = 'A',
        Pending = 'P',
        Rejected = 'R'
    }

    public class SenderId : BaseModel
    {
        /// <summary>
        /// Sender ID numeric ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Alphanumeric Sender ID itself
        /// </summary>
        [JsonPropertyName("senderId")]
        public string Name { get; set; }

        /// <summary>
        /// User who applied for this Sender ID
        /// </summary>
        public User User { get; set; }

        [JsonPropertyName("status")]
        public char StatusChar { get; set; }
        /// <summary>
        /// Dedicated number status
        /// </summary>
        [JsonPropertyName("fake-unused-name")]
        public SenderIdStatus Status
        {
            get { return (SenderIdStatus)StatusChar; }
            set { StatusChar = value.ToString()[0]; }
        }
    }
}
