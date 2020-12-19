using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace UIser
{
    public partial class UIBaser
    {
        public int Width = 0;
        public int Height = 0;
        public float X = 0;
        public float Y = 0;

        /// <summary>
        /// 此UI是否已启用
        /// </summary>
        public bool Activated
        {
            get;
            set;
        } = false;

        /// <summary>
        /// 此UI Draw时的Color
        /// </summary>
        public Color Color
        {
            get;
            set;
        } = Color.White;

        /// <summary>
        /// 此UI Draw时的Scale
        /// </summary>
        public float Scale
        {
            get;
            set;
        } = 0f;

        /// <summary>
        /// 此UI Draw时的Rotation
        /// </summary>
        public float Rotation
        {
            get;
            set;
        } = 0f;

        /// <summary>
        /// 此UI的内部名称
        /// </summary>
        public string Name
        {
            get;
            set;
        } = UIDefaultName;

        /// <summary>
        /// 此UI的描述，将会Draw在鼠标下方
        /// </summary>
        public string Description
        {
            get;
            set;
        } = string.Empty;

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
        /// 此UI在屏幕上的位置
        /// </summary>
        public Vector2 ScreenPosition
        {
            get => Position - Main.screenPosition;
            set => Position = value + Main.screenPosition;
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
        /// 此UI Draw时的Effect
        /// </summary>
        public SpriteEffects SpriteEffect
        {
            get;
            set;
        } = SpriteEffects.None;

        public delegate void MouseAction(bool? MouseLeft);

        public const string UIDefaultName = "UIser : DefaultName";
    }
}