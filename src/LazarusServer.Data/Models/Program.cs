using System;
using System.Collections.Generic;

namespace LazarusServer.Data.Models;

public class Program
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int UserId { get; set; }

    public bool? IsArchived { get; set; }

    public virtual ICollection<ProgramExercise> ProgramExercises { get; set; } = new List<ProgramExercise>();

    public virtual User User { get; set; } = null!;
}
