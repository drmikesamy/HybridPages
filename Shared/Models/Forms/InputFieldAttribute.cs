using HybridPages.Shared.Enums;
using HybridPages.Shared.Models.Forms.Types;

namespace HybridPages.Shared.Models.Forms
{
	public class InputFieldAttribute : BaseEntity<InputFieldAttribute>
	{
		public InputFieldAttributeType InputFieldAttributeType { get; set; } = new();
		public InputFieldAttributeOptionEnum Value;
		public string? StringValue;
	}
}