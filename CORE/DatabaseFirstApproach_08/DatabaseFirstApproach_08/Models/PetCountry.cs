using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach_08.Models;

public partial class PetCountry
{
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
