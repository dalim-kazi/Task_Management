using System.ComponentModel.DataAnnotations;

namespace Task_Management.Models.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public int answerId { get; set; }
        public string? role { get; set; }
    }
}
