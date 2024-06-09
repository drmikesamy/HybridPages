using HybridPages.Shared.Interfaces;
using HybridPages.Shared.Models;

namespace HybridPages.Shared.Helpers
{
	public static class ListManipulation
	{
		public static LinkedList<Post> MoveUp(this LinkedList<Post> list, Post item)
		{
			var node = FindById(list, item.Id);

			if (node.Previous != null)
			{
				var previous = node.Previous;
				list.Remove(node);
				list.AddBefore(previous, node);
			}
			return list;
		}
		public static LinkedList<Post> MoveDown(this LinkedList<Post> list, Post item)
		{
			var node = FindById(list, item.Id);

			if (node.Next != null)
			{
				var next = node.Next;
				list.Remove(node);
				list.AddAfter(next, node);
			}
			return list;
		}
		public static void Swap(Post? item1, Post? item2)
		{
			if(item1 == null || item2 == null) return;

			Post temp = item1;
			item1 = item2;
			item2 = temp;
		}
		public static LinkedListNode<Post>? FindById(LinkedList<Post> list, long id)
		{
			var currentNode = list.First;
			while (currentNode != null)
			{
				if (currentNode.Value.Id == id)
				{
					return currentNode;
				}
				currentNode = currentNode.Next;
			}
			return null;
		}
	}
}
