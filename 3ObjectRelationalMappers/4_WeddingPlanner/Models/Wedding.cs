using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingID { get; set; }

        [Required]
        public string WedderOne { get; set; }

        [Required]
        public string WedderTwo { get; set; }

        [Required]
        public DateTime DateOfEvent { get; set; }

        [Required]
        public string Address { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }

        // These will get set to a User in the controller upon validation success after creation of the Wedding if the Wedding was created by that User.
        public int UserID { get; set; }

        public User Creator { get; set; }

        // The below will tie Events to Wedding in a many-to-many:
        public List<Event> Events { get; set; }
    }
}