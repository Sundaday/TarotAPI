using System.ComponentModel.DataAnnotations.Schema;
using TarotAPI.Models;

namespace TarotAPI.DTOs.Get
{
    public class GetTeamWithCharactersDto
    {
        public int TeamId { get; set; }
        public string? TeamName { get; set; }
        public string? TeamDescription { get; set; }
        public float TeamDamage { get; set; }
        public int UserId { get; set; }
    }
}