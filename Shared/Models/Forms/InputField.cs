using HybridPages.Shared.Enums;
using HybridPages.Shared.Models.Forms.Types;

namespace HybridPages.Shared.Models.Forms
{
    public class InputField : BaseEntity<InputField>
    {
        public InputFieldType InputFieldType { get; set; } = new();
        public string? Label { get; set; }
        public string? Description { get; set; }
        public List<InputFieldAttribute> InputAttributeValues { get; set; } = new();
    }
}
