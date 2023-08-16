using HybridPages.Shared.Enums;
using HybridPages.Shared.Models.TextEditor;
using Microsoft.AspNetCore.Components;
using System.Web;

namespace HybridPages.Shared.Helpers
{
	public static class ParseEmbeds
	{
		public static MarkupString ParseVideoUrl(string input)
		{
			var uri = new Uri(input);

			if (uri.Host == "youtube.com" || uri.Host == "www.youtube.com" || uri.Host == "youtu.be")
			{
				var query = HttpUtility.ParseQueryString(uri.Query);
				var videoId = string.Empty;
				if (query.AllKeys.Contains("v"))
				{
					videoId = query["v"];
				}
				else
				{
					videoId = uri.Segments.Last();
				}

				return (MarkupString)$"""<iframe class="video-player" src="https://www.youtube.com/embed/{videoId}" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>""";
			}
			else if (uri.Host == "vimeo.com" || uri.Host == "www.vimeo.com")
			{
				var videoId = uri.Segments.Last();
				return (MarkupString)$"""<iframe class="video-player" src="https://player.vimeo.com/video/{videoId}" frameborder="0" allow="autoplay; fullscreen; picture-in-picture" allowfullscreen></iframe>""";
			}

			return (MarkupString)"""<div class="error"><p>Invalid Video URL</p></div>""";
		}
		public static MarkupString ParseLongformContent(List<TextLine> textLines)
		{
			var markUp = string.Empty;

			foreach (var textLine in textLines)
			{
				var tag = textLine.TextLineType.ToString();
				markUp += $"<{tag}>{textLine.Content}";
				markUp += ParseLongformContent(textLine.ChildTextLines);
				markUp += $"</{tag}>";
			}

			return (MarkupString)markUp;
		}

		public static MarkupString StringAsMarkup(string text)
		{
			return (MarkupString)text;
		}
	}
}
