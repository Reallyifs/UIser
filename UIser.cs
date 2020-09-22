using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using Terraria;
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
                        if (baser.MouseEntered)
                        {
                            if (!baser.Rectangle.Contains(Functionser.MousePoint))
                            {
                                baser.MouseLeave();
                                baser.MouseEntered = false;
                                continue;
                            }
                        }
                    }
                }
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