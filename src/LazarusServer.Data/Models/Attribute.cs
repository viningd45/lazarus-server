using System;
using System.Collections.Generic;

namespace LazarusServer.Data.Models;

public class Attribute
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int AttributeCategoryId { get; set; }

    public int UserId { get; set; }

    public virtual AttributeCategory AttributeCategory { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
