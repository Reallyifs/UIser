using System.Collections.Generic;

namespace UIser
{
    public partial class UIBaser
    {
        private bool Initialized = false;

        internal bool MouseEntered;

        internal UIBaser OnBaser;
        internal List<UIBaser> DeBaser;

        internal const double MaxDoubleClickTime = 0.5;
        internal static List<UIBaser> AllBaser;

        internal static void BaserAdd(UIBaser baser, int? index = null)
        {
            if (AllBaser == null)
                AllBaser = new List<UIBaser>();
            if (index.HasValue && index >= 0 && index.Value < AllBaser.Count)
            {
                AllBaser.Insert(index.Value, baser);
                return;
            }
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