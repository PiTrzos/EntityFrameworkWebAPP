using System;
using System.Collections.Generic;

namespace CatWebApp.Models;

public partial class BreedType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Cat> Cats { get; set; } = new List<Cat>();
}
