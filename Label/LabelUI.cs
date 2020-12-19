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
        /// <summary>
        /// 文字在UI中的位置X（以基类 <see cref="UIBaser.X"/> 为原点）
        /// </summary>
        public int TextPositionX = 0;
        /// <summary>
        /// 文字在UI中的位置Y（以基类 <see cref="UIBaser.Y"/> 为原点）
        /// </summary>
        public int TextPositionY = 0;

        /// <summary>
        /// 要显示的文字的颜色
        /// </summary>
        public Color TextColor
        {
            get;
            set;
        } = Color.White;

        /// <summary>
        /// 要显示的文字的背景颜色
        /// </summary>
        public Color TextBorderColor
        {
            get;
            set;
        } = Color.Black;

        /// <summary>
        /// 要显示的文字的缩放
        /// </summary>
        public float TextScale
        {
            get;
            set;
        } = 1;

        /// <summary>
        /// 要显示的文字
        /// </summary>
        public string Text
        {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// 文字在UI中的位置（以基类 <see cref="UIBaser.Position"/> 为原点）
        /// </summary>
        public Vector2 TextPosition
        {
            get => new Vector2(TextPositionX, TextPositionY) + ScreenPosition;
            set
            {
                TextPositionX = (int)(value.X - ScreenPosition.X);
                TextPositionY = (int)(value.Y - ScreenPosition.Y);
            }
        }

        /// <summary>
        /// 要显示的文字的字体
        /// </summary>
        public DynamicSpriteFont Font
        {
            get;
            set;
        } = Main.fontMouseText;

        /// <summary>
        /// 获取一个 <see cref="LabelUI"/>
        /// </summary>
        public LabelUI() : base()
        {
        }

        /// <summary>
        /// 获取一个 <see cref="LabelUI"/>，使用指定的文字
        /// </summary>
        /// <param name="text">要显示的文字</param>
        public LabelUI(string text) : base()
        {
            ChangeText(text);
        }

        /// <summary>
        /// 获取一个 <see cref="LabelUI"/>，使用指定的文字和字体
        /// </summary>
        /// <param name="text">要显示的文字</param>
        /// <param name="font">要显示的文字的字体</param>
        public LabelUI(string text, DynamicSpriteFont font) : base()
        {
            ChangeFont(font);
            ChangeText(text);
        }

        /// <summary>
        /// 获取一个 <see cref="LabelUI"/>，使用指定的字体
        /// </summary>
        /// <param name="font">要显示的文字的字体</param>
        public LabelUI(DynamicSpriteFont font) : base()
        {
            ChangeFont(font);
        }

        /// <summary>
        /// 检测能否更改其显示的文字的字体
        /// </summary>
        /// <param name="font">要检查的字体</param>
        /// <returns></returns>
        public virtual bool CanChangeFont(DynamicSpriteFont font) => font != null;

        /// <summary>
        /// 检测能否更改其显示的文字
        /// </summary>
        /// <param name="text">要检查的文字</param>
        /// <returns></returns>
        public virtual bool CanChangeText(string text) => !string.IsNullOrEmpty(text);

        /// <summary>
        /// 改变其显示的文字的字体，会先调用 <see cref="CanChangeFont(DynamicSpriteFont)"/>，如不需要可将其重写
        /// </summary>
        /// <param name="text">要显示的字体</param>
        public virtual void ChangeFont(DynamicSpriteFont font)
        {
            if (CanChangeFont(font))
                Font = font;
        }

        /// <summary>
        /// 改变其显示的文字，会先调用 <see cref="CanChangeText(string)"/>，如不需要可将其重写
        /// </summary>
        /// <param name="text">要显示的文字</param>
        public virtual void ChangeText(string text)
        {
            if (CanChangeText(text))
                Text = text;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (!string.IsNullOrEmpty(Text))
            {
                spriteBatch.DrawFiveString(Font, Text, TextPosition, TextColor, Color.Black, Vector2.Zero, TextScale);
                if (Width < Font.MeasureString(Text).X)
                    Width = (int)Font.MeasureString(Text).X + 1;
            }
        }
    }
}