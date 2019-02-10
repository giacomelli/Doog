using System;
using System.Globalization;

namespace Doog
{
    /// <summary>
    /// String extension methods.
    /// </summary>
    public static class StringExtensions
    {
        public static string With(this string message, params object[] args)
        {
            return String.Format(CultureInfo.InvariantCulture, message, args);
        }
    }
}