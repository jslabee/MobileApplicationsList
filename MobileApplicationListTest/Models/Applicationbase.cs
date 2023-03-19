using System;
using System.Collections.Generic;

namespace MobileApplicationListTest.Models;

public partial class Applicationbase
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Image { get; set; } = null!;

    public virtual ICollection<Aplicationdetail> Aplicationdetails { get; } = new List<Aplicationdetail>();
}
