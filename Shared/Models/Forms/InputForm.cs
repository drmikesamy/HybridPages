namespace HybridPages.Shared.Models.Forms
{
    public class InputForm : BaseEntity<InputForm>
    {
        public string Name { get; set; } = "Form Name";
        public string Description { get; set; } = "Form Description";
        public List<InputField> Fields { get; set; } = new();
    }
}