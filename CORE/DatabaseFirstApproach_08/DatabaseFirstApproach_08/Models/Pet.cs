using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach_08.Models;

public partial class Pet
{
    public int PetId { get; set; }

    public string? PetName { get; set; }

    public int? PetAge { get; set; }

    public DateOnly? PetAdoptedDate { get; set; }

    public string? PetGender { get; set; }

    public string? Hobbies { get; set; }

    public string? PetBreed { get; set; }

    public int? PetCountryId { get; set; }

    public string? PetPhoto { get; set; }

    public virtual PetCountry? PetCountry { get; set; }
}
