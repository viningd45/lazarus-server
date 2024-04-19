using System;
using System.Collections.Generic;

namespace LazarusServer.Data.Models;

public class WorkoutExerciseSet
{
    public int Id { get; set; }

    public int WorkoutExerciseId { get; set; }

    public decimal? Weight { get; set; }

    public int? Reps { get; set; }

    public decimal? Time { get; set; }

    public virtual WorkoutExercise WorkoutExercise { get; set; } = null!;
}
