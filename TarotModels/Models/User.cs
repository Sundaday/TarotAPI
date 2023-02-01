using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TarotAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime? HireGuild { get; set; }
        [ForeignKey("Guild")]
        public int GuildId { get; set; }
        public Guild? Guild { get; set; }
        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
