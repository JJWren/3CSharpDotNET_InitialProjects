using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpExam.Models
{
    public class Like
    {
        [Key]
        public int LikeID { get; set; }

        public int UserID { get; set; }

        public int IdeaID { get; set; }

        public User User { get; set; }

        public Idea Idea { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}