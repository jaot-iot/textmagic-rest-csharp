﻿using System;
using System.Text.Json.Serialization;

namespace TextmagicRest.Model
{
    public enum BulkSessionStatus
    {
        NotStarted = 'n',
        InProgress = 'w',
        Completed = 'c',
        Failed = 'f'
    }

    /// <summary>
    /// Bulk sending session class
    /// </summary>
    public class BulkSession : BaseModel
    {
        /// <summary>
        /// Bulk session ID
        /// </summary>
        public int Id { get; set; }

        [JsonPropertyName("status")]
        public char StatusChar { get; set; }
        /// <summary>
        /// Bulk session status
        /// </summary>
        [JsonPropertyName("fake-unused-name")]
        public BulkSessionStatus Status
        {
            get { return (BulkSessionStatus)StatusChar; }
            set { StatusChar = value.ToString()[0]; }
        }

        /// <summary>
        /// How many items (messages) processed during this session
        /// </summary>
        public int ItemsProcessed { get; set; }

        /// <summary>
        /// How many items (messages) total
        /// </summary>
        public int ItemsTotal { get; set; }

        /// <summary>
        /// Bulk session date creation
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Session text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Messages session (if already created)
        /// </summary>
        public Session Session { get; set; }
    }
}
