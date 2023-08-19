using HybridPages.Shared.Enums;

namespace HybridPages.Shared.Models.TextEditor
{
	public class TextLine
	{
		public string Content { get; set; } = "Your text here";
		public List<TextLine> ChildTextLines { get; set; } = new List<TextLine>();
		public TextLineTypeEnum TextLineType { get; set; } = TextLineTypeEnum.P;
	}
	public class FormatBlock
	{
		public string Content { get; set; } = "";
		public FormatBlockTypeEnum Format { get; set; } = FormatBlockTypeEnum.None;
	}
}
