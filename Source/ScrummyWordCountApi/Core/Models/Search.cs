using System;
using System.Collections.Generic;

namespace ScrummyWordCountApi.Core.Models;

public partial class Search
{
    public int Id { get; set; }

    public DateTime Searchedat { get; set; }

    public string Url { get; set; } = null!;

    public string Searchquery { get; set; } = null!;

    public int Numberofoccurrences { get; set; }
}
