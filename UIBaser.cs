using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;

namespace UIser
{
    public class UIBaser
    {
        #region Public
        public int Width;
        public int Height;
        public float X;
        public float Y;
        public bool Activated { get; set; }
        public Color Color { get; set; }
        public float Scale { get; set; }
        public float Rotation { get; set; }
        public string Name { get; set; } = null;
        public string Description { get; set; } = null;
        public Vector2 Size
        {
            get => new Vector2(Width, Height);
            set
            {
                Width = (int)value.X;
                Height = (int)value.Y;
            }
        }
        public Vector2 Position
        {
            get => new Vector2(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }
        public Rectangle Rectangle
        {
            get => new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            set
            {
                Size = new Vector2(value.Width, value.Height);
                Position = new Vector2(value.X, value.Y);
            }
        }
        public SpriteEffects SpriteEffect { get; set; }
        public delegate void MouseAction(bool? MouseLeft);
        #endregion
        #region Private
        /// <summary>
        /// 是否初始化了
        /// </summary>
        private bool Initialized;
        #endregion
        #region Internal
        internal UIBaser OnBaser;
        internal List<UIBaser> DeBaser;

        internal Action ActionMouseEnter;
        internal Action ActionMouseLeave;

        internal MouseAction ActionMouseClick;
        internal MouseAction ActionMouseDoubleClick;
        #endregion
        /// <summary>
        /// 激活此UI
        /// </summary>
        public void Activation()
        {
            if (!Initialized)
            {
                Initialize();
                Initialized = true;
            }
            Activate();
            DeBaser.ForEach(delegate (UIBaser baser) { baser.Activation(); });
        }
        /// <summary>
        /// 注销此UI
        /// </summary>
        public void Deactivation()
        {
            Deactivate();
            DeBaser.ForEach(delegate (UIBaser baser) { baser.Deactivation(); });
        }
        #region Virtual
        internal virtual bool TestUI => false;
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
        /// 初始化，只执行一次，建议保留 base.Initialize();
        /// </summary>
        protected virtual void Initialize()
        {
            X = Y = Width = Height = 0;
            Name = Description = "";
            ActionMouseClick = MouseClick;
            ActionMouseEnter = MouseEnter;
            ActionMouseLeave = MouseLeave;
            ActionMouseDoubleClick = MouseDoubleClick;
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color, Rotation, Vector2.Zero, Scale, SpriteEffect, 0f);
            if (Rectangle.Contains(Main.mouseX, Main.mouseY) && !string.IsNullOrWhiteSpace(Description))
            {
                Vector2 position = new Vector2(Main.mouseX + 15, Main.mouseY + 15);
                spriteBatch.DrawFiveString(Main.fontMouseText, Description, position, Color.White, Color.Black, Vector2.Zero);
            }
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
        /// <summary>
        /// 别问，问就是懒
        /// </summary>
        public virtual Texture2D Texture => Functionser.Instance.GetTexture("Images/Default");
        #endregion
    }
}