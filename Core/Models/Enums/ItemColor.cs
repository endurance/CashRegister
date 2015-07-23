using System;
using System.ComponentModel;

namespace CashRegister.Core.Models.Enums
{
    [Flags]
    public enum ItemColor
    {
        [Description("9da2a6")] Grey       =  0x9da2a6,
        [Description("4ab200")] LightGreen =  0x4ab200,
        [Description("0b8000")] DarkGreen  =  0x0b8000,
        [Description("13b1bf")] LightBlue  =  0x13b1bf,
        [Description("2952cc")] DarkBlue   =  0x2952cc,
        [Description("a82ee5")] Purple     =  0xa82ee5,
        [Description("e5457a")] LightRed   =  0xe5457a,
        [Description("b21212")] DarkRed    =  0xb21212,
        [Description("e5BF00")] Gold       =  0xe5BF00,
        [Description("593c00")] Brown      =  0x593c00 
    }
}