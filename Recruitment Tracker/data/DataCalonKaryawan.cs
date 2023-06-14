using System;
using System.Collections.Generic;

namespace Recruitment_Tracker.data;

public partial class DataCalonKaryawan
{
    public int IdCalonKaryawan { get; set; }

    public string? Nama { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<DataPelamar> DataPelamars { get; } = new List<DataPelamar>();
}
