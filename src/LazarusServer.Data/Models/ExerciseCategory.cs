using System;
using System.Collections.Generic;

namespace LazarusServer.Data.Models;

public class ExerciseCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
