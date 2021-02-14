using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpExam.Models
{
    public class Idea
    {
        [Key]
        public int IdeaID { get; set; }

        [Required]
        [MinLength(5)]
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // These will get set to a User in the controller upon validation success after creation of the Idea if the Idea was created by that User.
        public int UserID { get; set; }

        public User Creator { get; set; }

        // The below will tie Idea to User in a many-to-many via Like:
        public List<Like> Likes { get; set; }
    }
}