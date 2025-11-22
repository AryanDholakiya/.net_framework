using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03_CRUDAPI_using_Dapper.Models;

public partial class Person
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? Age { get; set; }
}
