using System;
using System.Collections.Generic;

namespace DI;

public partial class SuperHero
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Place { get; set; } = null!;

    public virtual ICollection<SuperPower> SuperPowers { get; set; } = new List<SuperPower>();
}
