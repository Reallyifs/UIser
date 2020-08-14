using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System.Reflection;
using Terraria;

namespace UIser
{
    public static class Functionser
    {
        internal static UIser Instance { get; set; }
        internal static Assembly Assembly { get; set; }
        public static void DrawFiveString(this SpriteBatch spriteBatch, DynamicSpriteFont font, string text, Vector2 position, Color textColor,
            Color hideColor, Vector2 orig, float scale = 1f)
        {
            Utils.DrawBorderStringFourWay(spriteBatch, font, text, position.X, position.Y, textColor, hideColor, orig, scale);
        }
    }
}