using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UIser.Image
{
    public class ImageUI : UIBaser
    {
        /// <summary>
        /// 图片的宽
        /// </summary>
        public int ImageWight = 0;

        /// <summary>
        /// 图片的高
        /// </summary>
        public int ImageHeight = 0;

        /// <summary>
        /// 图片在UI中的位置X（以基类 <see cref="UIBaser.X"/> 为原点）
        /// </summary>
        public int ImagePositionX = 0;

        /// <summary>
        /// 图片在UI中的位置X（以基类 <see cref="UIBaser.Y"/> 为原点）
        /// </summary>
        public int ImagePositionY = 0;

        /// <summary>
        /// 图片的颜色
        /// </summary>
        public Color ImageColor
        {
            get;
            set;
        } = Color.White;

        /// <summary>
        /// 图片的旋转
        /// </summary>
        public float ImageRotation
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// 图片在UI中的位置X（以基类 <see cref="UIBaser.Position"/> 为原点）
        /// </summary>
        public Vector2 ImagePosition
        {
            get => new Vector2(ImagePositionX, ImagePositionY);
            set
            {
                ImagePositionX = (int)value.X;
                ImagePositionY = (int)value.Y;
            }
        }

        /// <summary>
        /// 图片的缩放
        /// </summary>
        public Vector2 ImageScale
        {
            get;
            set;
        } = Vector2.Zero;

        /// <summary>
        /// 图片的尺寸
        /// </summary>
        public Vector2 ImageSize
        {
            get => new Vector2(ImageWight, ImageHeight);
            set
            {
                ImageWight = (int)value.X;
                ImageHeight = (int)value.Y;
            }
        }

        /// <summary>
        /// 要显示的图像
        /// </summary>
        public Texture2D Image
        {
            get;
            set;
        } = null;

        /// <summary>
        /// 显示的图像的判定面积
        /// </summary>
        public Rectangle ImageRectangle
        {
            get => new Rectangle(ImagePositionX, ImagePositionY, ImageWight, ImageHeight);
            set
            {
                ImageWight = value.Width;
                ImageHeight = value.Height;
                ImagePositionX = value.X;
                ImagePositionY = value.Y;
            }
        }

        /// <summary>
        /// 图片的效果
        /// </summary>
        public SpriteEffects ImageEffect
        {
            get;
            set;
        } = SpriteEffects.None;

        /// <summary>
        /// 获取一个 <see cref="ImageUI"/>
        /// </summary>
        public ImageUI() : base()
        {
        }

        /// <summary>
        /// 获取一个 <see cref="ImageUI"/>，使用指定的贴图
        /// </summary>
        /// <param name="texture">要显示的图像</param>
        public ImageUI(Texture2D texture) : base()
        {
            Image = texture;
            ImageWight = texture?.Width ?? 0;
            ImageHeight = texture?.Height ?? 0;
        }

        /// <summary>
        /// 获取一个 <see cref="ImageUI"/>，使用指定的贴图和缩放
        /// </summary>
        /// <param name="texture">要显示的图像</param>
        /// <param name="scale">图像的缩放</param>
        public ImageUI(Texture2D texture, float scale) : base()
        {
            Image = texture;
            ImageScale = new Vector2(scale);
            ImageWight = texture?.Width ?? 0;
            ImageHeight = texture?.Height ?? 0;
        }

        /// <summary>
        /// 获取一个 <see cref="ImageUI"/>，使用指定的贴图和缩放
        /// </summary>
        /// <param name="texture">要显示的图像</param>
        /// <param name="scale">图像的缩放</param>
        public ImageUI(Texture2D texture, Vector2 scale) : base()
        {
            Image = texture;
            ImageScale = scale;
            ImageWight = texture?.Width ?? 0;
            ImageHeight = texture?.Height ?? 0;
        }

        /// <summary>
        /// 检测能否更改其显示的图像
        /// </summary>
        /// <param name="texture">更改的图像</param>
        /// <returns></returns>
        public virtual bool CanChangeImage(Texture2D texture) => texture != null;

        /// <summary>
        /// 更改其显示的图像
        /// </summary>
        /// <param name="texture">更改的图像</param>
        public virtual void ChangeImage(Texture2D texture)
        {
            if (CanChangeImage(texture))
                Image = texture;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (Image != null)
            {
                Rectangle imageDrawRectangle = new Rectangle(0, 0, ImageWight, ImageHeight);
                spriteBatch.Draw(Image, ImagePosition, imageDrawRectangle, ImageColor, ImageRotation, Vector2.Zero, ImageScale, ImageEffect, 0);
            }
        }
    }
}