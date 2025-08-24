using System;
using System.Collections.Generic;

namespace Temperature_and_Humidity_Collection.Models;

public partial class UserInformationTable
{
    public int Uid { get; set; }

    public string UserAccount { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public byte UserAccessLevel { get; set; }

    public virtual ICollection<OperationLogTable> OperationLogTables { get; set; } = new List<OperationLogTable>();
}
