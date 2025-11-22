using System;
using System.Collections.Generic;

namespace CrudInDatabaseFirstApproach_09.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public string? StudentGender { get; set; }

    public int? StudentAge { get; set; }

    public int? StudentStd { get; set; }
}
