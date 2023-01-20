using System;
using System.Collections.Generic;

namespace TarotAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public DateTime? HireGuild { get; set; }

    public int GuildId { get; set; }

    public virtual Guild Guild { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; } = new List<Team>();
}
