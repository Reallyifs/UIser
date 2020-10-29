using ReLogic.Graphics;
using UIser.Button;
using UIser.Label;
using UIser.TextBox;

namespace UIser
{
    public static class UIGetter
    {
        public static ButtonUI NewButtonUI(string name = UIBaser.UIDefaultName, string description = "",
            DynamicSpriteFont font = null)
        {
            ButtonUI button = new ButtonUI(font)
            {
                Name = name,
                Description = description
            };
            return button;
        }

        public static CustomizeLabelUI NewCustomizeLabelUI(string name = UIBaser.UIDefaultName, string description = "",
            DynamicSpriteFont font = null)
        {
            CustomizeLabelUI label = new CustomizeLabelUI(font)
            {
                Name = name,
                Description = description
            };
            return label;
        }

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