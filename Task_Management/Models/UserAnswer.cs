using System.ComponentModel.DataAnnotations;

namespace Task_Management.Models
{
    public class UserAnswer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int answerId { get; set; }
        [Required]
        public string? role { get; set; }
    }
}
