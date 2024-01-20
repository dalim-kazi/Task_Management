using System.ComponentModel.DataAnnotations;

namespace Task_Management.Models
{
    public class Tasks_management
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime dateTime { get; set; }= DateTime.Now;

        [Required]
        public string? title { get; set; }

        public string? status { get; set; }

        public string? category { get; set; }

        [Required]
        public string? quesstion1 { get; set; }

        [Required]
        public string? quesstion2 { get; set; }

        [Required]
        public string? quesstion3 { get; set; }

        [Required]
        public string? quesstion4 { get; set; }

        [Required]
        public string? RightAnswer { get; set; }
    }
}
