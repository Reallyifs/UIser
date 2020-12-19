using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;

namespace UIser
{
    /// <summary>
    /// 如果你是用了此dll，请在你Mod主类添加下列所有方法<para></para>
    /// 你也可以直接继承 <see cref="UIser"/>，但是在重写 <see cref="UIser.PostDrawInterface(SpriteBatch)"/> 和 <see cref="UIser.UpdateUI(GameTime)"/> 时保留
    /// <code>base.PostDrawInterface(spriteBatch);</code>
    /// 和
    /// <code>base.UpdateUI(gameTime);</code>
    /// </summary>
    public static class UISetter
    {
        public static void PostDrawInterface(SpriteBatch spriteBatch)
        {
            foreach (UIBaser baser in UIBaser.AllBaser)
            {
                if (baser.Activated)
                    baser.Draw(spriteBatch);
            }
        }

        public static void UpdateUI(GameTime gameTime)
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
    }
}