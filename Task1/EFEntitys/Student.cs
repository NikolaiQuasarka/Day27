using System;
using System.Collections.Generic;

namespace Task1.EFEntitys;

public partial class Student
{
    public int IdStudent { get; set; }

    public string FullName { get; set; } = null!;

    public string Group { get; set; } = null!;

    public string? PhoneNumber { get; set; }
}
