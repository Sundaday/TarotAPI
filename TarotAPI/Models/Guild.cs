using System;
using System.Collections.Generic;

namespace TarotAPI.Models;

public partial class Guild
{
    public int GuildId { get; set; }

    public string GuildName { get; set; } = null!;

    public int GuildRank { get; set; }

    public DateTime? GuildCreationDate { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
