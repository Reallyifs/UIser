using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UIser
{
    public partial class UIBaser
    {
        public int Width;
        public int Height;
        public float X;
        public float Y;

        /// <summary>
        /// 此UI是否已启用
        /// </summary>
        public bool Activated { get; set; }

        /// <summary>
        /// 此UI Draw时的Color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// 此UI Draw时的Scale
        /// </summary>
        public float Scale { get; set; }

        /// <summary>
        /// 此UI Draw时的Rotation
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// 此UI的内部名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 此UI的描述，将会Draw在鼠标下方
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 此UI的长宽
        /// </summary>
        public Vector2 Size
        {
            get => new Vector2(Width, Height);
            set
            {
                Width = (int)value.X;
                Height = (int)value.Y;
            }
        }

        /// <summary>
        /// 此UI的位置
        /// </summary>
        public Vector2 Position
        {
            get => new Vector2(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        /// 此UI的判定矩形
        /// </summary>
        public Rectangle Rectangle
        {
            get => new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
            set
            {
                Size = new Vector2(value.Width, value.Height);
                Position = new Vector2(value.X, value.Y);
            }
        }

        /// <summary>
        /// 此UI Draw时的Effects
        /// </summary>
        public SpriteEffects SpriteEffect { get; set; }

        public delegate void MouseAction(bool? MouseLeft);
    }
}