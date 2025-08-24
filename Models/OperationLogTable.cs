using System;
using System.Collections.Generic;

namespace Temperature_and_Humidity_Collection.Models;

public partial class OperationLogTable
{
    public int Id { get; set; }

    public int Uid { get; set; }

    public DateTime Datetime { get; set; }

    public short OperationCode { get; set; }

    public bool Status { get; set; }

    public int? PUid { get; set; }

    public string? PUserAccount { get; set; }

    public string? PUserPassword { get; set; }

    public string? PUserName { get; set; }

    public byte? PUserAccessLevel { get; set; }

    public short ErrorCode { get; set; }

    public virtual UserInformationTable UidNavigation { get; set; } = null!;
}
