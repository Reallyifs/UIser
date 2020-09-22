using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace UIser
{
    public partial class UIBaser
    {
        public UIBaser()
        {
            X = Y = 0;
            Name = Description = "";
            Color = Color.White;
            Scale = 0;
            Width = Height = 0;
            OnBaser = null;
            DeBaser = new List<UIBaser>();
            Rotation = 0;
            SpriteEffect = SpriteEffects.None;
        }

        /// <summary>
        /// 添加UI到此UI的DeBaser，视为所添加的UI依赖此UI
        /// </summary>
        /// <param name="baser">所添加的UI</param>
        public void AddUIBaser(UIBaser baser)
        {
            if (!DeBaser.Contains(baser))
            {
                baser.OnBaser = this;
                DeBaser.Add(baser);
            }
        }

        /// <summary>
        /// 激活此UI
        /// </summary>
        public void Activation()
        {
            if (!Activated)
            {
                if (!Initialized)
                {
                    Initialize();
                    Initialized = true;
                }
                Activate();
                Activated = true;
                BaserAdd(this);
                DeBaser.ForEach(delegate (UIBaser baser) { baser.Activation(); });
            }
        }

        /// <summary>
        /// 注销此UI
        /// </summary>
        public void Deactivation()
        {
            if (Activated)
            {
                Deactivate();
                Activated = false;
                BaserRemove(this);
                DeBaser.ForEach(delegate (UIBaser baser) { baser.Deactivation(); });
            }
        }

        /// <summary>
        /// 获得此UI所依赖的UI
        /// </summary>
        /// <returns>依赖的UI</returns>
        public UIBaser GetOnBaser() => OnBaser;

        /// <summary>
        /// 获得依赖此UI的UIs
        /// </summary>
        /// <returns>依赖此UI的UIs</returns>
        public List<UIBaser> GetDeBaser() => DeBaser;
    }
}