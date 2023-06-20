using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HybridPages.Shared.Helpers
{
    public static class ParseEmbeds
    {
        public static IEnumerable<string> DetectYoutubeLink(string input)
        {
			var pattern = @"(?:youtube(?:-nocookie)?\.com\/(?:[^\/]+\/.+\/|(?:v|e(?:mbed)?)\/|.*[?&]v=)|youtu\.be\/)([^&?\/ ]{11})";
            foreach (Match m in Regex.Matches(input, pattern))
            {
				yield return m.Value;
			}
        }
    }
}
