using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using UIser.Label;

namespace UIser.Button
{
    /// <summary>
    /// 可以按的UI
    /// </summary>
    public class ButtonUI : LabelUI
    {
        /// <summary>
        /// 在此UI中，<see cref="Texture"/> 为常态显示的贴图
        /// </summary>
        public override Texture2D Texture => base.Texture;

        /// <summary>
        /// 当鼠标移入此UI时显示的贴图
        /// </summary>
        public virtual Texture2D MouseEnterTexture => Texture;

        /// <summary>
        /// 当鼠标按下此UI时显示的贴图
        /// </summary>
        public virtual Texture2D MousePressTexture => Texture;

        public ButtonUI() : base()
        {
        }

        public ButtonUI(DynamicSpriteFont font) : base(font)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (MouseEntered)
            {
                if (UILoader.Mouse.PressAny)
                    spriteBatch.Draw(this, MousePressTexture);
                else
                    spriteBatch.Draw(this, MouseEnterTexture);
            }
            else
                spriteBatch.Draw(this);
            if (!string.IsNullOrEmpty(Text))
            {
                Vector2 TextDrawPosition = ScreenPosition + TextPosition;
                spriteBatch.DrawFiveString(Font, Text, TextDrawPosition, Color.White, Color.Black, Vector2.Zero);
                if (Width < Font.MeasureString(Text).X)
                    Width = (int)Font.MeasureString(Text).X + 1;
            }
            DrawDescription(spriteBatch);
        }
    }
}