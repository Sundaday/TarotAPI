﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TarotAPI.Models
{
    public class CharacterOld
    {
        [Key]
        public int CharacterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Class { get; set; } = string.Empty;
        public string Element { get; set; } = string.Empty;
        public ICollection<TeamOld> Teams { get; set; } = new List<TeamOld>();
    }
}