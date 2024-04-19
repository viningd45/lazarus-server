using System;
using System.Collections.Generic;

namespace LazarusServer.Data.Models;

public class ProgramExercise
{
    public int Id { get; set; }

    public int ProgramId { get; set; }

    public int ExerciseId { get; set; }

    public int? TargetSetCount { get; set; }

    public virtual Exercise Exercise { get; set; } = null!;

    public virtual Program Program { get; set; } = null!;
}
