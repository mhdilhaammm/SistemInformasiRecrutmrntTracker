using System;
using System.Collections.Generic;

namespace Recruitment_Tracker.data;

public partial class User
{
    public int IdUser { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Rolle { get; set; }

    public byte[]? Nama { get; set; }

    public string? NamaUser { get; set; }

    public virtual ICollection<DataPelamar> DataPelamars { get; } = new List<DataPelamar>();
}
