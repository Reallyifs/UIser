using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using UIser.Button;
using UIser.Image;
using UIser.Label;
using UIser.TextBox;

namespace UIser
{
    public static class UIGetter
    {
        public static ImageUI NewImageUI(string name = UIBaser.UIDefaultName, string desctiption = "")
        {
            ImageUI image = new ImageUI()
            {
                Name = name,
                Description = desctiption
            };
            return image;
        }

        public static ImageUI NewImageUI(Texture2D texture, string name = UIBaser.UIDefaultName, string desctiption = "")
        {
            ImageUI image = new ImageUI(texture)
            {
                Name = name,
                Description = desctiption
            };
            return image;
        }

        public static ImageUI NewImageUI(Texture2D texture, float scale, string name = UIBaser.UIDefaultName, string desctiption = "")
        {
            ImageUI image = new ImageUI(texture, scale)
            {
                Name = name,
                Description = desctiption
            };
            return image;
        }

        public static ImageUI NewImageUI(Texture2D texture, Vector2 scale, string name = UIBaser.UIDefaultName, string desctiption = "")
        {
            ImageUI image = new ImageUI(texture, scale)
            {
                Name = name,
                Description = desctiption
            };
            return image;
        }

        public static ButtonUI NewButtonUI(DynamicSpriteFont font, string name = UIBaser.UIDefaultName, string description = "")
        {
            ButtonUI button = new ButtonUI(font)
            {
                Name = name,
                Description = description
            };
            return button;
        }

        public static ButtonUI NewButtonUI(string name = UIBaser.UIDefaultName, string description = "")
        {
            ButtonUI button = new ButtonUI()
            {
                Name = name,
                Description = description
            };
            return button;
        }

        public static ButtonUI NewButtonUI(Texture2D defaultTexture, Texture2D pressingTexture,
            string name = UIBaser.UIDefaultName, string description = "")
        {
            ButtonUI button = new ButtonUI(defaultTexture, pressingTexture)
            {
                Name = name,
                Description = description
            };
            return button;
        }

        public static ButtonUI NewButtonUI(Texture2D defaultTexture, Texture2D pressingTexture, DynamicSpriteFont font,
            string name = UIBaser.UIDefaultName, string description = "")
        {
            ButtonUI button = new ButtonUI(defaultTexture, pressingTexture, font)
            {
                Name = name,
                Description = description
            };
            return button;
        }

        public static ButtonUI NewButtonUI(Texture2D defaultTexture, Texture2D enterTexture, Texture2D pressTexture,
            string name = UIBaser.UIDefaultName, string description = "")
        {
            ButtonUI button = new ButtonUI(defaultTexture, enterTexture, pressTexture)
            {
                Name = name,
                Description = description
            };
            return button;
        }

        public static ButtonUI NewButtonUI(Texture2D defaultTexture, Texture2D enterTexture, Texture2D pressTexture, DynamicSpriteFont font,
            string name = UIBaser.UIDefaultName, string description = "")
        {
            ButtonUI button = new ButtonUI(defaultTexture, enterTexture, pressTexture, font)
            {
                Name = name,
                Description = description
            };
            return button;
        }

        public static ButtonUI NewButtonUI(Texture2D defaultTexture, DynamicSpriteFont font,
            string name = UIBaser.UIDefaultName, string description = "")
        {
            ButtonUI button = new ButtonUI(defaultTexture, font)
            {
                Name = name,
                Description = description
            };
            return button;
        }

        public static ButtonUI NewButtonUI(Texture2D defaultTexture, string name = UIBaser.UIDefaultName, string description = "")
        {
            ButtonUI button = new ButtonUI(defaultTexture)
            {
                Name = name,
                Description = description
            };
            return button;
        }

        public static CustomizeLabelUI NewCustomizeLabelUI(string name = UIBaser.UIDefaultName, string description = "")
        {
            CustomizeLabelUI label = new CustomizeLabelUI()
            {
                Name = name,
                Description = description
            };
            return label;
        }

        public static LabelUI NewLabelUI(string name = UIBaser.UIDefaultName, string description = "")
        {
            LabelUI label = new LabelUI()
            {
                Name = name,
                Description = description
            };
            return label;
        }

        public static LabelUI NewLabelUI(string text, DynamicSpriteFont font, string name = UIBaser.UIDefaultName, string description = "")
        {
            LabelUI label = new LabelUI(text, font)
            {
                Name = name,
                Description = description
            };
            return label;
        }

        public static LabelUI NewLabelUI(string text, string name = UIBaser.UIDefaultName, string description = "")
        {
            LabelUI label = new LabelUI(text)
            {
                Name = name,
                Description = description
            };
            return label;
        }

        public static LabelUI NewLabelUI(DynamicSpriteFont font, string name = UIBaser.UIDefaultName, string description = "")
        {
            LabelUI label = new LabelUI(font)
            {
                Name = name,
                Description = description
            };
            return label;
        }

        public static TextBoxUI NewTextBoxUI(string text, string name = UIBaser.UIDefaultName, string description = "")
        {
            TextBoxUI textBox = new TextBoxUI(text)
            {
                Name = name,
                Description = description
            };
            return textBox;
        }

        public static TextBoxUI NewTextBoxUI(string name = UIBaser.UIDefaultName, string description = "")
        {
            TextBoxUI textBox = new TextBoxUI()
            {
                Name = name,
                Description = description
            };
            return textBox;
        }

        public static TextBoxUI NewTextBoxUI(DynamicSpriteFont font, string name = UIBaser.UIDefaultName, string description = "")
        {
            TextBoxUI textBox = new TextBoxUI(font)
            {
                Name = name,
                Description = description
            };
            return textBox;
        }

        public static TextBoxUI NewTextBoxUI(string text, DynamicSpriteFont font, string name = UIBaser.UIDefaultName, string description = "")
        {
            TextBoxUI textBox = new TextBoxUI(text, font)
            {
                Name = name,
                Description = description
            };
            return textBox;
        }
    }
}