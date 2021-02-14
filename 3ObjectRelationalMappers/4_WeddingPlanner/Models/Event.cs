using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        public int UserID { get; set; }

        public int WeddingID { get; set; }

        public User User { get; set; }

        public Wedding Wedding { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }
}