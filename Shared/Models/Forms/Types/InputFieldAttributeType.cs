using HybridPages.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace HybridPages.Shared.Models.Forms.Types
{
    public class InputFieldAttributeType : BaseEntity<InputFieldAttributeType>
    {
		public string AttributeName { get; set; }
		public HashSet<InputFieldType> InputFieldTypes { get; set; } = new();
	}
}