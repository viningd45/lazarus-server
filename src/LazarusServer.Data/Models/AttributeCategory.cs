using System;
using System.Collections.Generic;

namespace LazarusServer.Data.Models;

public class AttributeCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsUniversal { get; set; }

    public virtual ICollection<Attribute> Attributes { get; set; } = new List<Attribute>();
}
