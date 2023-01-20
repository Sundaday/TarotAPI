namespace TarotAPI.DTOs.Post
{
    public class CreateTeamDto
    {
        public string? TeamName { get; set; }
        public string? TeamDescription { get; set; }
        public float TeamDamage { get; set; }
        public int UserId { get; set; } = 0;
    }
}