using System;
using System.Collections.Generic;

namespace DI;

public partial class User
{
    public string Username { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Passkey { get; set; } = null!;
}
