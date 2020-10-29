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
        public const string Instructions = "请转到本 Mod 的 descripton.txt 或 更多信息 查看。";

        internal static bool DeveloperMode
        {
            get;
            private set;
        }

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
            DeveloperMode = true;
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
                        baser.FocusUpdate(gameTime);
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
                    else
                        baser.NonFocusUpdate(gameTime);
                }
            }
            if (Functionser.MouseInAnyBaser())
            {
                if (UILoader.Mouse.Left.Click)
                    UpdateUIAction(true);
                if (UILoader.Mouse.Middle.Click)
                    UpdateUIAction(null);
                if (UILoader.Mouse.Right.Click)
                    UpdateUIAction(false);
                void UpdateUIAction(bool? MouseLeft)
                {
                    UIBaser clickBaser = UIBaser.AllBaser.FindAll((UIBaser baser) => baser.Rectangle.Contains(Functionser.MousePoint))[0];
                    UIBaser.AllBaser.ToFront(clickBaser);
                    clickBaser.MouseClick(MouseLeft);
                    UILoader.clickUINow = clickBaser;
                    if (UILoader.clickUIBefore == clickBaser && DateTime.Now - UILoader.clickTime < UIBaser.MaxDoubleClickTime.FromSeconds())
                    {
                        clickBaser.MouseDoubleClick(MouseLeft);
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