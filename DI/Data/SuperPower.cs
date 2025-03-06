using System;
using System.Collections.Generic;

namespace DI;

public partial class SuperPower
{
    public int Id { get; set; }

    public string? SuperPowerName { get; set; }

    public int SuperHeroId { get; set; }

    public virtual SuperHero SuperHero { get; set; } = null!;
}
