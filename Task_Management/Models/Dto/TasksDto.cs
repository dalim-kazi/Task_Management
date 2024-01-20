using System.ComponentModel.DataAnnotations;

namespace Task_Management.Models.Dto
{
    public class TasksDto
    {
        public int Id { get; set; }

        public DateTime dateTime { get; set; } = DateTime.Now;

        public string? title { get; set; }

        public string? Status { get; set; }

        public string? category { get; set; }

        public string? quesstion1 { get; set; }

        public string? quesstion2 { get; set; }

        public string? quesstion3 { get; set; }

        public string? quesstion4 { get; set; }

        public string? RightAnswer { get; set; }
    }
}
