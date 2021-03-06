﻿using System.Linq;

namespace TrashRouting.Common.Extensions
{
    public static class StringExtensions
    {
        public static string Underscore(this string value)
            => string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));
    }
}
