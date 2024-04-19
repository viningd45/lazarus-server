using System;
using System.Collections.Generic;

namespace LazarusServer.Data.Models;

public class Exercise
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public bool IsDouble { get; set; }

    public int UserId { get; set; }

    public bool IsArchived { get; set; }

    public virtual ExerciseCategory? Category { get; set; }

    public virtual ICollection<ProgramExercise> ProgramExercises { get; set; } = new List<ProgramExercise>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; } = new List<WorkoutExercise>();

    public virtual ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();
}
