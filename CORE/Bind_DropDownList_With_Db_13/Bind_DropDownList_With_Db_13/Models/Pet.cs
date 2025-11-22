using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bind_DropDownList_With_Db_13.Models;

public partial class Pet
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Breed { get; set; }

    public string? Gender { get; set; }

    //[ForeignKey("CountryId")]
    public int? CountryId { get; set; }

    public virtual PetCountry? Country { get; set; }
}
