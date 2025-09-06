using System;
using System.Collections.Generic;

namespace Temperature_and_Humidity_Collection.Models;

public partial class DataTable
{
    public int Id { get; set; }

    public string SlaveAddress { get; set; } = null!;

    public float Temperature { get; set; }

    public float Humidity { get; set; }

    public DateTime Datetime { get; set; }
}
