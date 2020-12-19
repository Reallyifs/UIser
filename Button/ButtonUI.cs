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
        private Texture2D[] Textures;

        /// <summary>
        /// 在此UI中，<see cref="Texture"/> 为常态显示的贴图
        /// </summary>
        public new virtual Texture2D Texture
        {
            get => Textures[0];
            set => Textures[0] = value;
        }

        /// <summary>
        /// 当鼠标移入此UI时显示的贴图
        /// </summary>
        public virtual Texture2D MouseEnterTexture
        {
            get => Textures[1];
            set => Textures[1] = value;
        }

        /// <summary>
        /// 当鼠标按下此UI时显示的贴图
        /// </summary>
        public virtual Texture2D MousePressTexture
        {
            get => Textures[2];
            set => Textures[2] = value;
        }

        /// <summary>
        /// 获取一个 <see cref="ButtonUI"/>
        /// </summary>
        public ButtonUI() : base()
        {
            Textures = new Texture2D[]
            {
                base.Texture,
                base.Texture,
                base.Texture
            };
        }

        /// <summary>
        /// 获取一个 <see cref="ButtonUI"/>，使用指定的字体
        /// </summary>
        /// <param name="font">字体</param>
        public ButtonUI(DynamicSpriteFont font) : base(font)
        {
            Textures = new Texture2D[]
            {
                base.Texture,
                base.Texture,
                base.Texture
            };
        }

        /// <summary>
        /// 获取一个 <see cref="ButtonUI"/>，将所有贴图设置为默认的贴图
        /// </summary>
        /// <param name="defaultTexture">默认的贴图</param>
        public ButtonUI(Texture2D defaultTexture) : base()
        {
            Textures = new Texture2D[]
            {
                defaultTexture,
                defaultTexture,
                defaultTexture
            };
        }

        /// <summary>
        /// 获取一个 <see cref="ButtonUI"/>，将常态贴图设置为 <paramref name="defaultTexture"/>，其余贴图设置为 <paramref name="pressingTexture"/>
        /// </summary>
        /// <param name="defaultTexture">常态贴图</param>
        /// <param name="pressingTexture">鼠标在其上，或按下的贴图</param>
        public ButtonUI(Texture2D defaultTexture, Texture2D pressingTexture) : base()
        {
            Textures = new Texture2D[]
            {
                defaultTexture,
                pressingTexture,
                pressingTexture
            };
        }

        /// <summary>
        /// 获取一个 <see cref="ButtonUI"/>，使用指定的贴图
        /// </summary>
        /// <param name="defaultTexture">常态贴图</param>
        /// <param name="enterTexture">鼠标进入此UI时的贴图</param>
        /// <param name="pressTexture">鼠标按下此UI时的贴图</param>
        public ButtonUI(Texture2D defaultTexture, Texture2D enterTexture, Texture2D pressTexture) : base()
        {
            Textures = new Texture2D[]
            {
                defaultTexture,
                enterTexture,
                pressTexture
            };
        }

        /// <summary>
        /// 获取一个 <see cref="ButtonUI"/>，将所有贴图设置为默认的贴图且使用指定的字体
        /// </summary>
        /// <param name="defaultTexture">默认的贴图</param>
        /// <param name="font">字体</param>
        public ButtonUI(Texture2D defaultTexture, DynamicSpriteFont font) : base(font)
        {
            Textures = new Texture2D[]
            {
                defaultTexture,
                defaultTexture,
                defaultTexture
            };
        }

        /// <summary>
        /// 获取一个 <see cref="ButtonUI"/>，将常态贴图设置为 <paramref name="defaultTexture"/>，其余贴图设置为 <paramref name="pressingTexture"/> 且使用指定的字体
        /// </summary>
        /// <param name="defaultTexture">常态贴图</param>
        /// <param name="pressingTexture">鼠标在其上，或按下的贴图</param>
        /// <param name="font">字体</param>
        public ButtonUI(Texture2D defaultTexture, Texture2D pressingTexture, DynamicSpriteFont font) : base(font)
        {
            Textures = new Texture2D[]
            {
                defaultTexture,
                pressingTexture,
                pressingTexture
            };
        }

        /// <summary>
        /// 获取一个 <see cref="ButtonUI"/>，使用指定的贴图和指定的字体
        /// </summary>
        /// <param name="defaultTexture">常态贴图</param>
        /// <param name="enterTexture">鼠标进入此UI时的贴图</param>
        /// <param name="pressTexture">鼠标按下此UI时的贴图</param>
        /// <param name="font">字体</param>
        public ButtonUI(Texture2D defaultTexture, Texture2D enterTexture, Texture2D pressTexture, DynamicSpriteFont font) : base(font)
        {
            Textures = new Texture2D[]
            {
                defaultTexture,
                enterTexture,
                pressTexture
            };
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