using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _02_CRUD_API.Models;

public partial class Student
{
    [Key]
    public int GrNumber { get; set; }

    public string? Sname { get; set; }

    public string? Sgender { get; set; }

    public int? Sage { get; set; }

    public int? Sstd { get; set; }
}
