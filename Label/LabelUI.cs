using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;

namespace UIser.Label
{
    /// <summary>
    /// 可以显示文字的UI
    /// </summary>
    public class LabelUI : UIBaser
    {
        public int TextPositionX = 0;
        public int TextPositionY = 0;

        public string Text
        {
            get;
            protected set;
        } = string.Empty;

        public Vector2 TextPosition
        {
            get => new Vector2(TextPositionX, TextPositionY);
            set
            {
                TextPositionX = (int)value.X;
                TextPositionY = (int)value.Y;
            }
        }

        public DynamicSpriteFont Font
        {
            get;
            protected set;
        } = Main.fontMouseText;

        public LabelUI() : base()
        {
        }

        public LabelUI(DynamicSpriteFont font) : base()
        {
            Font = font ?? Main.fontMouseText;
        }

        public virtual bool CanChangeText(string text) => !string.IsNullOrEmpty(text);

        public virtual void ChangeText(string text)
        {
            if (CanChangeText(text))
                Text = text;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this);
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