using System;
using System.Collections.Generic;

namespace Temperature_and_Humidity_Collection.Models;

public partial class LoginInformationTable
{
    public int Uid { get; set; }

    public DateTime Datetime { get; set; }

    public bool LoginOrLogout { get; set; }

    public bool Status { get; set; }

    public short ErrorCode { get; set; }

    public virtual UserInformationTable UidNavigation { get; set; } = null!;
}
