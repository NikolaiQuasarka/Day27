using System;
using System.Collections.Generic;

namespace Task1.EFEntitys;

public partial class Note
{
    public int IdNote { get; set; }

    public string StudentFullName { get; set; } = null!;

    public string? ConstSubject { get; set; }

    public DateTime ConsultationTime { get; set; }
}
