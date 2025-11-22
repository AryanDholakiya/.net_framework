using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach_08.Models;

public partial class Person1
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? MobileNumber { get; set; }

    public byte[]? Photo { get; set; }
}
