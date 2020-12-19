using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using Terraria.ModLoader;

namespace UIser
{
    public class UIser : Mod
    {
        public const string Instructions = "请转到本 Mod 的 descripton.txt 或 更多信息 查看。";

        internal static bool DeveloperMode
        {
            get;
        } = true;

        internal static UIser Instance
        {
            get;
            private set;
        }

        public UIser()
        {
            Instance = this;
        }

        public UIBaser this[string name]
        {
            get
            {
                MethodInfo info = typeof(UIGetter).GetMethod($"New{name}");
                if (info != null)
                    return (UIBaser)info.Invoke(null, null);
                return null;
            }
        }

        public override void PostDrawInterface(SpriteBatch spriteBatch) => UISetter.PostDrawInterface(spriteBatch);

        public override void UpdateUI(GameTime gameTime) => UISetter.UpdateUI(gameTime);
    }
}