using System.ComponentModel.DataAnnotations;

namespace TarotAPI.Models
{
    public class GuildOld
    {
        [Key]
        public int GuildId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Rank { get; set; }
        public DateTime? CreationDate { get; set; }
        public ICollection<UserOld> Users { get; } = new HashSet<UserOld>();
    }
}
