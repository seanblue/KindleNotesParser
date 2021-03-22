namespace KindleNotes.Models
{
	internal static class KindleClippingTypeConsts
	{
		internal static readonly string BookmarkTypeKeyword = GetKeyword("Bookmark");
		internal static readonly string HighlightTypeKeyword = GetKeyword("Highlight");
		internal static readonly string NoteTypeKeyword = GetKeyword("Note");

		internal static string GetKeyword(string type) => $"- Your {type} on Location";
	}
}
