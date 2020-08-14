using System.Reflection;
using Terraria.ModLoader;

namespace UIser
{
    public class UIser : Mod
    {
        public UIser()
        {
            Functionser.Instance = this;
            Functionser.Assembly = Assembly.GetExecutingAssembly();
        }
    }
}