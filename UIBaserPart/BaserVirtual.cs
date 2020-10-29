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
        public virtual Texture2D Texture => UIser.Instance.GetTexture("Files/Images/BaserTexture");

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

        /// <summary>
        /// 在UI已 <see cref="Activate"/> 的前提下才会调用此方法，如果重写你需要写出所有的绘画逻辑
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this);
            DrawDescription(spriteBatch);
        }

        /// <summary>
        /// 在UI已 <see cref="Activate"/> 的前提下才会调用此方法，不管窗口有没有焦点
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// 在UI已 <see cref="Activate"/> 且窗口有焦点的前提下才会调用此方法，在此之前会调用 <see cref="Update(GameTime)"/>
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void FocusUpdate(GameTime gameTime)
        {
        }

        /// <summary>
        /// 在UI已 <see cref="Activate"/> 且窗口没有焦点的前提下才会调用此方法，在此之前会调用 <see cref="Update(GameTime)"/>
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void NonFocusUpdate(GameTime gameTime)
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
        /// <param name="MouseLeft">True：鼠标左键 | Null：鼠标中键 | False：鼠标右键</param>
        public virtual void MouseClick(bool? MouseLeft)
        {
        }

        /// <summary>
        /// 鼠标双击，会先触发 <see cref="MouseClick(bool?)"/>
        /// </summary>
        /// <param name="MouseLeft">True：鼠标左键 | Null：鼠标中键 | False：鼠标右键</param>
        public virtual void MouseDoubleClick(bool? MouseLeft)
        {
        }
        #endregion
    }
}