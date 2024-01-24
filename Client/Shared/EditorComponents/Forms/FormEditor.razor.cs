using HybridPages.Client.State;
using HybridPages.Shared.Models.Forms;

namespace HybridPages.Client.Shared.EditorComponents.Forms
{
	public partial class FormEditor
	{ 
		protected override async Task OnInitializedAsync()
		{
			try
			{

			}
			catch
			{

			}
		}
		public void AddField()
		{
			var field = new InputField
			{
				InputFieldType = _pageService.
			};
			InputForm.Fields.Add(field);
		}
	}
}