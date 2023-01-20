using System;
using System.Collections.Generic;

namespace TarotAPI.Models;

public partial class Character
{
    public int CharacterId { get; set; }

    public string CharacterName { get; set; } = null!;

    public string CharacterClass { get; set; } = null!;

    public string CharacterElement { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; } = new List<Team>();
}
