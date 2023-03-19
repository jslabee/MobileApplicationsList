using System;
using System.Collections.Generic;

namespace MobileApplicationListTest.Models;

public partial class Aplicationdetail
{
    public int Id { get; set; }

    public double Score { get; set; }

    public int Ratings { get; set; }

    public double Size { get; set; }

    public string ApplicationStoreUrl { get; set; } = null!;

    public int Type { get; set; }

    public DateTime DateAdded { get; set; }

    public int? ApplicationBaseId { get; set; }

    public virtual Applicationbase? ApplicationBase { get; set; }
}
