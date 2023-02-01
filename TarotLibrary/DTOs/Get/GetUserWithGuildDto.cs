using TarotAPI.Models;

namespace TarotAPI.DTOs.Get
{
    public class GetUserWithGuildDto
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? HireGuild { get; set; }
        public int? GuildId { get; set; }
        public string? GuildName { get; set; }
    }
}