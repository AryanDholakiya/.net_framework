using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach_08.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public byte[]? PersonImg { get; set; }
}
