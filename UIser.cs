using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;
using Terraria;
using Terraria.ModLoader;

namespace UIser
{
    public class UIser : Mod
    {
        internal static UIser Instance 
        { 
            get; 
            set; 
        }

        internal static Assembly Assembly 
        { 
            get; 
            set;
        }

        public UIser()
        {
            Assembly = Assembly.GetExecutingAssembly();
            Instance = this;
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (UILoader.clickUINow != null)
            {
                UILoader.clickUIBefore = UILoader.clickUINow;
                UILoader.clickUINow = null;
            }
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
            if (Functionser.MouseInAnyBaser())
            {
                if (Functionser.MouseLeftClick)
                {
                    UIBaser clickBaser = UIBaser.AllBaser.FindAll((UIBaser baser) => baser.Rectangle.Contains(Functionser.MousePoint))[0];
                    UIBaser.AllBaser.ToFront(clickBaser);
                    clickBaser.MouseClick(true);
                    UILoader.clickUINow = clickBaser;
                    if (UILoader.clickUIBefore == clickBaser && DateTime.Now - UILoader.clickTime < UIBaser.MaxDoubleClickTime.FromSeconds())
                    {
                        clickBaser.MouseDoubleClick(true);
                        UILoader.clickUIBefore = null;
                        UILoader.clickUINow = null;
                    }
                    UILoader.clickTime = DateTime.Now;
                }
                if (Functionser.MouseMiddleClick)
                {
                    UIBaser clickBaser = UIBaser.AllBaser.FindAll((UIBaser baser) => baser.Rectangle.Contains(Functionser.MousePoint))[0];
                    UIBaser.AllBaser.ToFront(clickBaser);
                    clickBaser.MouseClick(null);
                    UILoader.clickUINow = clickBaser;
                    if (UILoader.clickUIBefore == clickBaser && DateTime.Now - UILoader.clickTime < UIBaser.MaxDoubleClickTime.FromSeconds())
                    {
                        clickBaser.MouseDoubleClick(null);
                        UILoader.clickUIBefore = null;
                        UILoader.clickUINow = null;
                    }
                    UILoader.clickTime = DateTime.Now;
                }
                if (Functionser.MouseRightClick)
                {
                    UIBaser clickBaser = UIBaser.AllBaser.FindAll((UIBaser baser) => baser.Rectangle.Contains(Functionser.MousePoint))[0];
                    UIBaser.AllBaser.ToFront(clickBaser);
                    clickBaser.MouseClick(false);
                    UILoader.clickUINow = clickBaser;
                    if (UILoader.clickUIBefore == clickBaser && DateTime.Now - UILoader.clickTime < UIBaser.MaxDoubleClickTime.FromSeconds())
                    {
                        clickBaser.MouseDoubleClick(false);
                        UILoader.clickUIBefore = null;
                        UILoader.clickUINow = null;
                    }
                    UILoader.clickTime = DateTime.Now;
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