﻿using System.Text.Json.Serialization;


namespace TextmagicRest.Model
{
    public enum AccountStatus
    {
        Active = 'A',
        Trial = 'T'
    }

    public enum SubAccountType
    {
        ParentUser = 'P',
        AdministratorSubAccount = 'A',
        RegularUser = 'U'
    }

    /// <summary>
    /// User account representation class
    /// </summary>
    public class User : BaseModel
    {
        /// <summary>
        /// User ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Account username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Account first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Account last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Account full name
        /// </summary>
        public virtual string Name { get { return FirstName + " " + LastName; } }

        [JsonPropertyName("status")]
        public char StatusChar { get; set; }
        /// <summary>
        /// Current Account Status
        /// </summary>
        [JsonPropertyName("fake-unused-name")]
        public AccountStatus Status
        {
            get { return (AccountStatus)StatusChar; }
            set { StatusChar = value.ToString()[0]; }
        }

        /// <summary>
        /// Account balance, in account currency
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Account Company
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Account currency
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Account timezone
        /// </summary>
        public Timezone Timezone { get; set; }

        [JsonPropertyName("subaccountType")]
        public char AccountChar { get; set; }
        /// <summary>
        /// Type of Account
        /// </summary>
        [JsonPropertyName("fake-unused-name")]
        public SubAccountType SubaccountType
        {
            get { return (SubAccountType)AccountChar; }
            set { AccountChar = value.ToString()[0]; }
        }

    }
}
