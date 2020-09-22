using ReLogic.Graphics;
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
        public TextBoxUI() : base()
        {
        }
        public TextBoxUI(DynamicSpriteFont font) : base(font)
        {
        }

        public virtual bool CanWrite => true;

        public override void MouseClick(bool? MouseLeft)
        {
            if (MouseLeft == true && CanWrite)
            {

            }
        }
    }
}