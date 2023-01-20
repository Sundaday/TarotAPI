using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TarotAPI.Models
{
    public class UserOld
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public DateTime? HireGuild { get; set; }
        [ForeignKey("Guild")]
        public int GuildId { get; set; }
        public GuildOld? Guild { get; set; }
        public ICollection<TeamOld> Teams { get; set; } = new List<TeamOld>();
    }
}
