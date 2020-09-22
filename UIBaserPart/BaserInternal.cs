using System.Collections.Generic;

namespace UIser
{
    public partial class UIBaser
    {
        internal bool MouseEntered;

        internal UIBaser OnBaser;
        internal List<UIBaser> DeBaser;

        internal const double MaxDoubleClickTime = 0.5;
        internal static List<UIBaser> AllBaser;

        internal static void BaserAdd(UIBaser baser)
        {
            if (AllBaser == null)
                AllBaser = new List<UIBaser>();
            AllBaser.Add(baser);
        }
        internal static void BaserRemove(UIBaser baser)
        {
            if (AllBaser == null || !AllBaser.Contains(baser))
                return;
            AllBaser.Remove(baser);
        }
    }
}