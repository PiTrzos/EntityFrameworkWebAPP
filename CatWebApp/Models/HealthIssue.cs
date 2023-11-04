using System;
using System.Collections.Generic;

namespace CatWebApp.Models;

public partial class HealthIssue
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Cat> Cats { get; set; } = new List<Cat>();
}
