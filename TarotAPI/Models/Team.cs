using System;
using System.Collections.Generic;

namespace TarotAPI.Models;

public partial class Team
{
    public int TeamId { get; set; }

    public string TeamName { get; set; } = null!;

    public string TeamDescription { get; set; } = null!;

    public float TeamDamage { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Character> Characters { get; } = new List<Character>();
}
