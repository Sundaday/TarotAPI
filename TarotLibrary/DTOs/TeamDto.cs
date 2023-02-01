using TarotAPI.Models;

namespace TarotAPI.DTOs
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Damage { get; set; }
        public int UserId { get; set; } = 0;
    }
}