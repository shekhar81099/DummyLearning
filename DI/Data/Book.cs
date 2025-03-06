﻿using System;
using System.Collections.Generic;

namespace DI;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public virtual Author Author { get; set; } = null!;
}
