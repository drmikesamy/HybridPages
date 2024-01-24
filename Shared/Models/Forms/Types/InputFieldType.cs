using HybridPages.Shared.Enums;
using HybridPages.Shared.Models.Forms.Types;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;

namespace HybridPages.Shared.Models.Forms.Types
{
    public class InputFieldType : BaseEntity<InputFieldType>
    {
        public string Tag { get; set; }
        public HashSet<InputFieldAttributeType> InputFieldAttributeTypes { get; set; } = new();
    }
}