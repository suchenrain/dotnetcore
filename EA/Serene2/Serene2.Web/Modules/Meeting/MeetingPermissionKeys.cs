﻿
using Serenity.Extensibility;
using System.ComponentModel;

namespace Serene2.Meeting
{
    [NestedPermissionKeys]
    public class PermissionKeys
    {
        [Description("[General]")]
        public const string General = "Meeting:General";
        public const string Management = "Meeting:Management";
    }
}
