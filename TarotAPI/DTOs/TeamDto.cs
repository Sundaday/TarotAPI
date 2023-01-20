using TarotAPI.Models;

namespace TarotAPI.DTOs
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string? TeamName { get; set; }
        public string? TeamDescription { get; set; }
        public float TeamDamage { get; set; }
        public int UserId { get; set; } = 0;
    }
}