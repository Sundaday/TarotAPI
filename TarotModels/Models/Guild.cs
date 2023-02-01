using System.ComponentModel.DataAnnotations;

namespace TarotAPI.Models
{
    public class Guild
    {
        [Key]
        public int GuildId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Rank { get; set; }
        public DateTime? CreationDate { get; set; }
        public ICollection<User> Users { get; } = new HashSet<User>();
    }
}
