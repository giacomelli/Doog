using System;
namespace Snake.Framework.Animations
{
    public static class Easing
    {
        public static readonly IEase Linear = LinearEase.Default;
        public static readonly IEase InBack = InBackEase.Default;
    }
}
