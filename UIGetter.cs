using ReLogic.Graphics;
using UIser.Label;
using UIser.TextBox;

namespace UIser
{
    public static class UIGetter
    {
        public static LabelUI NewLabelUI(DynamicSpriteFont font = null, string Name = Functionser.UIDefaultName, string Description = "",
            string Text = null)
        {
            return new LabelUI(font)
            {
                Name = Name,
                Description = Description
            };
        }

        public static TextBoxUI NewTextBoxUI(DynamicSpriteFont Font = null, string Name = Functionser.UIDefaultName, string Description = "",
            string Text = null)
        {
            return new TextBoxUI(Font)
            {
                Name = Name,
                Description = Description
            };
        }
    }
}