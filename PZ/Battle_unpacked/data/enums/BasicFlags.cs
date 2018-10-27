
using System;

namespace Battle.data.enums
{
  [Flags]
  public enum BasicFlags
  {
    flag0 = 0,
    flag1 = 1,
    flag2 = 2,
    flag3 = 4,
    flag4 = 8,
    flag5 = 16, // 0x00000010
    flag6 = 32, // 0x00000020
    flag7 = 64, // 0x00000040
    flag8 = 128, // 0x00000080
  }
}
