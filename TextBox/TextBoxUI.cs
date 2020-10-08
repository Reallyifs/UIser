using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameInput;
using UIser.Label;

namespace UIser.TextBox
{
    /// <summary>
    /// 可以更改其文字的UI<para></para>
    /// 未实现<para></para>
    /// 卡点：如何获取键盘焦点，使人物不移动
    /// </summary>
    public class TextBoxUI : LabelUI
    {
        internal int WriteSecond;
        internal bool InWrite;
        internal Vector2 PlayerPosition;

        public TextBoxUI() : base()
        {
        }
        public TextBoxUI(DynamicSpriteFont font) : base(font)
        {
        }

        /// <summary>
        /// 在此UI中，<see cref="CanChangeText(string)"/> 控制玩家能否改变 UI 内文字
        /// </summary>
        /// <param name="text">被调用时值为 <see langword="null"/></param>
        /// <returns></returns>
        public override bool CanChangeText(string text) => true;

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this);
            string DrawText = Text;
            if (InWrite)
            {
                WriteSecond++;
                DrawText += (WriteSecond > 60) ? "|" : null;
                if (WriteSecond > 120)
                    WriteSecond = 0;
            }
            if (!string.IsNullOrEmpty(DrawText))
            {
                Vector2 DrawPosition = Position + TextPosition - Main.screenPosition;
                spriteBatch.DrawFiveString(Font, DrawText, DrawPosition, Color.White, Color.Black, Vector2.Zero);
            }
        }

        public override void MouseDoubleClick(bool? MouseLeft)
        {
            if (CanChangeText(null) && MouseLeft == true)
                InWrite = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (InWrite && Main.hasFocus)
            {
                Text += PlayerInput.BlockedKey;
                PlayerInput.BlockedKey = null;
                if (Main.LocalPlayer.position != PlayerPosition)
                    Main.LocalPlayer.position = PlayerPosition;
                if (!MouseEntered && Main.mouseLeft && Main.mouseLeftRelease)
                {
                    InWrite = false;
                    PlayerPosition = new Vector2();
                }
            }
            else
                PlayerPosition = Main.LocalPlayer.position;
        }
    }
}