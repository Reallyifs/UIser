using ReLogic.Graphics;
using UIser.TextBox;

namespace UIser
{
    public static class UIGetter
    {
        public static TextBoxUI NewTextBoxUI(DynamicSpriteFont Font, string Name = Functionser.UIDefaultName, string Description = "")
        {
            return new TextBoxUI(Font)
            {
                Name = Name,
                Description = Description
            };
        }
    }
}