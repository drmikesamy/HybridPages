﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HybridPages.Shared.Helpers
{
    public static class TitleToSlug
    {
        public static string ConvertTitleToSlug(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("input");
            }
            var stringBuilder = new StringBuilder();
            foreach (char c in title.ToArray())
            {
                if (Char.IsLetterOrDigit(c))
                {
                    stringBuilder.Append(c);
                }
                else if (c == ' ')
                {
                    stringBuilder.Append("-");
                }
            }
            return stringBuilder.ToString().ToLower();
        }
    }
}
