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
        public int TextPositionX;
        public int TextPositionY;
        public string Text { get; protected set; }
        public Vector2 TextPosition
        {
            get => new Vector2(TextPositionX, TextPositionY);
            set
            {
                TextPositionX = (int)value.X;
                TextPositionY = (int)value.Y;
            }
        }
        public DynamicSpriteFont Font { get; protected set; }

        public LabelUI() : base()
        {
            Font = Main.fontMouseText;
            Text = string.Empty;
            TextPositionX = TextPositionY = 0;
        }
        public LabelUI(DynamicSpriteFont font) : base()
        {
            Font = font ?? Main.fontMouseText;
            Text = string.Empty;
            TextPositionX = TextPositionY = 0;
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
                Vector2 TextDrawPosition = Position + TextPosition - Main.screenPosition;
                spriteBatch.DrawFiveString(Font, Text, TextDrawPosition, Color.White, Color.Black, Vector2.Zero);
            }
        }
    }
}