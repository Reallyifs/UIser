using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace UIser
{
    public partial class UIBaser
    {
        internal virtual bool TestUI => false;

        /// <summary>
        /// 别问，问就是懒
        /// </summary>
        public virtual Texture2D Texture => ModContent.GetTexture("Terraria/Text_Back");

        /// <summary>
        /// 激活此UI时，在这里初始化你需要用到的变量，如果没有初始化，则会先调用 <see cref="Initialize"/>
        /// </summary>
        protected virtual void Activate()
        {
        }

        /// <summary>
        /// 注销此UI时，在这里还原你用到的所有变量
        /// </summary>
        protected virtual void Deactivate()
        {
        }

        /// <summary>
        /// 初始化，只执行一次，保留 base.Initialize();
        /// </summary>
        protected virtual void Initialize()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position - Main.screenPosition, null, Color, Rotation, Vector2.Zero, Scale, SpriteEffect, 0f);
            if (Rectangle.Contains(Functionser.MousePoint) && !string.IsNullOrEmpty(Description))
            {
                Vector2 position = new Vector2(Main.mouseX + 15, Main.mouseY + 15);
                spriteBatch.DrawFiveString(Main.fontMouseText, Description, position, Color.White, Color.Black, Vector2.Zero);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        #region MouseAction
        /// <summary>
        /// 发生在鼠标进入此UI的时候
        /// </summary>
        public virtual void MouseEnter()
        {
        }
        /// <summary>
        /// 发生在鼠标离开此UI的时候
        /// </summary>
        public virtual void MouseLeave()
        {
        }
        /// <summary>
        /// 鼠标单击
        /// </summary>
        /// <param name="MouseLeft">True：鼠标左键 | False：鼠标右键 | null：鼠标中键</param>
        public virtual void MouseClick(bool? MouseLeft)
        {
        }
        /// <summary>
        /// 鼠标双击，会先触发单击事件
        /// </summary>
        /// <param name="MouseLeft">True：鼠标左键 | False：鼠标右键 | null：鼠标中键</param>
        public virtual void MouseDoubleClick(bool? MouseLeft)
        {
        }
        #endregion
    }
}