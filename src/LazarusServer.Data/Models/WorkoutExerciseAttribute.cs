using System;
using System.Collections.Generic;

namespace LazarusServer.Data.Models;

public class WorkoutExerciseAttribute
{
    public int WorkoutExerciseId { get; set; }

    public int AttributeId { get; set; }

    public virtual Attribute Attribute { get; set; } = null!;

    public virtual WorkoutExercise WorkoutExercise { get; set; } = null!;
}
