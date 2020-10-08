using ReLogic.Graphics;
using UIser.Label;
using UIser.TextBox;

namespace UIser
{
    public static class UIGetter
    {
        public static LabelUI NewLabelUI(string name = UIBaser.UIDefaultName, string description = "", DynamicSpriteFont font = null)
        {
            LabelUI label = new LabelUI(font)
            {
                Name = name,
                Description = description
            };
            return label;
        }

        public static TextBoxUI NewTextBoxUI(string name = UIBaser.UIDefaultName, string description = "", DynamicSpriteFont font = null)
        {
            TextBoxUI label = new TextBoxUI(font)
            {
                Name = name,
                Description = description
            };
            return label;
        }
    }
}