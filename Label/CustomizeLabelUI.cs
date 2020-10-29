using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using UIser.Customize;

namespace UIser.Label
{
    public class CustomizeLabelUI : CustomizeUIBaser
    {
        public string Text
        {
            get;
            set;
        } = string.Empty;

        public Vector2 TextPosition
        {
            get;
            set;
        }

        public DynamicSpriteFont Font
        {
            get;
            set;
        } = Main.fontMouseText;

        public CustomizeLabelUI() : base()
        {
        }

        public CustomizeLabelUI(DynamicSpriteFont font) : base()
        {
            Font = font ?? Main.fontMouseText;
        }

        public virtual bool CanChangeText(string text) => !string.IsNullOrEmpty(text);

        /// <summary>
        /// 不再调用 <see cref="CanChangeText(string)"/>，如需要请自行重写
        /// </summary>
        /// <param name="text"></param>
        public virtual void ChangeText(string text)
        {
            Text = text;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (!string.IsNullOrEmpty(Text))
            {
                Vector2 TextDrawPosition = ScreenPosition + TextPosition;
                spriteBatch.DrawFiveString(Font, Text, TextDrawPosition, Color.White, Color.Black, Vector2.Zero);
                if (Width < Font.MeasureString(Text).X)
                    Width = (int)Font.MeasureString(Text).X + 1;
            }
        }
    }
}