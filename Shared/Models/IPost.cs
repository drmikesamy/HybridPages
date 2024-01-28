namespace HybridPages.Shared.Models
{
	public interface IPost
	{
		long PageId { get; set; }
		string Title { get; set; }
		string Content { get; set; }
	}
}