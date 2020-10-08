using Microsoft.Xna.Framework;

namespace UIser.Customize
{
    /// <summary>
    /// 在此类UI中，所有变量都可以被定义，如Size不再调用Wight和Height<para></para>
    /// 这样可以做一个判定面积位置与视角位置不一样的UI<para></para>
    /// 不建议使用（
    /// </summary>
    public class CustomizeUIBaser : UIBaser
    {
        public new Vector2 Size
        {
            get;
            set;
        }

        public new Vector2 Position
        {
            get;
            set;
        }

        public new Vector2 ScreenPosition
        {
            get;
            set;
        }

        public new Rectangle Rectangle
        {
            get;
            set;
        }
    }
}