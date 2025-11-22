using System;
using System.Collections.Generic;

namespace ViewModel_BindMultiModel_withView.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? EmpEmail { get; set; }

    public int? EmpSalary { get; set; }
}
