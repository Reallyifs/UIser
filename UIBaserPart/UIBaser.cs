using UIser.Customize;

namespace UIser
{
    /// <summary>
    /// 所有此Mod所编写的UI的基类，包括 <see cref="CustomizeUIBaser"/>
    /// </summary>
    public partial class UIBaser
    {
    }

    public class TestBaser : UIBaser
    {
        internal override bool TestUI => true;
    }
}