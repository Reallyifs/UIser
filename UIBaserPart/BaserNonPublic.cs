using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;

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

        internal void DrawDescription(SpriteBatch spriteBatch)
        {
            string drawString = Description;
            if (UIser.DeveloperMode || TestUI)
                drawString = Name + "\n" + Description;
            if (MouseEntered && !string.IsNullOrEmpty(Description))
            {
                Vector2 position = new Vector2(Main.mouseX + 15, Main.mouseY + 15);
                spriteBatch.DrawFiveString(Main.fontMouseText, drawString, position, Color.White, Color.Black, Vector2.Zero);
            }
        }
    }
}