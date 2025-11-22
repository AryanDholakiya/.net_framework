using System;
using System.Collections.Generic;

namespace DatabaseFirstApproach_08.Models;

public partial class PhotoUpload
{
    public int PetId { get; set; }

    public string? PetPhoto { get; set; }
}
