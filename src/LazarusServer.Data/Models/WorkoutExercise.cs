using System;
using System.Collections.Generic;

namespace LazarusServer.Data.Models;

public class WorkoutExercise
{
    public int Id { get; set; }

    public int ExerciseId { get; set; }

    public int WorkoutId { get; set; }

    public string? Notes { get; set; }

    public int? Sequence { get; set; }

    public virtual Exercise Exercise { get; set; } = null!;

    public virtual Workout Workout { get; set; } = null!;

    public virtual ICollection<WorkoutExerciseSet> WorkoutExerciseSets { get; set; } = new List<WorkoutExerciseSet>();
}
