using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace UIser
{
    public class UIser : Mod
    {
        public UIser()
        {
            Functionser.Instance = this;
            Functionser.Assembly = Assembly.GetExecutingAssembly();
        }
        public override void UpdateUI(GameTime gameTime)
        {
            foreach (UIBaser baser in UIBaser.AllBaser)
            {
                if (baser.Activated)
                {
                    baser.Update(gameTime);
                    if (Main.hasFocus)
                    {
                        if (!baser.MouseEntered && baser.Rectangle.Contains(Functionser.MousePoint))
                        {
                            baser.MouseEnter();
                            baser.MouseEntered = true;
                        }
                        if (baser.MouseEntered && !baser.Rectangle.Contains(Functionser.MousePoint))
                        {
                            baser.MouseLeave();
                            baser.MouseEntered = false;
                        }
                    }
                }
            }
            if (Functionser.MouseClick)
            {
                UIBaser clickBaser = UIBaser.AllBaser.SkipWhile(
                    (UIBaser baser) => baser.Rectangle.Contains(Functionser.MousePoint)).ToArray()[0];
                clickBaser.MouseClick(true);
                Functionser.lastClickUI = clickBaser;
                if (Functionser.lastClickUI == clickBaser)
                {
                    clickBaser.MouseDoubleClick(true);
                    Functionser.lastClickUI = null;
                }
                Functionser.lastClickTime = gameTime;
            }
        }
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            foreach (UIBaser baser in UIBaser.AllBaser)
            {
                if (baser.Activated)
                    baser.Draw(spriteBatch);
            }
        }
    }
}