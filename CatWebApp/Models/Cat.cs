using System;
using System.Collections.Generic;

namespace CatWebApp.Models;

public partial class Cat
{
    public int Id { get; set; }

    public int BreedTypeId { get; set; }

    public string BreedName { get; set; } = null!;

    public string CommonBreedIssues { get; set; } = null!;

    public string? Origin { get; set; }

    public string? CoatLength { get; set; }

    public string? CoatPattern { get; set; }

    public string Description { get; set; } = null!;

    public string MainCharacteristics { get; set; } = null!;

    public string OriginDescription { get; set; } = null!;

    public string PersonalityTraitsDescription { get; set; } = null!;

    public string? LifeSpan { get; set; }

    public string? GoodWith { get; set; }

    public string? SheddingAmmount { get; set; }

    public string? Playfulness { get; set; }

    public string? AffectionLevel { get; set; }

    public string? ActivityLevel { get; set; }

    public string? TendencyToVocalize { get; set; }

    public string? ExerciseNeeds { get; set; }

    public string ImgSrc { get; set; } = null!;

    public virtual BreedType BreedType { get; set; } = null!;

    public virtual ICollection<FunFact> FunFacts { get; set; } = new List<FunFact>();

    public virtual ICollection<HealthIssue> HealthIssues { get; set; } = new List<HealthIssue>();
}
