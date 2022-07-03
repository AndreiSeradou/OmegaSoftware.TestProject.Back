﻿using System.ComponentModel.DataAnnotations;

namespace DataCollectionAndEmailMessageApplication.Web.Models.DTOs
{
    public class FootballSubscriptionPLModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CronParams { get; set; }
        public DateTime LastRunTime { get; set; }
        public int UserName { get; set; }
    }
}
