using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class ProdCatSup
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public short? UnitsInStock { get; set; }

    public int SupplierId { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? Country { get; set; }
}
