using System;
using System.Collections.Generic;

namespace Bind_DropDownList_With_Db_13.Models;

public partial class PetCountry
{
    public string? Countries { get; set; }

    public int Id { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
