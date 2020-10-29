using System;
using Terraria;

namespace UIser
{
    public static class UILoader
    {
        internal static UIBaser clickUIBefore;
        internal static UIBaser clickUINow;

        internal static DateTime clickTime;

        public static class Mouse
        {
            public static bool ClickAny => Left.Click || Middle.Click || Right.Click;

            public static bool PressAny => Left.Press || Middle.Press || Right.Press;

            public static class Left
            {
                public static bool Click => Main.mouseLeft && Main.mouseLeftRelease;

                public static bool Press => Main.mouseLeft;
            }

            public static class Right
            {
                public static bool Click => Main.mouseRight && Main.mouseRightRelease;

                public static bool Press => Main.mouseRight;
            }

            public static class Middle
            {
                public static bool Click => Main.mouseMiddle && Main.mouseMiddleRelease;

                public static bool Press => Main.mouseMiddle;
            }
        }
    }
}