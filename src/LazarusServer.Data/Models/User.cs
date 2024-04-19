using System;
using System.Collections.Generic;

namespace LazarusServer.Data.Models;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();

    public virtual ICollection<Program> Programs { get; set; } = new List<Program>();

    public virtual ICollection<Workout> Workouts { get; set; } = new List<Workout>();
}
