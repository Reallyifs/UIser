using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using Terraria;

namespace UIser
{
    public static class Functionser
    {
        public const string UIDefaultName = "UIser : DefaultName";

        public static bool MouseClick => Main.mouseLeft && Main.mouseLeftRelease;

        internal static UIBaser lastClickUI;
        internal static GameTime lastClickTime;
        internal static Point MousePoint => new Point(Main.mouseX, Main.mouseY);
        internal static UIser Instance { get; set; }
        internal static Assembly Assembly { get; set; }

        public static void ToFront<T>(this List<T> list, T item)
        {
            if (list.Contains(item))
            {
                T item2 = item;
                list.Remove(item);
                list.Insert(0, item2);
            }
        }

        public static void Add<T>(this List<T> list, T item, bool front)
        {
            if (front)
                list.Insert(0, item);
        }

        public static void Draw(this SpriteBatch spriteBatch, UIBaser baser)
        {
            spriteBatch.Draw(baser.Texture, baser.Position - Main.screenPosition, null, baser.Color, baser.Rotation, Vector2.Zero, baser.Scale,
                baser.SpriteEffect, 0f);
        }

        public static Rectangle GetRectangle(Vector2 position, Vector2 WH)
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)WH.X, (int)WH.Y);
        }

        public static void DrawFiveString(this SpriteBatch spriteBatch, DynamicSpriteFont font, string text, Vector2 position, Color textColor,
            Color hideColor, Vector2 orig, float scale = 1f, Action ifMouseIn = null)
        {
            Utils.DrawBorderStringFourWay(spriteBatch, font, text, position.X, position.Y, textColor, hideColor, orig, scale);
            if (GetRectangle(position, font.MeasureString(text)).Contains(MousePoint))
                ifMouseIn?.Invoke();
        }
    }
}