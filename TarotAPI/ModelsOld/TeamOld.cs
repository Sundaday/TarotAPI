using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TarotAPI.Models
{
    public class TeamOld
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Damage { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserOld? User { get; set; }
        public ICollection<CharacterOld> CharactersList { get; } = new List<CharacterOld>();
    }
}
