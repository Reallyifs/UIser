using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria;

namespace UIser
{
    public static class Functionser
    {
        internal static Point MousePoint => new Point(Main.mouseX, Main.mouseY);

        public static TimeSpan FromSeconds(this double number) => TimeSpan.FromSeconds(number);

        public static bool MouseInAnyBaser() => UIBaser.AllBaser.Any((UIBaser baser) => baser.Rectangle.Contains(MousePoint));

        public static void ToFront<T>(this List<T> list, T item)
        {
            if (list.Contains(item))
            {
                T item2 = item;
                list.Remove(item);
                list.Add(item2, true);
            }
        }

        public static void Add<T>(this List<T> list, T item, bool front)
        {
            if (front)
                list.Insert(0, item);
            else
                list.Add(item);
        }

        public static void Draw(this SpriteBatch spriteBatch, UIBaser baser, Texture2D otherTexture)
        {
            if (otherTexture == null)
                otherTexture = baser.Texture;
            spriteBatch.Draw(otherTexture, baser.ScreenPosition, null, baser.Color, baser.Rotation, Vector2.Zero, baser.Scale,
                baser.SpriteEffect, 0f);
        }

        public static void Draw(this SpriteBatch spriteBatch, UIBaser baser)
        {
            spriteBatch.Draw(baser.Texture, baser.ScreenPosition, null, baser.Color, baser.Rotation, Vector2.Zero, baser.Scale,
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