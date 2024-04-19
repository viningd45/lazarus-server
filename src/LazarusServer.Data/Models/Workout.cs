using System;
using System.Collections.Generic;

namespace LazarusServer.Data.Models;

public class Workout
{
    public int Id { get; set; }

    public DateOnly? Day { get; set; }

    public int UserId { get; set; }

    public string? Notes { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();
}
